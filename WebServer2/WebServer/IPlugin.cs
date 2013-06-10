using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer
{
    public interface IPlugin
    {
        bool CanHandle(Request request);
        void ProcessRequest(Request request);
    }
}
