using System.Collections.Generic;
using Newtonsoft.Json;

namespace TotalVoice
{
    public class Parameters : IParameters
    {
        private readonly Dictionary<string, dynamic> Items;

        public Parameters()
        {
            Items = new Dictionary<string, dynamic>();
        }

        public void Add(string Key, dynamic Value)
        {
            Items.Add(Key, Value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Items);
        }
    }
}
