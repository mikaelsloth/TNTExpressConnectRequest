namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class Address
    {
        [XmlElement(Order = 0)]
        public virtual string? COMPANYNAME { get; set; }

        [XmlElement(Order = 1)]
        public virtual string? STREETADDRESS1 { get; set; }

        [XmlElement(Order = 2)]
        public virtual string? STREETADDRESS2 { get; set; }

        [XmlElement(Order = 3)]
        public virtual string? STREETADDRESS3 { get; set; }

        [XmlElement(Order = 4)]
        public virtual string? CITY { get; set; }

        [XmlElement(Order = 5)]
        public virtual string? PROVINCE { get; set; }

        [XmlElement(Order = 6)]
        public virtual string? POSTCODE { get; set; }

        [XmlElement(Order = 7)]
        public virtual string? COUNTRY { get; set; }

        [XmlElement(Order = 8)]
        public virtual string? VAT { get; set; }

        [XmlElement(Order = 9)]
        public virtual string? CONTACTNAME { get; set; }

        [XmlElement(Order = 10)]
        public virtual string? CONTACTDIALCODE { get; set; }

        [XmlElement(Order = 11)]
        public virtual string? CONTACTTELEPHONE { get; set; }

        [XmlElement(Order = 12)]
        public virtual string? CONTACTEMAIL { get; set; }
    }
}