using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace git_lab5
{
    public class XMLReader
    {
        private bool XSDValidation;
        private string xsdPath;
        private string xmlPath;
        public XMLReader(string xsdP, string xmlP)
        {
            this.xsdPath = xsdP;
            this.xmlPath = xmlP;
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
        public List<Tariff> Read_XML()
        {
            List<Tariff> tariffs = new List<Tariff>();
            XSDValidation = true;
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.Schemas.Add("http://www.example.com/students", xsdPath);
            xmlSettings.ValidationType = ValidationType.Schema;
            xmlSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);
            Tariff tariff = new Tariff();
            CallPrices callPrices = new CallPrices();
            Parameters parameters = new Parameters();
            using(XmlReader tarr = XmlReader.Create(xmlPath, xmlSettings))
            {
                try {
                    while (tarr.Read())
                    {   
                        if (tarr.HasAttributes)
                        {
                            while (tarr.MoveToNextAttribute())
                                {
                                    if (tarr.Name == "name")
                                    {
                                        tariff.setName(tarr.Value);
                                    }
                                    if (tarr.Name == "operator_name")
                                    {
                                        tariff.setOperatorName(tarr.Value);
                                    }
                                }
                        }
                        switch (tarr.NodeType)
                        {
                            case XmlNodeType.Element:
                                switch(tarr.Name)
                                {
                                    case "payroll":
                                        tarr.Read();
                                        tariff.setPayroll(Convert.ToDouble(tarr.Value));
                                    break;
                                    case "call_prices":
                                        tarr.Read();
                                        tariff.setCallPrices(callPrices);
                                    break;
                                    case "inside_network":
                                        tarr.Read();
                                        tariff.getCallPrices().setInsideNetwork(Convert.ToDouble(tarr.Value));
                                    break;
                                    case "outside_network":
                                        tarr.Read();
                                        tariff.getCallPrices().setOutsideNetwork(Convert.ToDouble(tarr.Value));
                                    break;
                                    case "fixed_phone":
                                        tarr.Read();
                                        tariff.getCallPrices().setFixed_Phone(Convert.ToDouble(tarr.Value));
                                    break;
                                    case "sms_price":
                                        tarr.Read();
                                        tariff.setSmsPrice(Convert.ToDouble(tarr.Value));
                                    break;
                                    case "parameters":
                                        tarr.Read();
                                        tariff.setParameters(parameters);
                                    break;
                                    case "favorite_number":
                                        tarr.Read();
                                        tariff.getParameters().setFavouriteNumber(Convert.ToInt64(tarr.Value));
                                    break;
                                    case "tariffication":
                                        tarr.Read();
                                        tariff.getParameters().setTarifficaton(tarr.Value);
                                    break;
                                    case "connection_fee":
                                        tarr.Read();
                                        tariff.getParameters().setConnection_Fee(Convert.ToDouble(tarr.Value));
                                    break;
                                }
                            break;
                            case XmlNodeType.EndElement:
                                if(tarr.Name == "tariff")
                                {
                                    tariffs.Add(tariff);
                                    tariff = new Tariff();
                                    parameters = new Parameters();
                                    callPrices = new CallPrices();
                                }
                            break;
                        }
                    }
                } catch (Exception) 
                {
                    XSDValidation = false;
                }
            }
            return tariffs;
        }
    }
}