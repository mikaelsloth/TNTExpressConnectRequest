namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "LOGIN")]
    public partial class Login
    {
        [XmlElement(Order = 0)]
        public string? COMPANY { get; set; }

        [XmlElement(Order = 1)]
        public string? PASSWORD { get; set; }

        [XmlElement(Order = 2)]
        public string? APPID { get; set; }

        [XmlElement(Order = 3)]
        public string? APPVERSION { get; set; }
    }
}
