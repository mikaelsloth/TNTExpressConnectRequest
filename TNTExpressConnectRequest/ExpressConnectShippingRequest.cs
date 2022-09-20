namespace TNTExpressConnectRequest
{
    using RestSharp;
    using System;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class ExpressConnectShippingRequest : ExpressConnectRequest
    {
        private const string GET_RESULT = "GET_RESULT:";
        private const string GET_MANIFEST = "GET_MANIFEST:";
        private const string GET_INVOICE = "GET_INVOICE:";
        private const string GET_CONNOTE = "GET_CONNOTE:";

        private string url = "https://express.tnt.com/expressconnect/shipping/ship";
        private readonly string contenttype = "application/x-www-form-urlencoded";

        /// <inheritdoc cref="ExpressConnectRequest.URL"/>
        public override string URL
        {
            get => url;
            set => url = value;
        }

        /// <inheritdoc cref="ExpressConnectRequest.ContentType"/>
        public override string ContentType => contenttype;

        /// <summary>
        /// Submit a request to get the Result document for the referenced transaction
        /// </summary>
        /// <param name="accesskey">A string containing the access key from the initial response</param>
        /// <returns>An <see cref="XDocument>"/> containing the requested document</returns>
        public virtual XDocument GetResult(string accesskey) => SubmitRequest(GET_RESULT + accesskey);

        /// <summary>
        /// Submit an async request to get the Result document for the referenced transaction
        /// </summary>
        /// <param name="accesskey">A string containing the access key from the initial response</param>
        /// <returns>An <see cref="Task>"/> object where the result is the requested document</returns>
        public virtual async Task<XDocument> GetResultAsync(string accesskey) => await SubmitRequestAsync(GET_RESULT + accesskey);

        /// <summary>
        /// Submit a request to get the Manifest document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResult(string)"/>
        public virtual XDocument GetManifest(string accesskey) => SubmitRequest(GET_MANIFEST + accesskey);

        /// <summary>
        /// Submit an async request to get the Manifest document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResultAsync(string)"/>
        public virtual async Task<XDocument> GetManifestAsync(string accesskey) => await SubmitRequestAsync(GET_MANIFEST + accesskey);

        /// <summary>
        /// Submit a request to get the Invoice document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResult(string)"/>
        public virtual XDocument GetInvoice(string accesskey) => SubmitRequest(GET_INVOICE + accesskey);

        /// <summary>
        /// Submit an async request to get the Invoice document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResultAsync(string)"/>
        public virtual async Task<XDocument> GetInvoiceAsync(string accesskey) => await SubmitRequestAsync(GET_INVOICE + accesskey);

        /// <summary>
        /// Submit a request to get the Connote document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResult(string)"/>
        public virtual XDocument GetConnote(string accesskey) => SubmitRequest(GET_CONNOTE + accesskey);

        /// <summary>
        /// Submit an async request to get the Connote document for the referenced transaction
        /// </summary>
        /// <inheritdoc cref="GetResultAsync(string)"/>
        public virtual async Task<XDocument> GetConnoteAsync(string accesskey) => await SubmitRequestAsync(GET_CONNOTE + accesskey);

        /// <inheritdoc cref="ExpressConnectRequest.SetupConnectionParameters(string, RestClient)"/>
        protected override RestRequest SetupConnectionParameters(string requestXmlAsString, RestClient client)
        {
            RestRequest request = new() { Resource = URL };
            _ = request.AddHeader("Content-Type", ContentType);
            _ = request.AddHeader("Accept", "*/*");
            _ = request.AddParameter("xml_in", requestXmlAsString);

            return request;
        }

        /// <inheritdoc cref="ExpressConnectRequest.ParseToXDoc(RestResponse)(string, RestClient)"/>
        protected override XDocument ParseToXDoc(RestResponse response)
        {
            string value = response.Content;
            if (!value.Contains("COMPLETE")) throw new Exception("The shipping endpoint must return a COMPLETE message containing an access key");
            string accesskey = value[9..];

            XDocument document = new (
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XElement("AccessKey", accesskey));
            return document;
        }
    }
}
