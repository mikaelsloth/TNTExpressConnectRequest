namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "CONSIGNMENT")]
    public partial class Consignment
    {
        [XmlElement(Order = 0)]
        public string? CONREF { get; set; }

        [XmlElement("CONNUMBER", typeof(string), Order = 1)]
        [XmlElement("DETAILS", typeof(Details), Order = 1)]
        public object? Item { get; set; }
    }
}
