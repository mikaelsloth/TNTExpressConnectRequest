namespace TNTExpressConnectShipment
{
    using System;
    using System.Xml.Serialization;

    [XmlType(TypeName = "COLLECTION")]
    public partial class Collection
    {
        [XmlElement(Order = 0)]
        public CollectionAddress? COLLECTIONADDRESS { get; set; }

        [XmlIgnore]
        public DateOnly? ShipDate { get; set; }

        [XmlElement(Order = 1)]
        public string? SHIPDATE { get => ShipDate?.ToString("dd/MM/yyyy").Replace('-', '/') ; set => ShipDate = DateOnly.ParseExact(value!, "dd/MM/yyyy"); }

        [XmlElement(Order = 2)]
        public PrefCollectTime? PREFCOLLECTTIME { get; set; }

        [XmlElement(Order = 3)]
        public AltCollectTime? ALTCOLLECTTIME { get; set; }

        [XmlElement(Order = 4)]
        public string? COLLINSTRUCTIONS { get; set; }

        [XmlElement(Order = 5)]
        public string? CONFIRMATIONEMAILADDRESS { get; set; }
    }
}
