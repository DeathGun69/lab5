using System;
using System.Xml;
using System.Xml.Serialization;

namespace git_lab5
{
    public class Tariff
    {
        [XmlAttribute]
        string name;
        [XmlAttribute]
        string operator_name;
        [XmlElement]
        double payroll;
        [XmlElement]
        CallPrices call_Prices = new CallPrices();
        [XmlElement]
        double sms_price;
        [XmlElement]
        Parameters paremeters = new Parameters();
        public Tariff() {   }
        public Tariff(string name, string operatorname, double payroll, CallPrices callPrices, double smsprice, Parameters parameters)
        {
            this.name = name;
            this.operator_name = operatorname;
            this.payroll = payroll;
            this.call_Prices = callPrices;
            this.sms_price = smsprice;
            this.paremeters = parameters;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public double getPayroll()
        {
            return payroll;
        }
        public void setPayroll(double payroll)
        {
            this.payroll = payroll;
        }
        
    }
}