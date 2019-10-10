using System;
using System.Xml;
using System.Xml.Schema;

namespace git_lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string XSDPATH = @"C:\Users\Eugene\Desktop\KPO\lab5\git_lab5\tariffs.xsd";
            string XMLPATH = @"C:\Users\Eugene\Desktop\KPO\lab5\git_lab5\tariffs.xml"; 
            XMLParser xmlParser = new XMLParser(XSDPATH, XMLPATH);
            xmlParser.Check_XML();
            
        }
    }
}
