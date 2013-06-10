using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace backoffice
{
    public class ProxyLayer
    {
        
        public List<EntityInterface> request(string para, string from)
        {
            List<EntityInterface> kundenliste = new List<EntityInterface>();
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("http://localhost:8080/EPU_Plugin/select.html?search=" + para + "&from=" + from); //+ "&useFake=1"
            // If required by the server, set the credentials.                      
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.UTF8);
            
            kundenliste = (List<EntityInterface>)new XmlSerializer(typeof(List<EntityInterface>)).Deserialize(reader);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return kundenliste;
        }

        public void edit(List<EntityInterface> liste, string from)
        {
            string xmlData = "xmlData init";
            XmlSerializer myserializer = new XmlSerializer(typeof(List<EntityInterface>));
            xmlData = myserializer.ToString();

            var stringwriter = new System.IO.StringWriter();
            string url = "http://localhost:8080/EPU_Plugin/edit.html?from=" + from;
            myserializer.Serialize(stringwriter, liste);

            string Xml = stringwriter.ToString();
            
            WebRequest request = WebRequest.Create(url);
            byte[] requestBytes = Encoding.UTF8.GetBytes("&xml=" + Xml);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-16";
            request.ContentLength = requestBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            

            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
            string backstr = sr.ReadToEnd();


            sr.Close();
            res.Close();
            MessageBox.Show(backstr);


        }

        public void add(List<EntityInterface> kundenliste, string from)
        {
            string xmlData = "xmlData init";
            XmlSerializer myserializer = new XmlSerializer(typeof(List<EntityInterface>));
            xmlData = myserializer.ToString();

            var stringwriter = new System.IO.StringWriter();

            myserializer.Serialize(stringwriter, kundenliste);

            string Xml = stringwriter.ToString();

            string url = "http://localhost:8080/EPU_Plugin/add.html?from=" + from;

            WebRequest request = WebRequest.Create(url);
            byte[] requestBytes = Encoding.UTF8.GetBytes("&xml=" + Xml);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-16";
            request.ContentLength = requestBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();



            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
            string backstr = sr.ReadToEnd();


            sr.Close();
            res.Close();
            MessageBox.Show(backstr);

        }

        public void delete(List<EntityInterface> entitylist, string from)
        {
            string xmlData = "xmlData init";
            XmlSerializer myserializer = new XmlSerializer(typeof(List<EntityInterface>));
            xmlData = myserializer.ToString();

            var stringwriter = new System.IO.StringWriter();

            myserializer.Serialize(stringwriter, entitylist);

            string Xml = stringwriter.ToString();

            string url = "http://localhost:8080/EPU_Plugin/delete.html?from=" + from;

            WebRequest request = WebRequest.Create(url);
            byte[] requestBytes = Encoding.UTF8.GetBytes("&xml=" + Xml);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-16";
            request.ContentLength = requestBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();



            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
            string backstr = sr.ReadToEnd();


            sr.Close();
            res.Close();
            MessageBox.Show(backstr);

        }


    }
}
