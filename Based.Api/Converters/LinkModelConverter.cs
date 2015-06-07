using System;
using Based.Api.Models;
using Newtonsoft.Json;

namespace Based.Api.Converters
{
    public class LinkModelConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var model = value as LinkModel;

            if (model != null)
            {
                if (string.IsNullOrWhiteSpace(model.Href))
                {
                    return;
                }
                
                writer.WriteStartObject();

                writer.WritePropertyName("href");
                writer.WriteValue(model.Href);

                writer.WritePropertyName("rel");
                writer.WriteValue(model.Rel);

                if (!model.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    writer.WritePropertyName("method");
                    writer.WriteValue(model.Method);
                }
                
                writer.WriteEndObject();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (LinkModel);
        }
    }
}