using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer;
using System.IO;

namespace HttpPlugin
{
    public class Class1 : IPlugin
    {


        private string getMIMEType(string ext) //looks the mime type of the extension up in the registry
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            var regValue = key.GetValue("Content Type");
            string contentType;

            if (regValue != null)
                contentType = key.GetValue("Content Type").ToString();
            else
                contentType = "text/html";
            return contentType;

        }
        
        public bool CanHandle(Request request)
        {
            if (request.Url.Extension != "")
                return true;
            else
                return false;
        }

        public void ProcessRequest(Request request)
        {
            string workDir = Directory.GetCurrentDirectory();//aktuelles verzeichnis bestimmen
            byte[] responseBody;


            if (request.Url.Path == "/")
                workDir = Path.Combine(workDir, "index.html");
            else
                workDir = workDir + request.Url.Path;//vollen Pfad zur angeforderten Datei zusammensetzen. Annahme, dass 
            //Datei im selben Verzeichnis wie die Exec liegt.
            Response resp = new Response(request, request._socket);
            if (File.Exists(workDir)) //prüfen ob datei existiert bzw. im angegebenen pfad ist
            {
                using (var fs = File.OpenRead(workDir))
                {
                    long count = fs.Length;

                    responseBody = new byte[count];

                    fs.Read(responseBody, 0, (int)count);
                    

                    resp.sendResponse(request.HttpVersion, getMIMEType(request.Url.Extension), (int)count, " 200 OK", responseBody);
                    
                }
            }
            else //wenn nicht, error message an den browser senden
            {
                string errorMessage = "<h2> Error: File not found! </h2>";
                resp.sendResponse(request.HttpVersion, "", errorMessage.Length, " 404 NOT FOUND", Encoding.ASCII.GetBytes(errorMessage));
                
            }

        }
    }
}
