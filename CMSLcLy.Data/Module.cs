using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data
{
    public class Module<T> where T : System.Data.Entity.DbContext, IDisposable
    {
        public static bool ForceDisconnectSSO = false;
        public T Context { get; set; }
        public Module(T context)
        {
            Context = context;
            Context.Database.CommandTimeout = 1 * 60; // 10 min

            // update connection string is sso exists
            if (!ForceDisconnectSSO && Security.SSOApiCaller.Manager.HasApiUrl())
            {
                if (string.IsNullOrEmpty(MAT.Context.Profile.DatabaseName))
                    throw new Exception("SSO Database Name is empty");

                // replace database name
                var oldDb = $"database={Context.Database.Connection.Database}";
                var newDb = $"database={MAT.Context.Profile.DatabaseName}";
                var newConStr = Context.Database.Connection.ConnectionString.Replace(oldDb, newDb);
                Context.Database.Connection.ConnectionString = newConStr;
            }
        }

        public virtual int SaveChanges()
        {
            var result = Context?.SaveChanges();
            return result ?? 0;
        }

        protected void SetAuditData(object obj)
        {
            var propertyInfo = obj.GetType().GetProperties();

            /// detected whether this object is new record
            /// object is new record if the createddate is equal datetime.minvalue
            var isNew = false;
            var createdDateProperty = propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "createddate");
            if (createdDateProperty != null)
            {
                var createdDate = (DateTime)createdDateProperty.GetValue(obj);
                isNew = createdDate == DateTime.MinValue;   // if datatime is min, will be treated as new data
            }

            if (isNew)
            {
                var entityPropertyInfo = propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "entityid");
                if (entityPropertyInfo != null && (Guid)entityPropertyInfo.GetValue(obj) == Guid.Empty) entityPropertyInfo.SetValue(obj, MAT.Context.Profile.EntityId);

                propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "createddate")?.SetValue(obj, DateTime.Now);
                propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "createdby")?.SetValue(obj, MAT.Context.Profile.UserId);

                var subscriptionPropertyInfo = propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "subscriptionid");
                if (subscriptionPropertyInfo != null && (Guid)subscriptionPropertyInfo.GetValue(obj) == Guid.Empty) subscriptionPropertyInfo.SetValue(obj, MAT.Context.Profile.SubscriptionId);
            }

            // set guid for primary key if still empty
            var className = TypeDescriptor.GetClassName(obj).Split('.').Last();
            var primaryKeyName = $"{className}Id";
            var primaryKeyPropertyInfo = propertyInfo.FirstOrDefault(r => r.Name.ToLower() == primaryKeyName.ToLower());
            if (primaryKeyPropertyInfo != null)
            {
                var pid = (Guid)primaryKeyPropertyInfo.GetValue(obj);
                if (pid == Guid.Empty) primaryKeyPropertyInfo.SetValue(obj, Guid.NewGuid());
            }

            propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "modifieddate")?.SetValue(obj, DateTime.Now);
            propertyInfo.FirstOrDefault(r => r.Name.ToLower() == "modifiedby")?.SetValue(obj, MAT.Context.Profile.UserId);
        }

        protected virtual void BindInsertData(object obj) => SetAuditData(obj);
        protected virtual void BindUpdateData(object obj) => SetAuditData(obj);

        protected void TryUpdateModel(object target, object source, bool checkPropertyType = false)
        {
            MAT.Helper.Reflector.TryUpdateModel(target, source, checkPropertyType);
        }
        //
        // Summary:
        //     Creates a raw SQL query that will return elements of the given generic type.
        //      The type can be any type that has properties that match the names of the
        //     columns returned from the query, or can be a simple primitive type. The type
        //     does not have to be an entity type. The results of this query are never tracked
        //     by the context even if the type of object returned is an entity type. Use
        //     the System.Data.Entity.DbSet<TEntity>.SqlQuery(System.String,System.Object[])
        //     method to return entities that are tracked by the context.  As with any API
        //     that accepts SQL it is important to parameterize any user input to protect
        //     against a SQL injection attack. You can include parameter place holders in
        //     the SQL query string and then supply parameter values as additional arguments.
        //     Any parameter values you supply will automatically be converted to a DbParameter.
        //      context.Database.SqlQuery<Post>("SELECT * FROM dbo.Posts WHERE Author =
        //     @p0", userSuppliedAuthor); Alternatively, you can also construct a DbParameter
        //     and supply it to SqlQuery. This allows you to use named parameters in the
        //     SQL query string.  context.Database.SqlQuery<Post>("SELECT * FROM dbo.Posts
        //     WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   sql:
        //     The SQL query string.
        //
        //   parameters:
        //     The parameters to apply to the SQL query string. If output parameters are
        //     used, their values will not be available until the results have been read
        //     completely. This is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     The type of object returned by the query.
        //
        // Returns:
        //     A System.Data.Entity.Infrastructure.DbRawSqlQuery<TElement> object that will
        //     execute the query when it is enumerated.
        public System.Data.Entity.Infrastructure.DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return SqlQuery<T>(sql, string.Empty, parameters);
        }

        public System.Data.Entity.Infrastructure.DbRawSqlQuery<T> SqlQuery<T>(string sql, string connectionString, params object[] parameters)
        {
            var previousConnectionString = this.Context.Database.Connection.ConnectionString;
            try
            {
                this.Context.Database.Connection.ConnectionString = GetConnectionString(connectionString);

                // parse parameters, convert NULL to DBNull 
                ApplyDBNull(parameters);

                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Closed)
                    this.Context.Database.Connection.Open();

                this.Context.Database.CommandTimeout = 10 * 60;
                return this.Context.Database.SqlQuery<T>(sql, parameters);
            }
            finally
            {
                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Open)
                    this.Context.Database.Connection.Close();

                this.Context.Database.Connection.ConnectionString = previousConnectionString;
            }
        }

        string GetConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) connectionString = "ConnectionString";
            return System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            // parse parameters, convert NULL to DBNull 
            ApplyDBNull(parameters);

            this.Context.Database.CommandTimeout = 10 * 60;

            return this.Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        void ApplyDBNull(params object[] parameters)
        {
            foreach (System.Data.Common.DbParameter item in parameters)
                if (item.Value == null) item.Value = DBNull.Value;
        }

        public object ExecuteScalar(string sql, params object[] parameters)
        {
            try
            {
                // parse parameters, convert NULL to DBNull 
                ApplyDBNull(parameters);

                var cmd = this.Context.Database.Connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);

                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Closed)
                    this.Context.Database.Connection.Open();

                var result = cmd.ExecuteScalar();

                return result;
            }
            finally
            {
                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Open)
                    this.Context.Database.Connection.Close();
            }
        }

        public System.Data.DataTable ExecuteReaderReturnWithDataTable(string sql, params object[] parameters)
        {
            ApplyDBNull(parameters);
            using (var con = new System.Data.SqlClient.SqlConnection(this.Context.Database.Connection.ConnectionString))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);

                con.Open();

                var result = new System.Data.DataTable();
                var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
                adapter.Fill(result);

                con.Close();
                return result;
            }
        }

        public List<T> ExecuteReader<T>(string sql, params object[] parameters)
        {
            try
            {
                // parse parameters, convert NULL to DBNull 
                ApplyDBNull(parameters);

                var cmd = this.Context.Database.Connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);

                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Closed)
                    this.Context.Database.Connection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<T>();
                if (reader.HasRows)
                {
                    // get properties name from class
                    var properties = typeof(T).GetProperties();
                    var propertyNameList = new List<string>();
                    foreach (var property in properties)
                        propertyNameList.Add(property.Name);

                    // get columns name from schema table
                    var schemaColumNameList = new List<string>();
                    foreach (System.Data.DataRow row in reader.GetSchemaTable().Rows)
                        schemaColumNameList.Add(row["ColumnName"].ToString().ToLower());

                    // get common name in both schema and class
                    var columnNameList = new List<KeyValuePair<int, string>>();
                    foreach (var name in propertyNameList)
                        if (schemaColumNameList.Contains(name.ToLower())) columnNameList.Add(new KeyValuePair<int, string>(schemaColumNameList.IndexOf(name.ToLower()), name));

                    // read data into object list
                    T item;
                    while (reader.Read())
                    {
                        // init new object
                        item = System.Activator.CreateInstance<T>();

                        // read data
                        foreach (var column in columnNameList)
                        {
                            var val = reader.GetValue(column.Key);
                            if (val != DBNull.Value) MAT.Helper.Reflector.SetPropertyValue(item, column.Value, reader.GetValue(column.Key));
                        }

                        // add to result list
                        result.Add(item);
                    }
                }

                return result;
            }
            finally
            {
                if (this.Context.Database.Connection.State == System.Data.ConnectionState.Open)
                    this.Context.Database.Connection.Close();
            }
        }
    }
}
