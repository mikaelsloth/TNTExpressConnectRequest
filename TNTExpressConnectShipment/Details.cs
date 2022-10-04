namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "DETAILS")]
    public partial class Details 
    {
        [XmlElement(Order = 0)]
        public ReceiverAddress? RECEIVER { get; set; }

        [XmlElement(Order = 1)]
        public DeliveryAddress? DELIVERY { get; set; }

        [XmlElement(Order = 2)]
        public string? CONNUMBER { get; set; }

        [XmlElement(Order = 3)]
        public string? CUSTOMERREF { get; set; }

        [XmlElement(Order = 4)]
        public string? CONTYPE { get; set; }

        [XmlElement(Order = 5)]
        public string? PAYMENTIND { get; set; }

        [XmlElement(Order = 6)]
        public int ITEMS { get; set; }

        [XmlElement(Order = 7)]
        public decimal TOTALWEIGHT { get; set; }

        [XmlElement(Order = 8)]
        public decimal TOTALVOLUME { get; set; }

        [XmlElement(Order = 9)]
        public string? CURRENCY { get; set; }

        [XmlElement(Order = 10)]
        public decimal GOODSVALUE { get; set; }

        [XmlElement(Order = 11, IsNullable = false)]
        public decimal INSURANCEVALUE { get; set; }

        [XmlIgnore]
        public bool INSURANCEVALUESpecified => INSURANCEVALUE > 0;

        [XmlElement(Order = 12)]
        public string? INSURANCECURRENCY { get; set; }

        [XmlIgnore]
        public bool INSURANCECURRENCYSpecified => INSURANCEVALUE > 0;

        [XmlElement(Order = 13)]
        public string? DIVISION { get; set; }

        [XmlElement(Order = 14)]
        public string? SERVICE { get; set; }

        [XmlElement("OPTION", Order = 15)]
        public string[]? OPTION { get; set; }

        [XmlElement(Order = 16)]
        public string? DESCRIPTION { get; set; }

        [XmlElement(Order = 17)]
        public string? DELIVERYINST { get; set; }

        [XmlElement(Order = 18, IsNullable = false)]
        public bool CUSTOMCONTROLIN { get; set; }

        [XmlIgnore]
        public bool CUSTOMCONTROLINSpecified => CUSTOMCONTROLIN != false;

        [XmlElement(Order = 19, IsNullable = false)]
        public bool HAZARDOUS { get; set; }

        [XmlElement(Order = 20)]
        public string? UNNUMBER { get; set; }

        [XmlElement(Order = 21)]
        public string? PACKINGGROUP { get; set; }

        [XmlElement("PACKAGE", Order = 22)]
        public Package[]? PACKAGE { get; set; }
    }
}
