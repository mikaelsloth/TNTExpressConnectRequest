namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "PACKAGE")]
    public partial class Package
    {
        [XmlElement(Order = 0)]
        public int ITEMS { get; set; }

        [XmlElement(Order = 1)]
        public string? DESCRIPTION { get; set; }

        [XmlElement(Order = 2)]
        public decimal LENGTH { get; set; }

        [XmlElement(Order = 3)]
        public decimal HEIGHT { get; set; }

        [XmlElement(Order = 4)]
        public decimal WIDTH { get; set; }

        [XmlElement(Order = 5)]
        public decimal WEIGHT { get; set; }

        [XmlElement("ARTICLE", Order = 6)]
        public Article[]? ARTICLE { get; set; }
    }
}
