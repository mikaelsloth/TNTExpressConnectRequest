namespace TNTExpressConnectRequest.Tests
{
    using System;

    internal class ExpressConnectShippingSchema : ExpressConnectSchema
    {
        private static readonly string[] schemafiles = new string[] { "ShippingCommonDefinitions.xsd", "ShipmentRequest.xsd" };

        private ExpressConnectShippingSchema() : base(schemafiles)
        {
        }

        private static readonly Lazy<ExpressConnectShippingSchema> lazy = new(() => new ExpressConnectShippingSchema());

        public static ExpressConnectShippingSchema Instance = lazy.Value;
    }
}
