namespace TNTExpressConnectShipment
{
    using System.Xml;
    using System.Xml.Serialization;

    public partial class ShipmentRequest
    {
        public ShipmentRequest()
        {
            Namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[]
            { new XmlQualifiedName(string.Empty, "")});
        }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces { get; }
    }
}
