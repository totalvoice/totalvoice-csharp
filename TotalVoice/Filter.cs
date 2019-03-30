using System.Collections.Generic;
using System.Linq;

namespace TotalVoice
{
    public class Filter
    {
        private Dictionary<string, dynamic> _filters;

        public Filter()
        {
            _filters = new Dictionary<string, dynamic>();
        }

        public void Add(string Key, dynamic Value)
        {
            _filters.Add(Key, Value);
        }

        public bool IsEmpty()
        {
            return _filters.Count() == 0;
        }
        
        public void Merge(ref QueryString Query)
        {
            foreach (KeyValuePair<string, dynamic> entry in _filters)
            {
                Query.Add(entry.Key, entry.Value);
            }
        }
    }
}
