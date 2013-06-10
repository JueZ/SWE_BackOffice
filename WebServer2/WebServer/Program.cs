using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using System.Threading;


namespace WebServer
{
    class Program
    {

        public static bool active { get; private set; } 
        static void Main(string[] args)
        {
            

            PluginManager manager = PluginManager.getInstance();
            manager.LoadPlugins();

            HttpProcessor processor;
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            active = true;
            listener.Start();


            while (active)
            {
                Socket s = listener.AcceptSocket(); // Blockiert bis Request von einem Client vorhanden ist.

                processor = new HttpProcessor(s);

                
                Thread t = new Thread(processor.processHttp); //bearbeiten des Request in neuem Thread
                t.Start();
               
                //processor.processHttp();
            }

            
        }

       
        static void client()
        {

            var s = new TcpClient();

            s.Connect("www.technikum-wien.at", 80);

            var stream = s.GetStream();

            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine("GET / HTTP/1.1");
            sw.WriteLine("host: www.technikum-wien.at");
            sw.WriteLine("connection: close");
            sw.WriteLine();
            sw.Flush();

            // Shift+Alt+F10

            StreamReader sr = new StreamReader(stream);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                Console.WriteLine(line);
            }

            Console.ReadKey();

        }
    }
}
