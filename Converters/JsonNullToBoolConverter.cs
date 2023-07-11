using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ETFHelper_WPF.Converters;

 class JsonNullToBoolConverter : JsonConverter<int>
{
    #region მეთოდები

    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
       try
        {
            return reader.TryGetInt32(out var value) ? value : 0;
        }
        catch {
            return default;
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }

    #endregion
}
