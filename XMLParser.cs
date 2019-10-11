using System;
using System.Collections.Generic;
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
                tarr.Close();
            } catch (Exception) 
            {
                XSDValidation = false;
                tarr.Close();
            }
            return XSDValidation;
        }

        public bool get_XSDValidation()
        {
            return XSDValidation;
        }

        public List<Tariff> buildTarrifList()
        {
            List<Tariff> tariffList = new List<Tariff>();

            Check_XML();
            if (XSDValidation == true) 
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(xmlPath);
                    XmlElement xRoot = xDoc.DocumentElement;
                    foreach (XmlNode xnode in xRoot)
                    {
                        tariffList.Add(buildTarrif(xnode));
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return tariffList;
        }

        private Tariff buildTarrif(XmlNode xmlNode)
        {
            Tariff tariff = new Tariff();
            if(xmlNode.Attributes.Count>0)
            {
                XmlNode attr = xmlNode.Attributes.GetNamedItem("name");
                if (attr!=null)
                {
                    tariff.setName(attr.Value);
                }
                attr = xmlNode.Attributes.GetNamedItem("operator_name");
                if (attr!=null)
                {
                    tariff.setOperatorName(attr.Value);
                }
                foreach (XmlNode childnode in xmlNode.ChildNodes)
                {
                    if(childnode.Name == "payroll")
                    {
                        tariff.setPayroll(Convert.ToDouble(childnode.InnerText));
                    }
                    if(childnode.Name == "call_prices")
                    {
                        tariff.setCallPrices(buildCallPrices(childnode));
                    }
                    if(childnode.Name == "sms_price")
                    {
                        tariff.setSmsPrice(Convert.ToDouble(childnode.InnerText));
                    }
                    if(childnode.Name == "parameters")
                    {
                        tariff.setParameters(buildParameters(childnode));
                    }
                }
            }
            return tariff;
        }
        private CallPrices buildCallPrices(XmlNode xmlN)
        {
            CallPrices callPrices = new CallPrices();
            foreach (XmlNode cnode in xmlN.ChildNodes)
            {
                if (cnode.Name == "inside_network")
                {
                    callPrices.setInsideNetwork(Convert.ToDouble(cnode.InnerText));
                }
                if (cnode.Name == "outside_network")
                {
                    callPrices.setOutsideNetwork(Convert.ToDouble(cnode.InnerText));
                }
                if (cnode.Name == "fixed_phone")
                {
                    callPrices.setFixed_Phone(Convert.ToDouble(cnode.InnerText));
                }
            }
            return callPrices;
        }
        private Parameters buildParameters (XmlNode xmlN)
        {
            Parameters parameters = new Parameters();
            foreach (XmlNode cnode in xmlN.ChildNodes)
            {
                if (cnode.Name == "favorite_number")
                {
                    parameters.setFavouriteNumber(Convert.ToInt64(cnode.InnerText));
                }
                if (cnode.Name == "tariffication")
                {
                    parameters.setTarifficaton(cnode.InnerText);
                }
                if (cnode.Name == "connection_fee")
                {
                    parameters.setConnection_Fee(Convert.ToDouble(cnode.InnerText));
                }
            }
            return parameters;
        }
    }
}