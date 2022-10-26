using System.Diagnostics;
using Newtonsoft.Json;

namespace LanguageDict.Models
{
    public class RestServicesDict
    {
        HttpClient _client;

        public RestServicesDict()
        {
            _client = new HttpClient();
        }

        public async Task<Root> GetDictData(string query)
        {
            Root dictData = null;
            List<Root> dictDataList = null;

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dictDataList = JsonConvert.DeserializeObject<List<Root>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            dictData = dictDataList[0];
            
            return dictData;
        }
    }
}
