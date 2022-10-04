namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "RECEIVER")]
    public partial class ReceiverAddress : Address
    {
        [XmlElement(Order = 13)]
        public string? ACCOUNT { get; set; }

        [XmlElement(Order = 14)]
        public string? ACCOUNTCOUNTRY { get; set; }
    }
}
