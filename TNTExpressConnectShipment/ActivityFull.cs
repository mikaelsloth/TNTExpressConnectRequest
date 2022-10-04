namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class ActivityFull
    {
        [XmlElement(Order = 1)]
        public string[]? CONNUMBER { get; set; }

        [XmlElement(Order = 0)]
        public string[]? CONREF { get; set; }

        [XmlElement(Order = 2)]
        public string[]? GROUPCODE { get; set; }
    }
}
