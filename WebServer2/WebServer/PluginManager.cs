using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;


namespace WebServer
{

    /// <summary>
    /// Plugin-Manager Klasse. Teilweise übernommen aus dem Beispielcode im CIS.
    /// Wird als Singleton implementiert (es gibt nur eine Instanz). Lädt Plugins aus einem
    /// angegebenen Verzeichnis, indem es DLLs in dem Verzeichnis nach Klassen durchsucht,
    /// die das IPlugin Interface implementieren und instanziert diese.
    /// </summary>
    public class PluginManager
    {
        private List<IPlugin> plugins = new List<IPlugin>();
        private static volatile PluginManager Instance;
        private readonly string configFile = "config.xml";

        private PluginManager() { }

        public static PluginManager getInstance()
        {
            if (Instance == null)
            {
                Instance = new PluginManager();
              
            }

            return Instance;
        }

        /// <summary>
        /// Erstellt ein Xml Configfile indem alle .dll im Pluginordner nach Klassen, die das
        /// IPlugin Interface implementieren untersucht werden. Gefundene klassen werden
        /// als Childnode der AssemblyNode mit ihrem Namen gespeichert und das attribut
        /// active defaultmässig auf false gesetzt.
        /// </summary>
        /// <param name="configFilePath">Pfad zum Configfile</param>
        /// <param name="config"></param>
        private void CreateConfig(string configFilePath, XmlDocument config)
        {
            XmlNode root = config.CreateElement("config");
            config.AppendChild(root);

            string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            directory = Path.Combine(directory, "Plugins");

            try
            {
                foreach (string dateiname in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                {
                    if (dateiname != null)
                    {
                        Assembly asm = Assembly.LoadFile(dateiname);
                        XmlElement asmXml = config.CreateElement("assembly"); //neue xmlnode von typ assembly erstellen
                        asmXml.SetAttribute("name", Path.GetFileName(dateiname) ); //name als attribut der xmlnode
                        root.AppendChild(asmXml); //dem rootelement hinzufügen

                        foreach (Type asmtyp in asm.GetTypes()) //alle typen der assembly durchgehen
                        {
                            if (asmtyp.GetInterface("IPlugin") != null) //wenn IPlugin interface vorhanden
                            {
                                XmlElement plugin = config.CreateElement("plugin"); //Plugin xmlnode als child der assembly anhängen
                                plugin.SetAttribute("active", "false");
                                plugin.InnerText = asmtyp.FullName;
                                asmXml.AppendChild(plugin);
                            }

                        }
                    }
                }
                config.Save(configFilePath);
            }

            catch (DirectoryNotFoundException) { ExceptionHandler.ErrorMsg(1); }
            catch (FileNotFoundException) { ExceptionHandler.ErrorMsg(2); }
        }


        

        public void LoadPlugins()
        {
            
            string configFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            configFilePath = Path.Combine(configFilePath, configFile); //Pfad des config files zusammensetzen
            
            FileInfo fi = new FileInfo(configFilePath);
            XmlDocument xmlDoc = new XmlDocument();

            if(fi.Exists)
            {
                xmlDoc.Load(fi.FullName);
                
            }
            else //wenn xml config file nicht vorhanden, alle vorhandenen Plugins auslesen und in das config-file schreiben
            {
                CreateConfig(configFilePath, xmlDoc);
            }
            try
            {


                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes) //Die xml-nodes mit <assembly> durchgehen
                {
                    string assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    assemblyPath = Path.Combine(assemblyPath, "Plugins", node.Attributes["name"].InnerText); //assemblypfad zusammensetzen. Sollten im Plugins Ordner liegen
                    
                    Assembly asm = Assembly.LoadFile(assemblyPath); //Assembly mittels Reflection laden
                    
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        //string namSpace = child.Attributes["namespace"].InnerText; //namespace wird bei GetType gebraucht
                        Type asmtyp = asm.GetType(child.InnerText);
                        
                        if (asmtyp.GetInterface("IPlugin") != null 
                            && child.Attributes["active"].InnerText == "true") //wenn das Interface implementiert ist, Klasse instanzieren
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(asmtyp);
                            plugins.Add(plugin); //zur pluginliste hinzufügen
                        }
                    }
                    

                } //ende foreach
                
            }//ende try

            catch (DirectoryNotFoundException) { ExceptionHandler.ErrorMsg(1); }
            catch (FileNotFoundException) { ExceptionHandler.ErrorMsg(2); }
        }

        public List<IPlugin> PluginList
        {
            get
            {
                return plugins;
            }
        }
    }
}
