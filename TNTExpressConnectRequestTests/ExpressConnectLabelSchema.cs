namespace TNTExpressConnectRequest.Tests
{
    using System;

    internal class ExpressConnectLabelSchema : ExpressConnectSchema
    {
        private static readonly string[] schemafiles = new string[] { "LabelCommonDefinitions.xsd", "LabelRequest.xsd" };

        private ExpressConnectLabelSchema() : base(schemafiles)
        {
        }

        private static readonly Lazy<ExpressConnectLabelSchema> lazy = new(() => new ExpressConnectLabelSchema());

        public static ExpressConnectLabelSchema Instance = lazy.Value;

    }
}
