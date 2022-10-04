namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [XmlType(TypeName = "CONSIGNMENTBATCH")]
    public partial class ConsignmentBatch
    {
        [XmlElement(Order = 0)]
        public string? GROUPCODE { get; set; }

        [XmlElement(Order = 1)]
        public SenderAddress? SENDER { get; set; }

        [XmlElement("CONSIGNMENT", Order = 2)]
        public Consignment[]? CONSIGNMENT { get; set; }
    }
}
