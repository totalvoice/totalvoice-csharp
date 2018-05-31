using System;
using System.Collections.Generic;
using System.Text;

namespace TotalVoice
{
    public interface IParameters
    {
        void Add(string Key, dynamic Value);

        string Serialize();
    }
}
