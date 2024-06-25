
using System;
using System.Xml.Linq;

namespace BackFacture
{
    public static class Config
    {
        public static string Enviroment { get; set; }
        public static string User { get; set; }
        public static bool Verbose { get; set; }
        public static string Dbpath { get; set; }
        public static string Pathlog { get; set; }

        public static void Init()
        {
            XElement config = XElement.Load("configuration.xml");
            Dbpath = config.Element("dbpath").Value;
            Pathlog = config.Element("pathlog").Value;
            Enviroment = config.Element("enviroment").Value;
            Verbose = config.Element("verbose").Value == "true";
        }
    }
}
