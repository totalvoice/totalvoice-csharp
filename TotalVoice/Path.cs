using System;
using System.Collections.Generic;

namespace TotalVoice
{
    public class Path
    {
        private readonly List<object> Paths;

        public Path()
        {
            Paths = new List<object>();
        }

        public void Add(object Value)
        {
            Paths.Add(Value);
        }

        public string GetPathString()
        {
            string spath = "";
            for (int i = 0; i < Paths.Count; i++)
            {
                spath = spath + "/" + Paths[i];
            }
            return spath;
        }
    }
}
