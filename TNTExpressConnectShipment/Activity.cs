namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "ACTIVITY")]
    public partial class Activity
    {
        [XmlElement(Order = 0)]
        public CreateActivity? CREATE { get; set; }

        [XmlElement(Order = 1)]
        public RateActivity? RATE { get; set; }

        [XmlElement(Order = 2)]
        public BookActivity? BOOK { get; set; }

        [XmlElement(Order = 3)]
        public ShipActivity? SHIP { get; set; }

        [XmlElement(Order = 4)]
        public Print? PRINT { get; set; }

        [XmlElement(Order = 5)]
        public Show_Groupcode? SHOW_GROUPCODE { get; set; }
    }
}
