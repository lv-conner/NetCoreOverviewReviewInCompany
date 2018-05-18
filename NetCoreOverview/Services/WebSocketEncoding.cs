using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreOverview.Services
{
    public class WebSocketEncoding : IWebSocketEncoding
    {
        private readonly Encoding encoding;
        public WebSocketEncoding()
        {
            encoding = Encoding.UTF8;
        }
        public string Decode(byte[] byteMsg)
        {
            return encoding.GetString(byteMsg);
        }

        public byte[] Encode(string msg)
        {
            return encoding.GetBytes(msg);
        }
    }
}
