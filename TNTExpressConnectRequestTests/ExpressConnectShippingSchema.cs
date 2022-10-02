namespace TNTExpressConnectRequest.Tests
{
    internal sealed class ExpressConnectShippingSchema : ExpressConnectSchema
    {
        private static readonly string[] schemafiles = new string[] { "ShipmentRequest.xsd" };

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ExpressConnectShippingSchema()
        {
        }

        private ExpressConnectShippingSchema() : base(schemafiles)
        {
        }

        public static ExpressConnectShippingSchema Instance { get; } = new();
    }
}
