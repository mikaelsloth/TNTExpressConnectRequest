namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "ARTICLE")]
    public partial class Article
    {
        [XmlElement(Order = 0)]
        public int ITEMS { get; set; }

        [XmlElement(Order = 1)]
        public string? DESCRIPTION { get; set; }

        [XmlElement(Order = 2)]
        public decimal WEIGHT { get; set; }

        [XmlElement(Order = 3)]
        public decimal INVOICEVALUE { get; set; }

        [XmlElement(Order = 4)]
        public string? INVOICEDESC { get; set; }

        [XmlElement(Order = 5)]
        public string? HTS { get; set; }

        [XmlElement(Order = 6)]
        public string? COUNTRY { get; set; }

        [XmlElement(Order = 7)]
        public string? EMRN { get; set; }
    }
}
