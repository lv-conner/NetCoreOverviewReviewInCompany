using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreOverview.Services
{
    public interface IWebSocketEncoding
    {
        byte[] Encode(string msg);
        string Decode(byte[] byteMsg);
    }
}