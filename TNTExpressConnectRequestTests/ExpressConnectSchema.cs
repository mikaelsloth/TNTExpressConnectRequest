namespace TNTExpressConnectRequest.Tests
{
    using System;
    using System.Xml;
    using System.Xml.Schema;

    internal class ExpressConnectSchema
    {
        public string ErrorMessages { get; protected set; } = string.Empty;
        public bool Errors { get; protected set; } = false;

        public ExpressConnectSchema(string[] schemafiles)
        {
            FakeRequestSchema = CreateSchemaSet(schemafiles);
        }

        public virtual XmlSchemaSet? FakeRequestSchema { get; protected set; }

        private XmlSchemaSet? CreateSchemaSet(string[] schemafiles)
        {
            string tempmsg = string.Empty;
            bool error = false;
            XmlSchemaSet schemas = new()
            {
                XmlResolver = new XmlUrlResolver()
            };

            try
            {
                for (int i = 0; i < schemafiles.Length; i++)
                {
                    XmlSchema? myschema = XmlSchema.Read(XmlReader.Create(schemafiles[i]), (o, e) =>
                    {
                        ArgumentNullException.ThrowIfNull(e);
                        tempmsg += "The following messages came from reading the schema: \r\n";

                        tempmsg += e.Severity switch
                        {
                            XmlSeverityType.Warning => "WARNING: " + e.Message,
                            XmlSeverityType.Error => "ERROR: " + e.Message,
                            _ => string.Empty
                        };
                        tempmsg += e.Exception?.Message ?? string.Empty;
                        error = true;
                    });

#if DEBUG
                    if (myschema == null)
                    {
                        throw new XmlException($"The XML schema could not be read. The following errors were encountered:\r\n{tempmsg}");
                    }
#endif

                    _ = schemas.Add(myschema);
                }

                schemas.Compile();
            }
            catch
            {
                Errors = error;
                ErrorMessages = tempmsg;
                return null;
            }

            return schemas;
        }
    }
}