using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IPlugin;
using WebServer;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Data;
using System.Xml.Serialization;
using System.Net;


namespace backofficePlugin
{
    public class backofficePlugin : IPlugin
    {
        private string pName = "backofficePlugin";
        //DAL myDAL;
        BL myBL;
        public string PName
        {
            get
            {
                return pName;
            }
        }
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
            try
            {

                //myDAL = new DAL();
                myBL = new BL();
                String[] temppath = request.Url.Path.ToString().Split("/".ToCharArray()); // url parsen

                Console.WriteLine(temppath[2]);
                if (temppath[2].StartsWith("select"))
                {
                    String[] switcher = temppath[0].Split("?".ToCharArray());
                    

                    string xmlData = "xmlData init";


                    List<EntityInterface> liste = new List<EntityInterface>();
                    int useFake = 0;
                    if (request.Url.Parameter.ContainsKey("useFake")) { useFake = Convert.ToInt32(request.Url.Parameter["useFake"]); }

                    liste = myBL.check(request.Url.Parameter["search"], request.Url.Parameter["from"], useFake);

                    StringWriter sw = new StringWriter();

                    //kundenliste.WriteXml(sw);
                    XmlSerializer myserializer = new XmlSerializer(typeof(List<EntityInterface>));
                    xmlData = myserializer.ToString();

                    
                    var stringwriter = new System.IO.StringWriter();
                    //var serializer = new XmlSerializer(this.GetType());
                    myserializer.Serialize(stringwriter, liste);
                    Console.WriteLine(stringwriter.ToString());

                    byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(stringwriter.ToString());
                    long count = requestBytes.Length;
                    Response resp = new Response(request, request._socket);
                    resp.sendResponse(request.HttpVersion, getMIMEType(request.Url.Extension), (int)count, " 200 OK", requestBytes);

                }
                else if (temppath[2].StartsWith("edit"))
                {


                    List<EntityInterface> liste = new List<EntityInterface>();

                    //StreamReader reader = new StreamReader(request.Header["xml"]);
                    //reader.ReadToEnd();

                    XmlReader reader = XmlReader.Create(new StringReader(request.Header["xml"]));
                    liste = (List<EntityInterface>)new XmlSerializer(typeof(List<EntityInterface>)).Deserialize(reader);
                    reader.Close();

                    
                    string response = myBL.update(liste, request.Url.Parameter["from"]);
                                                         // was ASCII
                    byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(response.ToString());
                    long count = requestBytes.Length;
                    Response resp = new Response(request, request._socket);
                    resp.sendResponse(request.HttpVersion, getMIMEType(request.Url.Extension), (int)count, " 200 OK", requestBytes);

                }
                else if (temppath[2].StartsWith("add"))
                {
                    List<EntityInterface> liste = new List<EntityInterface>();

                    //StreamReader reader = new StreamReader(request.Header["xml"]);
                    //reader.ReadToEnd();
                    XmlReader reader = XmlReader.Create(new StringReader(request.Header["xml"]));
                    liste = (List<EntityInterface>)new XmlSerializer(typeof(List<EntityInterface>)).Deserialize(reader);
                    reader.Close();

                    ////Console.WriteLine("switcher[1]:" + switcher[1]);
                    //Console.WriteLine("temü[2]:" + temppath);
                    string response = myBL.add(liste, request.Url.Parameter["from"]);
                                                            //was ASCII
                    byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(response.ToString());
                    long count = requestBytes.Length;
                    Response resp = new Response(request, request._socket);
                    resp.sendResponse(request.HttpVersion, getMIMEType(request.Url.Extension), (int)count, " 200 OK", requestBytes);
                }

                else if (temppath[2].StartsWith("delete"))
                {
                    List<EntityInterface> liste = new List<EntityInterface>();

                    //StreamReader reader = new StreamReader(request.Header["xml"]);
                    //reader.ReadToEnd();
                    XmlReader reader = XmlReader.Create(new StringReader(request.Header["xml"]));
                    liste = (List<EntityInterface>)new XmlSerializer(typeof(List<EntityInterface>)).Deserialize(reader);
                    reader.Close();

                    ////Console.WriteLine("switcher[1]:" + switcher[1]);
                    //Console.WriteLine("temü[2]:" + temppath);
                    string response = myBL.delete(liste, request.Url.Parameter["from"]);
                    //was ASCII
                    byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(response.ToString());
                    long count = requestBytes.Length;
                    Response resp = new Response(request, request._socket);
                    resp.sendResponse(request.HttpVersion, getMIMEType(request.Url.Extension), (int)count, " 200 OK", requestBytes);
                }
                //return "ERROR parse " + temppath.Length.ToString() + " " + temppath[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return "ERROR exception";
            }

        }



    }
}
