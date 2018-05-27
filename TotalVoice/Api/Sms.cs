using System;
using System.Collections.Generic;
using System.Text;

namespace TotalVoice.Api
{
    public class Sms
    {
        readonly TotalVoice Client;

        public Sms(TotalVoice Client)
        {
            this.Client = Client;
        }
    }
}
