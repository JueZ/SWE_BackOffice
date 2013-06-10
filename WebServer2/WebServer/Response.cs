using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WebServer
{
    public class Response
    {
        private Socket s;
        private byte[] header;
        private byte[] responseBody;

        public Response(Request Requ, Socket sock)
        {
            
            this.s = sock;
            responseBody = null;

        }

        

        private void SendToBrowser(string Data) //overload for strings
        {
            SendToBrowser(Encoding.ASCII.GetBytes(Data));
        }

        private void SendToBrowser(Byte[] bSendData)
        {
            
            NetworkStream stream = new NetworkStream(s);
            try
            {
                if (s.Connected)
                {
                    stream.Write(bSendData, 0, bSendData.Length);
                    
                    Console.WriteLine("No. of bytes sent {0}", bSendData.Length);
                    
                }
                else
                    Console.WriteLine("Connection Dropped....");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred : {0} ", e);
            }
        }

        public void CreateHeader(string HttpVersion, string MIMEHeader,
            int TotBytes, string StatusCode)
        {
            String sBuffer = "";

            // if Mime type is not provided set default to text/html
            if (MIMEHeader.Length == 0)
            {
                MIMEHeader = "text/html";  // Default Mime Type is text/html
            }

            sBuffer = sBuffer + HttpVersion + StatusCode + "\r\n";
            sBuffer = sBuffer + "connection: close\r\n";

            sBuffer = sBuffer + "Content-Type: " + MIMEHeader + "\r\n";

            sBuffer = sBuffer + "Content-Length: " + TotBytes + "\r\n\r\n";

            header = Encoding.ASCII.GetBytes(sBuffer);
        }

       
        public int sendResponse(string HttpVersion,string MIMEHeader, int TotBytes, string StatusCode, byte []Data)
        {


            CreateHeader(HttpVersion, MIMEHeader, TotBytes, StatusCode);
            SendToBrowser(header);
            SendToBrowser(Data);
            /*
                
            */
            return 0;
        }
    }
}
