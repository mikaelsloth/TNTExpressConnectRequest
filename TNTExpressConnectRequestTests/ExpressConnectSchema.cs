namespace TNTExpressConnectRequest.Tests
{
    using System.Xml;
    using System.Xml.Schema;

    internal class ExpressConnectSchema
    {
        public ExpressConnectSchema(string[] schemafiles)
        {
            FakeRequestSchema = CreateSchemaSet(schemafiles);
        }

        public virtual XmlSchemaSet? FakeRequestSchema { get; protected set; }

        protected static XmlSchemaSet? CreateSchemaSet(string[] schemafiles)
        {
            string tempmsg = string.Empty;
            XmlSchemaSet? schemas = new()
            {
                XmlResolver = new XmlUrlResolver()
            };

            for (int i = 0; i < schemafiles.Length; i++)
            {

                XmlSchema? myschema = XmlSchema.Read(XmlReader.Create(schemafiles[i]), (o, e) =>
                {
                    tempmsg = "The following messages came from reading the schema: \r\n";
                    if (e.Severity == XmlSeverityType.Warning)
                        tempmsg = tempmsg + "\r\n" + "WARNING: " + e.Message;
                    else if (e.Severity == XmlSeverityType.Error)
                        tempmsg = tempmsg + "\r\n" + "ERROR: " + e.Message;
                });

#if DEBUG
                if (myschema == null)
                {
                    throw new XmlException($"The XML schema could not be read. The following errors were encountered:\r\n{tempmsg}");
                }
#endif

                try
                {
                    _ = schemas!.Add(myschema);
                }
                catch
                {
                    schemas = null;
                    break;
                }
            }

            return schemas;
        }
    }
}