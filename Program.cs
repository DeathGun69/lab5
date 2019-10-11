using System;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;

namespace git_lab5
{
    class Program
    {
        // точка входа
        static void Main(string[] args)
        {
            // объявление списков для заполнения
            List<Tariff> tariffs1 = new List<Tariff>();
            List<Tariff> tariffs2 = new List<Tariff>();
            // пути к файлам
            string XSDPATH = @"C:\Users\Eugene\Desktop\KPO\lab5\git_lab5\tariffs.xsd";
            string XMLPATH = @"C:\Users\Eugene\Desktop\KPO\lab5\git_lab5\tariffs.xml"; 
            // парсинг DOM
            XMLParser xmlParser = new XMLParser(XSDPATH, XMLPATH);
            tariffs1 = xmlParser.buildTarrifList();
            // вывод полученных данных
            foreach (Tariff item in tariffs1)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Name tariff: " + item.getName());
                Console.WriteLine("Operator name: " + item.getOperatorName());
                Console.WriteLine("Payroll: " + item.getPayroll());
                Console.WriteLine("Inside network: " + item.getCallPrices().getInsideNetwork());
                Console.WriteLine("Outside network: " + item.getCallPrices().getOutsideNetwork());
                Console.WriteLine("Fixed phone: " + item.getCallPrices().getFixed_Phone());
                Console.WriteLine("Sms price: " + item.getSmsPrice());
                Console.WriteLine("Favourite number: " + item.getParameters().getFavouriteNumber());
                Console.WriteLine("Tariffication: " + item.getParameters().getTarifficaton());
                Console.WriteLine("Connection fee: " + item.getParameters().getConnection_Fee());
            }
            Console.WriteLine("---------------------------------");
            // парсинг SAX
            XMLReader xMLReader = new XMLReader(XSDPATH, XMLPATH);
            tariffs2 = xMLReader.Read_XML();
            // вывод полученных данных
            foreach (Tariff item in tariffs2)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Name tariff: " + item.getName());
                Console.WriteLine("Operator name: " + item.getOperatorName());
                Console.WriteLine("Payroll: " + item.getPayroll());
                Console.WriteLine("Inside network: " + item.getCallPrices().getInsideNetwork());
                Console.WriteLine("Outside network: " + item.getCallPrices().getOutsideNetwork());
                Console.WriteLine("Fixed phone: " + item.getCallPrices().getFixed_Phone());
                Console.WriteLine("Sms price: " + item.getSmsPrice());
                Console.WriteLine("Favourite number: " + item.getParameters().getFavouriteNumber());
                Console.WriteLine("Tariffication: " + item.getParameters().getTarifficaton());
                Console.WriteLine("Connection fee: " + item.getParameters().getConnection_Fee());
            }
        }
    }
}
