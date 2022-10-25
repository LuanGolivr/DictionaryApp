using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDict.Models
{
    public class RestServicesDict
    {
        HttpClient _client;

        public RestServicesDict()
        {
            _client = new HttpClient();
        }

        public async Task<DictData> GetDictData(string query)
        {
            DictData dictData = null;

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dictData.JsonConvert.DeserializeObject<DictData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return dictData;
        }
    }
}
