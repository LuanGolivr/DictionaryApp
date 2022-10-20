using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LanguageDict.Models
{
    internal class Main
    {
        public ObservableCollection<Dict> AllDictionaries { get; set; } = new ObservableCollection<Dict>();
        public DataBs serverConnection { get; set; }

        public Main()
        {
            makeConnectionServer();
            AllDictionaries.Clear();
        }

        private void makeConnectionServer()
        {
            serverConnection = new DataBs();
        }

        public bool checkStatus()
        {
            bool answer = serverConnection.clientStatus;
            return answer;
        }
    }
}
