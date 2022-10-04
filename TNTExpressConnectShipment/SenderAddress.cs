namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "SENDER")]
    public partial class SenderAddress : Address
    {
        [XmlElement(Order = 8)]
        public string? ACCOUNT { get; set; }

        [XmlElement(Order = 9)]
        public override string? VAT { get; set; }

        [XmlElement(Order = 10)]
        public override string? CONTACTNAME { get; set; }

        [XmlElement(Order = 11)]
        public override string? CONTACTDIALCODE { get; set; }

        [XmlElement(Order = 12)]
        public override string? CONTACTTELEPHONE { get; set; }

        [XmlElement(Order = 13)]
        public override string? CONTACTEMAIL { get; set; }

        [XmlElement(Order = 14)]
        public Collection? COLLECTION { get; set; }
    }
}
