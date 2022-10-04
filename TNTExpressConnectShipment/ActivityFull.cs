namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    public class ActivityFull
    {
        [XmlElement("CONNUMBER", typeof(string), Order = 0)]
        [XmlElement("CONREF", typeof(string), Order = 0)]
        [XmlElement("GROUPCODE", typeof(string), Order = 0)]
        [XmlChoiceIdentifier("ItemsElementName")]
        public string[]? Items { get; set; }

        [XmlElement("ItemsElementName", Order = 1)]
        [XmlIgnore()]
        public ItemsChoiceType[]? ItemsElementName { get; set; }
    }

    public enum ItemsChoiceType
    {
        CONNUMBER,

        CONREF,

        GROUPCODE,
    }
}
