using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Common.Enums
{
    /// <summary>
    /// Access Type to determine what a user can do for a particular function
    /// </summary>
    [Serializable]
    [Flags]
    public enum AccessTypes
    {
        None = 0,
        Read = 1,
        Create = 2,
        Update = 4,
        Delete = 8,
        Full = Read | Create | Update | Delete
    }
}
