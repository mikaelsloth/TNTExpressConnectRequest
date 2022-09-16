namespace TNTExpressConnectRequest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

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
    }
}
