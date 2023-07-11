using System;
using System.Collections.Generic;
using System.Linq;

namespace ETFHelper_WPF.Helpers;

public static  class EnumHelper
{
    #region მეთოდები

    public static IEnumerable<TEnum> GetEnumValues<TEnum>()
    {
        if (typeof(TEnum).IsEnum)
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>(); 
        }

        return Enumerable.Empty<TEnum>();   
    }


    #endregion
}
