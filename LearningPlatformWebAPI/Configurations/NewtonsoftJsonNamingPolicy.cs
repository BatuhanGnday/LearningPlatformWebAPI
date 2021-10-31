using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LearningPlatformWebAPI.Configurations
{
    public class NewtonsoftJsonNamingPolicy : JsonNamingPolicy
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public NewtonsoftJsonNamingPolicy(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public override string ConvertName(string name)
        {
            var contractResolver = _jsonSerializerSettings.ContractResolver;
            return (contractResolver as DefaultContractResolver)?.GetResolvedPropertyName(name) ?? name;
        }
    }
}