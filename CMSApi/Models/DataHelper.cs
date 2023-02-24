using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using CMSApi.Models;
using System.Web.Mvc;
using System.IO;

namespace CMSApi.Models
{
    public class DataHelper
    {
        public static DocumentModel GetDocument(string documentid, string searchID="")
        {
            DocumentModel docModel = new DocumentModel();
            MySqlConnection cnn;
            MySqlCommand command;
            MySqlDataReader reader;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;
            SqlDataReader sqlreader;

            DataTable dt = new DataTable();

            string documentpath = "";
            string documentname = "";
            string documentDS = "";
            string primarykey = "";

            string sql = "";

            sql = "select * from documentconfig where documentID=" + documentid;
            //string connetionString = @"Data Source=localhost;Initial Catalog=IFCANET_Standard32;User ID=sa;Password=sql123!@#";
            //string connetionString = "Data Source=127.0.0.1;Initial Catalog=cmslcly_mysql;User Id=root;Password=JustDoIt!123";
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    documentpath = AppDomain.CurrentDomain.BaseDirectory + "DocumentTemplate\\" + reader["documentName"].ToString();
                    documentname = reader["documentName"].ToString();
                    documentDS = reader["dataSource"].ToString();
                    primarykey = reader["primary_key"].ToString();
                }
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);
                sqlcnn.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    documentpath = AppDomain.CurrentDomain.BaseDirectory + "DocumentTemplate\\" + sqlreader["documentName"].ToString();
                    documentname = sqlreader["documentName"].ToString();
                    documentDS = sqlreader["dataSource"].ToString();
                    primarykey = sqlreader["primary_key"].ToString();
                }
                sqlcnn.Close();
            }

            sql = "select * from " + documentDS;
            if (!string.IsNullOrEmpty(searchID))
            {
                //sql = sql + " where " + primarykey + "=" + searchID;
                sql = sql + " where " + primarykey + "='" + searchID + "'";
            }

            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);
                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(dt);
                sqlcnn.Close();
            }

            docModel.DocumentId = documentid;
            docModel.DocumentPath = documentpath.Substring(0,documentpath.LastIndexOf('\\'));
            docModel.DocumentName = documentname;
            docModel.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            docModel.DocumentDs = dt;

            return docModel;
        }

        public static List<DocumentModel> GetDocumentList()
        {
            List<DocumentModel> docmodellist = new List<DocumentModel>();
            MySqlConnection cnn;
            MySqlCommand command;
            MySqlDataReader reader;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;
            SqlDataReader sqlreader;

            string documentpath = "";
            string documentname = "";
            string documentDS = "";
            string primarykey = "";

            string sql = "";

            sql = "select * from documentconfig";
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentModel docModel = new DocumentModel();
                    docModel.DocumentId = reader["documentID"].ToString();
                    docModel.DocumentPath = AppDomain.CurrentDomain.BaseDirectory + "DocumentTemplate\\" + reader["documentName"].ToString();
                    docModel.DocumentName = reader["documentName"].ToString();
                    docModel.DocumentType = reader["documentType"].ToString();
                    docModel.dataSource = reader["dataSource"].ToString();
                    docModel.primary_key = reader["primary_key"].ToString();
                    docmodellist.Add(docModel);
                }
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);
                sqlcnn.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    DocumentModel docModel = new DocumentModel();
                    docModel.DocumentId = sqlreader["documentID"].ToString();
                    docModel.DocumentPath = AppDomain.CurrentDomain.BaseDirectory + "DocumentTemplate\\" + sqlreader["documentName"].ToString();
                    docModel.DocumentName = sqlreader["documentName"].ToString();
                    docModel.DocumentType = sqlreader["documentType"].ToString();
                    docModel.dataSource = sqlreader["dataSource"].ToString();
                    docModel.primary_key = sqlreader["primary_key"].ToString();
                    docmodellist.Add(docModel);
                }
                sqlcnn.Close();
            }


            return docmodellist;
        }

        public static void SaveDocumentTemplate(string documentid, string documentpath)
        {
            MySqlConnection cnn;
            MySqlCommand command;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;

            DataTable dt = new DataTable();
            string sql = "";
            string documentname = "";

            documentname = documentpath.Substring(documentpath.LastIndexOf('\\')+1);
            sql = "update documentconfig set documentname='" + documentname + "', documentpath='" + documentpath + "' where documentID=" + documentid;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);
                sqlcnn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcnn.Close();
            }

        }

        public static DataTable getList(string documentid)
        {
            SqlConnection cnn;
            SqlCommand command;
            DataTable dt = new DataTable();

            string documentpath = "";
            string documentname = "";
            string documentDS = "";
            string primarykey = "";

            string sql = "";

            sql = "select * from documentconfig where documentID=" + documentid;
            string connetionString = @"Data Source=localhost;Initial Catalog=IFCANET_Standard32;User ID=sa;Password=sql123!@#";
            cnn = new SqlConnection(connetionString);
            command = new SqlCommand(sql, cnn);
            cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                documentpath = reader["documentpath"].ToString();
                documentname = reader["documentName"].ToString();
                documentDS = reader["dataSource"].ToString();
                primarykey = reader["primary_key"].ToString();
            }
            cnn.Close();

            sql = "select " + primarykey + " as Name, " + primarykey + " as Value from " + documentDS;
            command = new SqlCommand(sql, cnn);
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            cnn.Close();

            return dt;
        }

        public static DataTable getDocType(int documentid)
        {
            MySqlConnection cnn;
            MySqlCommand command;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;

            DataTable dt = new DataTable();

            string sql = "";

            if (documentid==0)
                sql = "select * from documentconfig";
            else
                sql = "select * from documentconfig where documentID=" + documentid;

            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                dt.Load(command.ExecuteReader());
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);

                sqlcnn.Open();
                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd);
                sqladapter.Fill(dt);
                sqlcnn.Close();
            }

            return dt;
        }

        public static Boolean deleteDocument(string documentid)
        {
            DocumentModel docModel = new DocumentModel();
            MySqlConnection cnn;
            MySqlCommand command;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;

            DataTable dt = new DataTable();

            string sql = "";

            sql = "delete from documentconfig where documentID=" + documentid;
            //string connetionString = @"Data Source=localhost;Initial Catalog=IFCANET_Standard32;User ID=sa;Password=sql123!@#";
            //string connetionString = "Data Source=127.0.0.1;Initial Catalog=cmslcly_mysql;User Id=root;Password=JustDoIt!123";
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            try
            {
                if (isMySQL)
                {
                    cnn = new MySqlConnection(connetionString);
                    command = new MySqlCommand(sql, cnn);
                    cnn.Open();
                    int ret = command.ExecuteNonQuery();
                    cnn.Close();
                }
                else
                {
                    sqlcnn = new SqlConnection(connetionString);
                    sqlcmd = new SqlCommand(sql, sqlcnn);
                    sqlcnn.Open();
                    sqlcmd.ExecuteNonQuery();
                    sqlcnn.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true; ;
        }

        public static List<SelectListItem> GetDocumentTypeList()
        {
            MySqlConnection cnn;
            MySqlCommand command;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;

            string sql = "";

            sql = "select enumvalue, enumname from enummaster where enumtype='DocumentType' and status=1";

            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Please Select",
                Value = ""
            });
            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = reader.GetString(0),
                            Value = reader.GetString(1)
                        });
                    }
                }
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);

                sqlcnn.Open();
                using (var reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = reader.GetString(0),
                            Value = reader.GetString(1)
                        });
                    }
                }
                sqlcnn.Close();
            }
            return items;
        }

        public static void AddDocumentTemplate(DocumentModel documentmodel)
        {
            MySqlConnection cnn;
            MySqlCommand command;
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;

            DataTable dt = new DataTable();
            string sql = "";
            string documentname = "";
            string fileextension = Path.GetExtension(documentmodel.DocumentFile.FileName);

            documentname = documentmodel.DocumentName + fileextension;
            sql = string.Format("insert documentconfig (documentType, documentPath,documentName, dataSource, primary_key) values('{0}', 'DocumentTemplate', '{1}', '{2}', '{3}');", documentmodel.DocumentType, documentname, documentmodel.dataSource, documentmodel.primary_key);
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            bool isMySQL = true;
            if (System.Configuration.ConfigurationManager.AppSettings["isMySQL"] == "true")
                isMySQL = true;

            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/DocumentTemplate"),
                                       documentname);

            documentmodel.DocumentFile.SaveAs(path);
            if (isMySQL)
            {
                cnn = new MySqlConnection(connetionString);
                command = new MySqlCommand(sql, cnn);
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            else
            {
                sqlcnn = new SqlConnection(connetionString);
                sqlcmd = new SqlCommand(sql, sqlcnn);
                sqlcnn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcnn.Close();
            }

        }
    }
    public class exportmodel
    {
        public int SelectValue { get; set; }
        public DataTable SelectList { get; set; }

        public DocumentModel doc { get; set; }
    }
}