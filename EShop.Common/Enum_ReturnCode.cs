using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Common
{
    public enum Enum_ReturnCode
    {
        Success = 1,
        Fail = -4,
        DataInValid = -1,
        DuplicateData = -3,
        DataIsNull = -2,
        Exception = -99
    }
}
