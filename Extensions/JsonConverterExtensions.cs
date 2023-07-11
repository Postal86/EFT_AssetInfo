using System.Collections.Generic;
using System.Text.Json.Serialization;
using ETFHelper_WPF.Converters;

namespace ETFHelper_WPF.Extensions;

public static class JsonConverterExtensions
{
    #region  მეთოდები

    public static void AddCustomConverter(this IList<JsonConverter> jsonConverter)
    {
        jsonConverter.Add(new JsonNullToIntConverter());
        jsonConverter.Add(new JsonNullToBoolConverter());
    }

    #endregion
}
