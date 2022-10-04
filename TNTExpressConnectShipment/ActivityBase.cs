namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class ActivityBase
    {
        [XmlElement("CONREF", Order = 0)]
        public string[]? CONREF { get; set; }
    }
}