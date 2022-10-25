using Newtonsoft.Json;

namespace LanguageDict.Models
{
    public class DictData
    {
        [JsonProperty("word")]
        public string Word { get; set; }

    }
}
