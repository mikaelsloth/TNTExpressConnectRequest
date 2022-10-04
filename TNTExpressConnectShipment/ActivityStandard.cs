namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class ActivityStandard : Activity
    {
        [XmlElement("CONNUMBER", Order = 1)]
        public string[]? CONNUMBER { get; set; }
    }
}
