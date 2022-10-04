namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "EMAILTO")]
    public partial class EmailTo
    {
        [XmlAttribute()]
        public string? type { get; set; }

        [XmlText()]
        public string? Value { get; set; }
    }
}
