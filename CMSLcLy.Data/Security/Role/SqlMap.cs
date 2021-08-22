using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.Role
{
    static class SqlMap
    {
        internal static string ListRole(string name)
        {
            return @"
SELECT r.RoleId, r.Name
FROM [Role] r
WHERE r.SubscriptionId = @SubscriptionId
" + (!string.IsNullOrEmpty(name) ? "AND r.[Name] LIKE @Name" : "") + @"
ORDER BY r.Name
";
        }
 
        internal static string GetForAuditLog(string modulesStr)
        {
            return @"
SELECT r.Name, '" + modulesStr + @"' AS Modules
FROM [Role] r
WHERE r.RoleId = @AuditKey
";
        }

        internal static string SelectFullUserGroupFunctionList()
        {
            return @"
WITH FunctionHierarchy(FunctionId, ParentFunctionId, Name, OrderNo, FlagCRUD, [Last])
AS
(
	SELECT f.FunctionId, f.ParentFunctionId, f.Name, f.OrderNo, rf.FlagCRUD, 1
	FROM RoleFunction rf
	INNER JOIN [Function] f ON f.FunctionId = rf.FunctionId
	WHERE rf.RoleId = @roleId
	UNION ALL
	SELECT f.FunctionId, f.ParentFunctionId, f.Name, f.OrderNo, CAST(15 AS tinyint), 0 
	FROM [Function] f
    INNER JOIN FunctionHierarchy fh ON fh.ParentFunctionId = f.FunctionId
)
SELECT DISTINCT *
FROM FunctionHierarchy
";
        }
    }
}
