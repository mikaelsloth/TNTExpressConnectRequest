namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "BOOK")]
    public partial class BookActivity : ActivityFull
    {
        [XmlAttribute()]
        public bool EMAILREQD { get; set; }

        [XmlIgnore]
        public bool EMAILREQDSpecified => EMAILREQD != false;

        [XmlAttribute()]
        public bool ShowBookingRef { get; set; }

        [XmlIgnore]
        public bool ShowBookingRefSpecified => ShowBookingRef != false;

        [XmlAttribute()]
        public string? FaxNumber { get; set; }

        [XmlAttribute()]
        public string? LanguageId { get; set; }

        [XmlAttribute()]
        public bool PrintAtDepot { get; set; }

        [XmlIgnore]
        public bool PrintAtDepotSpecified => PrintAtDepot != false;
    }
}
