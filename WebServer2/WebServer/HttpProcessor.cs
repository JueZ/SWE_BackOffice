using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace WebServer
{
    class HttpProcessor
    {
        private Socket s;
        
        public HttpProcessor(Socket s)
        {
            this.s = s;
        }

        public void processHttp()
        {
            var request = new Request(s);

            if (request.Parse())
            {

                HandleRequest(request);
            
            }

            s.Close();
        }

        public void HandleRequest(Request requ) 
        {
            
            
                foreach (IPlugin plugin in PluginManager.getInstance().PluginList)
                {
                    if (plugin.CanHandle(requ))
                    {
                        plugin.ProcessRequest(requ);
                        break;
                    }
                }
            


        }

    }
}
