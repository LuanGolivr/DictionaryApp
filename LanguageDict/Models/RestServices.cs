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
            if(dictData != null)
            {
                dictData = dictDataList[0];
            }
            
            
            return dictData;
        }
    }

    public class RestServicesRandom
    {
        HttpClient _client;

        public RestServicesRandom()
        {
            _client = new HttpClient();
        }

        public async Task<string> getRandomWordData(string query)
        {
            string randomWord = null;
            List<string> listRandomWord = null;

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    listRandomWord = JsonConvert.DeserializeObject<List<string>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            randomWord = listRandomWord[0];
            return randomWord;
        }
    }
}
