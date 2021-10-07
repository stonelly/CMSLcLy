using CMSLcLy.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Common
{
    public static class AccessTypesExtension
    {
        public static bool CanCreate(this AccessTypes access) => (access & AccessTypes.Create) == AccessTypes.Create;

        public static bool CanDelete(this AccessTypes access) => (access & AccessTypes.Delete) == AccessTypes.Delete;

        public static bool CanUpdate(this AccessTypes access) => (access & AccessTypes.Update) == AccessTypes.Update;

        public static bool CanRead(this AccessTypes access) => (access & AccessTypes.Read) == AccessTypes.Read;
    }
}
