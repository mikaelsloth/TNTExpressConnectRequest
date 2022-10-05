namespace TNTExpressConnectShipment
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public static class SerializeExtensionMethods
    {
        public static T? DeserializeFromXDoc<T>(this XDocument source) where T : ShipmentRequest
        {
            if (source is null || source.Root is null)
                return default;

            try
            {
                using var reader = source.Root.CreateReader();
                return new XmlSerializer(typeof(T)).Deserialize(reader) is T t ? t : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static XDocument? SerializeToXDoc<T>(this T source) where T : ShipmentRequest
        {
            if (source is null)
                return null;
            try
            {
                XDocument doc = new(new XDeclaration("1.0", "utf-8", "yes"));
                using XmlWriter writer = doc.CreateWriter();
                new XmlSerializer(typeof(T)).Serialize(writer, source);

                return doc;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
