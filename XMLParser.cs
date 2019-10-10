using System;
using System.Xml;
using System.Xml.Schema;

namespace git_lab5{
    public class XMLParser {
        private bool XSDValidation;
        private string xsdPath;
        private string xmlPath;
        public XMLParser(string xsdP, string xmlP)
        {
            xsdPath = xsdP;
            xmlPath = xmlP;
        }
        private void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }

            XSDValidation = false;
        }

        public bool Check_XML()
        {
            XSDValidation = true;
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.Schemas.Add("http://www.example.com/students", xsdPath);
            xmlSettings.ValidationType = ValidationType.Schema;
            xmlSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader tarr = XmlReader.Create(xmlPath, xmlSettings);
            try {
                while (tarr.Read())
                {   }
            } catch (Exception) 
            {
                XSDValidation = false;
            }
            return XSDValidation;
        }

        public bool get_XSDValidation()
        {
            return XSDValidation;
        }
 
    }
}