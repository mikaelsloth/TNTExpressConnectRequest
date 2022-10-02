// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using TNTExpressConnectRequest.Tests;

try
{

    ExpressConnectShippingTests request = new();
    Console.WriteLine("All OK");
    //string content = new ExpressConnectShippingTestRequests().FakeSuccessfullRequest();

    //    await request.A01_SubmitShippingRequestAsync_XDocument(content, nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest));
    //    await request.A230_GetResultAsync_InvalidCredentials();
}
catch (Exception ex)
{ Console.WriteLine("errors happened:" + ex.Message); }
//var test = new Test();

//test.CreateSchemaSet(new string[] { "LabelRequest.xsd" });

//class Test
//{
//    internal string ErrorMessages { get; set; } = string.Empty;
//    internal bool Errors { get; set; } = false;

//    internal XmlSchemaSet? CreateSchemaSet(string[] schemafiles)
//    {
//        string tempmsg = string.Empty;
//        XmlSchemaSet schemas = new()
//        {
//            XmlResolver = new XmlUrlResolver()
//        };

//        ValidationEventHandler eventhandler = new(XsdValidationCallback);

//        for (int i = 0; i < schemafiles.Length; i++)
//        {
//            XmlSchema? myschema = XmlSchema.Read(XmlReader.Create(schemafiles[i]), eventhandler);

//#if DEBUG
//            if (myschema == null)
//            {
//                throw new XmlException($"The XML schema could not be read. The following errors were encountered:\r\n{tempmsg}");
//            }
//#endif

//            try
//            {
//                _ = schemas.Add(myschema);
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        schemas.Compile();
//        return schemas;
//    }

//    void XsdValidationCallback(object? sender, ValidationEventArgs e)
//    {
//        ArgumentNullException.ThrowIfNull(e);
//        ErrorMessages += "The following messages came from reading the schema: \r\n";

//        ErrorMessages += e.Severity switch
//        {
//            XmlSeverityType.Warning => "WARNING: " + e.Message,
//            XmlSeverityType.Error => "ERROR: " + e.Message,
//            _ => string.Empty
//        };
//        ErrorMessages += e.Exception?.Message ?? string.Empty;
//    }
//}

