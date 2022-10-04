namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "PRINT")]
    public partial class PrintActivity
    {
        [XmlElement(Order = 0)]
        public Required? REQUIRED { get; set; }

        [XmlElement(Order = 1)]
        public Connote? CONNOTE { get; set; }

        [XmlElement(Order = 2)]
#pragma warning disable CS0618 // Type or member is obsolete
        public Label? LABEL { get; set; }
#pragma warning restore CS0618 // Type or member is obsolete

        [XmlElement(Order = 3)]
        public Manifest? MANIFEST { get; set; }

        [XmlElement(Order = 4)]
        public Invoice? INVOICE { get; set; }

        [XmlElement(Order = 5)]
        public EmailTo? EMAILTO { get; set; }

        [XmlElement(Order = 6)]
        public string? EMAILFROM { get; set; }
    }
}
