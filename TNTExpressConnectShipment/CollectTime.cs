namespace TNTExpressConnectShipment
{
    using System;
    using System.Xml.Serialization;

    public class CollectTime
    {
        [XmlIgnore]
        public TimeOnly From { get; set; }

        [XmlElement(Order = 0)]
        public string? FROM { get => From.ToString("hh:mm"); set => From = TimeOnly.ParseExact(value!, "hh:mm"); }

        [XmlIgnore]
        public TimeOnly To { get; set; }

        [XmlElement(Order = 1)]
        public string? TO { get => To.ToString("hh:mm"); set => To = TimeOnly.ParseExact(value!, "hh:mm"); }
    }
}