using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer
{
    public class Url
    {
        public Url()
        {
            Parameter = new Dictionary<string, string>();
        }

        public Url(string url)
            : this()
        {
            var buffer = url.Split(new[] { '?' }, 2);

            if (buffer.Length == 0)
                throw new ArgumentOutOfRangeException("url", "url is empty!");

            Path = buffer[0];

            if (buffer.Length > 1)
            {
                Query = buffer[1];
                var parameters = Query.Split('&');

                foreach (var p in parameters)
                {
                    var paramStr = p.Split('=');

                    if (paramStr.Length == 1)
                    {
                        Parameter[paramStr[0]] = "";
                    }
                    else if (paramStr.Length == 2)
                    {
                        Parameter[paramStr[0]] = paramStr[1];
                    }
                    else
                    {
                        // Fehler ^^
                    }
                }
            }
        }

        public string Path { get; private set; }

        public string Query { get; private set; }

        public Dictionary<string, string> Parameter { get; private set; }

        public string Extension
        {
            get
            {
                return System.IO.Path.GetExtension(Path).ToLower();
            }
        }
    }
}
