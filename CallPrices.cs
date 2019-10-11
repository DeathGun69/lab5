using System.Xml.Serialization;

namespace git_lab5
{
    /*Класс CallPrices, описывающий цены на звонки */
    public class CallPrices
    {
        // внутри сети
        [XmlElement]
        double inside_network;
        // вне сети
        [XmlElement]
        double outside_network;
        // звонки на стационарные телефоны
        [XmlElement]
        double  fixed_phone;
        public CallPrices(){    }
        public CallPrices(double inside_n, double  outside_n, double  f_phone)
        {
            this.inside_network = inside_n;
            this.outside_network = outside_n;
            this.fixed_phone = f_phone;
        }
        // геттер для цены внутри сети
        public double getInsideNetwork()
        {
            return inside_network;
        }
        // сеттер для цены внутри сети
        public void setInsideNetwork(double inside_n)
        {
            this.inside_network = inside_n;
        }
        // геттер для цены вне сети
        public double  getOutsideNetwork()
        {
            return outside_network;
        }
        // сеттер для цены вне сети
        public void setOutsideNetwork(double  outside_n)
        {
            this.outside_network = outside_n;
        }
        // геттер для цены на звонки на стационарные телефоны
        public double getFixed_Phone()
        {
            return fixed_phone;
        }
        // сеттер для цены на звонки на стационарные телефоны
        public void setFixed_Phone(double f_phone)
        {
            this.fixed_phone = f_phone;
        }
    }
}