namespace TNTExpressConnectRequest
{
    public class ExpressLabelRequest : ExpressConnectRequest
    {
        private string url = "https://express.tnt.com/expresslabel/documentation/getlabel";
        private readonly string contenttype = "text/xml";

        /// <inheritdoc cref="ExpressConnectRequest.URL"/>
        public override string URL
        {
            get => url;
            set => url = value;
        }

        /// <inheritdoc cref="ExpressConnectRequest.ContentType"/>
        public override string ContentType => contenttype;
    }
}
