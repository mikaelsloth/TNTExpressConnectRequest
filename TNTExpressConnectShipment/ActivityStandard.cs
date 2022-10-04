namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class ActivityStandard : ActivityBase
    {
        [XmlElement("CONNUMBER", Order = 1)]
        public string[]? CONNUMBER { get; set; }
    }
}
