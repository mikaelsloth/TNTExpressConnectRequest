namespace TNTExpressConnectRequest
{
    using RestSharp;
    using System;
    using System.Xml.Linq;

    class ExpressConnectShippingRequest : ExpressConnectRequest
    {
        private string url = "https://express.tnt.com/expressconnect/shipping/ship";
        private readonly string contenttype = "application/x-www-form-urlencoded";

        /// <summary>
        /// Get or set the endpoint URL for the API
        /// </summary>
        public override string URL
        {
            get => url;
            set => url = value;
        }

        /// <summary>
        /// Get a string containing the Content type for the header
        /// </summary>
        public override string ContentType => contenttype;

        protected override RestRequest SetupConnectionParameters(string requestXmlAsString, RestClient client)
        {
            RestRequest request = new() { Resource = URL };
            _ = request.AddHeader("Content-Type", ContentType);
            _ = request.AddHeader("Accept", "*/*");
            _ = request.AddParameter("xml_in", requestXmlAsString);

            return request;
        }

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
