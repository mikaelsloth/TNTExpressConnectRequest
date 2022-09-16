namespace TNTExpressConnectRequest
{
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class ExpressLabelRequest : ExpressConnectRequest
    {
        private string url = "https://express.tnt.com/expresslabel/documentation/getlabel";
        private readonly string contenttype = "text/xml";

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
    }
}
