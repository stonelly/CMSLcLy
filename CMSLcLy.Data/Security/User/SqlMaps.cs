using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    class SqlMaps
    {
        internal static string List(List<Guid> entities)
        {
            var entitiesSql = MAT.Helper.SQLBuilder.JoinParameter(entities.ToArray());

            return @"
SELECT u.UserId, u.Username, u.UserStatus, u.DisplayName, eeh.BelongsToEId,
en.Name AS Department, r.RoleId, r.Name AS UserRole
FROM [User] u
INNER JOIN EmployeeLogin el ON el.[UserId] = u.UserId
INNER JOIN Employee e ON e.EmployeeId = el.EmployeeId
INNER JOIN Person p ON p.PersonId = e.PersonId
INNER JOIN UserRole ur ON ur.UserId = u.UserId
INNER JOIN Role r ON r.RoleId = ur.RoleId
LEFT JOIN EmployeeEmploymentHistory eeh ON eeh.EmployeeId = e.EmployeeId
AND CAST(getdate() AS date) BETWEEN eeh.EffectiveDate AND ISNULL(eeh.EndDate, getdate())
LEFT JOIN Entity en ON en.EntityId = eeh.BelongsToEId
WHERE eeh.BelongsToEId IS NULL OR eeh.BelongsToEId IN (" + entitiesSql + @")
ORDER BY u.Username
";
        }
        internal static string Get()
        {
            return @"
SELECT u.UserId, u.Username, u.UserStatus, u.AuthenticationType, u.DisplayName, u.FirstName, u.LastName, 
p.Email, p.MobilePhone, e.EmployeeId, e.EmployeeNo, e.JoinedDate, e.ResignationDate, ur.RoleId, p.ProfileImagePath,
eeh.BelongsToEId, eeh.SupervisorEmpId, eeh.CostCenterCId
FROM [User] u
INNER JOIN EmployeeLogin el ON el.[UserId] = u.UserId
INNER JOIN Employee e ON e.EmployeeId = el.EmployeeId
INNER JOIN Person p ON p.PersonId = e.PersonId
INNER JOIN UserRole ur ON ur.UserId = u.UserId
LEFT JOIN EmployeeEmploymentHistory eeh ON eeh.EmployeeId = e.EmployeeId
AND CAST(getdate() AS date) BETWEEN eeh.EffectiveDate AND ISNULL(eeh.EndDate, getdate())
WHERE u.UserId = @UserId
ORDER BY u.Username
";
        }
    }
}
