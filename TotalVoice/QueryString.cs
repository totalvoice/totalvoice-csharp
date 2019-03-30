using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalVoice
{
    public class QueryString
    {
        private Dictionary<string, dynamic> _query;

        public QueryString()
        {
            _query = new Dictionary<string, dynamic>();
        }

        public void Add(string Key, dynamic Value)
        {
            _query.Add(Key, Value);
        }

        public bool IsEmpty()
        {
            return _query.Count() == 0;
        }

        public string Build()
        {
            return "?" + HttpUtility.UrlEncode(string.Join("&", _query.Select(Item => string.Format("{0}={1}", Item.Key, Item.Value))));
        }
    }
}
