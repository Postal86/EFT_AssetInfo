using ETFHelper_WPF.Enums;

namespace ETFHelper_WPF.Extensions;

public static class TarkovToolsRequestTypesExtension
{
    #region მეთოდები

    public static  string AssociatedFilterName(this TarkovToolsRequestTypes type)
    {
        return type switch
        {
            TarkovToolsRequestTypes.ItemsByName => "name", 
            TarkovToolsRequestTypes.ItemsByType => "type",
            TarkovToolsRequestTypes.Item => "id",
            _ => string.Empty,
        };
    }

    #endregion
}
