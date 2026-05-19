using System.Text.Json;
using System.Text.Json.Serialization;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Mappers
{
    public static class LogJsonSerializer
    {
        private static readonly JsonSerializerOptions Options = CreateOptions();

        private static JsonSerializerOptions CreateOptions()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }

        public static string Serialize(object value)
        {
            if (value == null)
                return "null";

            return JsonSerializer.Serialize(value, Options);
        }
    }
}
