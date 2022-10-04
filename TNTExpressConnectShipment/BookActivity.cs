namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "BOOK")]
    public partial class BookActivity : ActivityFull
    {
        [XmlAttribute()]
        public bool? EMAILREQD { get; set; }

        [XmlAttribute()]
        public bool? ShowBookingRef { get; set; }

        [XmlAttribute()]
        public string? FaxNumber { get; set; }

        [XmlAttribute()]
        public string? LanguageId { get; set; }

        [XmlAttribute()]
        public bool PrintAtDepot { get; set; }
    }
}
