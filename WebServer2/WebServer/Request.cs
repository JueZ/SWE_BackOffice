using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Web;

namespace WebServer
{
    public class Request
    {
        public Socket _socket { get; private set; }

        public string Method { get; private set; }
        public Url Url { get; private set; }
        public Dictionary<string, string> Header { get; private set; }
        public string HttpVersion { get; private set; }

        public Request(Socket s)
        {
            _socket = s;
            Header = new Dictionary<string, string>();
        }


        public bool Parse()
        {
            NetworkStream stream = new NetworkStream(_socket);
            StreamReader sr = new StreamReader(stream);

            parseHeader(sr);

            return IsValid;

        }

        private void parsePost(StreamReader stream, string line)
        {

            int postLength = Convert.ToInt32(Header["Content-Length"]); //Auslesen, wie groß die Post message ist
            char[] buffer = new char[postLength];
            stream.Read(buffer, 0, postLength);//soviel byte wie im header angegeben lesen. 
            line = new string(buffer);
            line = HttpUtility.UrlDecode(line); //Urlencodete Zeichen wie + statt ' ' decodieren

            var temp = line.Split(new[] { '&' });

            foreach (var i in temp)
            {
                var paramStr = i.Split(new[] { '=' }, 2);

                if (paramStr.Length == 2)
                    Header[paramStr[0]] = paramStr[1];
                else if (paramStr.Length == 1)
                    Header[paramStr[0]] = "";

            }

            Console.WriteLine(line);

        }

        private bool parseHeader(StreamReader sr)
        {

            string line = sr.ReadLine();
            Console.WriteLine(line);

            if (!string.IsNullOrEmpty(line)) //Methode und URL des Request auslesen. GET oder POST
            {
                var buffer = line.Split(' '); //nach leerzeichen trennen

                if (buffer.Length == 3)
                {
                    Method = buffer[0];
                    Url = new Url(buffer[1]);
                    HttpVersion = buffer[2];
                }
            }
            else
            {
                return false;
            }

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                if (string.IsNullOrEmpty(line)) //lesen bis headerende
                    break;

                var buffer = line.Split(new[] { ':' }, 2); //key/wert paare in header dictionary eintragen

                if (buffer.Length == 2)
                {
                    Header[buffer[0]] = buffer[1];
                }
                else
                {
                    return false;
                }

                Console.WriteLine(line);
            }

            if (Method == "POST") //wenn methode == post dann nach header weiterlesen
            {
                parsePost(sr, line);
                return IsValid;
            }


            return IsValid;
        }

        private bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Method);
            }
        }

    }
}
