using System.Xml.Serialization;

namespace git_lab5
{
    /*Класс Parameters, описывающий параметры тарифа. */
    public class Parameters 
    {
        // любимый номер
        [XmlElement]
        private long favourite_number;
        // тарификация
        [XmlText]
        private string tariffication;
        // плата за подключение
        [XmlElement]
        private double connection_fee;
        public Parameters(){    }
        public Parameters(long f_number, string tariff, double f_phone)
        {
            this.favourite_number = f_number;
            this.tariffication = tariff;
            this.connection_fee = f_phone;
        }
        // геттеры и сеттеры
        public long getFavouriteNumber()
        {
            return favourite_number;
        }
        public void setFavouriteNumber(long f_number)
        {
            this.favourite_number = f_number;
        }
        public string getTarifficaton()
        {
            return tariffication;
        }
        public void setTarifficaton(string tariff)
        {
            this.tariffication = tariff;
        }
        public double getConnection_Fee()
        {
            return connection_fee;
        }
        public void setConnection_Fee(double f_phone)
        {
            this.connection_fee = f_phone;
        }
    }
}