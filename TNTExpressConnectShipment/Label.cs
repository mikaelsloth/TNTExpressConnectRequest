namespace TNTExpressConnectShipment
{
    using System.Xml.Serialization;

    [Obsolete("This label should not be used as it is depreciated. Please create a label by using the ExpressLabel webservice.", false)]
    [XmlType(TypeName = "LABEL")]
    public partial class Label : ActivityStandard
    {
    }
}
