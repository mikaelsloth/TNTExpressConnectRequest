namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "ESHIPPER")]
    public partial class ShipmentRequest
    {
        [XmlElement(Order = 0)]
        public Login? LOGIN { get; set; }

        [XmlElement(Order = 1)]
        public ConsignmentBatch? CONSIGNMENTBATCH { get; set; }

        [XmlElement(Order = 2)]
        public Activity? ACTIVITY { get; set; }
    }
}