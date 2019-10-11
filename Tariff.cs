using System;
using System.Xml;
using System.Xml.Serialization;

namespace git_lab5
{
    /*Класс Tariff, описывающий тариф, который записан в XML-файле */
    public class Tariff
    {
        // название тарифа
        [XmlAttribute]
        string name;
        // оператор
        [XmlAttribute]
        string operator_name;
        // ежемесячная плата
        [XmlElement]
        double payroll;
        // цены тарифа
        [XmlElement]
        CallPrices call_Prices = new CallPrices();
        // цена за смс
        [XmlElement]
        double sms_price;
        // параметры тарифа
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
        // геттеры и сеттеры
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getOperatorName()
        {
            return operator_name;
        }
        public void setOperatorName(string op_name)
        {
            this.operator_name = op_name;
        } 
        public double getPayroll()
        {
            return payroll;
        }
        public void setPayroll(double payroll)
        {
            this.payroll = payroll;
        }
        public CallPrices getCallPrices()
        {
            return call_Prices;
        }
        public void setCallPrices(CallPrices call)
        {
            this.call_Prices = call;
        }
        public double getSmsPrice()
        {
            return sms_price;
        }
        public void setSmsPrice(double sp)
        {
            this.sms_price = sp;
        }
        public Parameters getParameters()
        {
            return paremeters;
        }
        public void setParameters(Parameters param)
        {
            this.paremeters = param;
        }
    }
}