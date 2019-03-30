using System.Collections.Generic;
using System.Linq;

namespace TotalVoice
{
    public class Filter
    {
        private Dictionary<string, dynamic> filters;

        public Filter()
        {
            filters = new Dictionary<string, dynamic>();
        }

        public void Add(string Key, dynamic Value)
        {
            filters.Add(Key, Value);
        }

        public bool IsEmpty()
        {
            return filters.Count() == 0;
        }
        
        public void Merge(ref QueryString Query)
        {
            foreach (KeyValuePair<string, dynamic> entry in filters)
            {
                Query.Add(entry.Key, entry.Value);
            }
        }
    }
}
