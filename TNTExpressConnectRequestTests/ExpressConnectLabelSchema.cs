namespace TNTExpressConnectRequest.Tests
{
    internal sealed class ExpressConnectLabelSchema : ExpressConnectSchema
    {
        private static readonly string[] schemafiles = new string[] { "LabelRequest.xsd" };

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ExpressConnectLabelSchema()
        {
        }

        private ExpressConnectLabelSchema() : base(schemafiles)
        {
        }

        public static ExpressConnectLabelSchema Instance { get; } = new();
    }
}
