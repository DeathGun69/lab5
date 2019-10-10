using System.Xml.Serialization;

namespace git_lab5
{
    public class CallPrices
    {
        [XmlElement]
        double inside_network;
        [XmlElement]
        double outside_network;
        [XmlElement]
        double  fixed_phone;
        public CallPrices(){    }
        public CallPrices(double inside_n, double  outside_n, double  f_phone)
        {
            this.inside_network = inside_n;
            this.outside_network = outside_n;
            this.fixed_phone = f_phone;
        }
        public double getInsideNetwork()
        {
            return inside_network;
        }
        public void setInsideNetwork(double inside_n)
        {
            this.inside_network = inside_n;
        }
        public double  getOutsideNetwork()
        {
            return outside_network;
        }
        public void setOutsideNetwork(double  outside_n)
        {
            this.outside_network = outside_n;
        }
        public double getFixed_Phone()
        {
            return fixed_phone;
        }
        public void setFixed_Phone(double f_phone)
        {
            this.fixed_phone = f_phone;
        }
    }
}