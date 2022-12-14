namespace TNTExpressConnectRequest
{
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    /// <summary>
    /// Abstract base class for request to the various ExpressConnect endpoints, like labeling, pricing and shipping.
    /// </summary>
    public abstract class ExpressConnectRequest
    {
        protected static RestClient GetHttpClient { get; } = new();

        /// <summary>
        /// Get or set the login name to be used for the request
        /// </summary>
        public virtual string? CustomerId
        {
            get;
            set;
        }

        /// <summary>
        /// Set the password to be used for the request
        /// </summary>
        public virtual string? Password
        {
            protected get;
            set;
        }

        /// <summary>
        /// Get or set the URL of the web service endpoint
        /// </summary>
        public abstract string URL
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the header content type
        /// </summary>
        public abstract string ContentType
        {
            get;
        }

        /// <summary>
        /// Create an asyncronous request to the TNT ExpressConnect service
        /// </summary>
        /// <param name="requestXml">A <see cref="XDocument"/> object containing the XML message to be submitted to the web service</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual async Task<XDocument> SubmitRequestAsync(XDocument requestXml) => await SubmitRequestAsyncImpl(requestXml.ToString());

        /// <summary>
        /// Create an asyncronous request to the TNT ExpressConnect service
        /// </summary>
        /// <param name="requestXmlAsString">A <see cref="string"/> object containing the XML message to be submitted to the web service</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual async Task<XDocument> SubmitRequestAsync(string requestXmlAsString) => await SubmitRequestAsyncImpl(requestXmlAsString);

        /// <summary>
        /// Create a request to the TNT ExpressConnect service 
        /// </summary>
        /// <param name="requestXml">A <see cref="XDocument"/> object containing the XML message to be submitted to the web service</param>
        /// <returns>An <see cref="XDocument"/> object containing the XML response from the service</returns>
        public virtual XDocument SubmitRequest(XDocument requestXml) => SubmitRequestImpl(requestXml.ToString());

        /// <summary>
        /// Create a request to the TNT ExpressConnect service 
        /// </summary>
        /// <param name="requestXmlAsString">A <see cref="string"/> object containing the XML message to be submitted to the web service</param>
        /// <returns>An <see cref="XDocument"/> object containing the XML response from the service</returns>
        public virtual XDocument SubmitRequest(string requestXmlAsString) => SubmitRequestImpl(requestXmlAsString);

        /// <summary>
        /// Create an asyncronous request to the TNT ExpressConnect service after validating the input against a schema
        /// </summary>
        /// <param name="requestXml">A <see cref="XDocument"/> object containing the XML message to be submitted to the web service</param>
        /// <param name="schemaSet">A <see cref="XmlSchemaSet"/> object with the validation schema</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual async Task<XDocument> SubmitRequestAsync(XDocument requestXml, XmlSchemaSet schemaSet) =>
            // If schema not valid inform user
            !TryValidateSchema(requestXml, schemaSet, out string message)
                ? throw new ArgumentException($"The request is not confirming to the supplied schema. \r\nThe error returned was : \r\n{message}\r\nPlease ensure you use a valid request.")
                : await SubmitRequestAsyncImpl(requestXml.ToString());

        /// <summary>
        /// Create an asyncronous request to the TNT ExpressConnect service after validating the input against a schema
        /// </summary>
        /// <param name="requestXmlAsString">A <see cref="string"/> object containing the XML message to be submitted to the web service</param>
        /// <param name="schemaSet">A <see cref="XmlSchemaSet"/> object with the validation schema</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual async Task<XDocument> SubmitRequestAsync(string requestXmlAsString, XmlSchemaSet schemaSet)
        {
            // If not valid XML then inform caller
            XDocument inputxml;
            try
            {
                inputxml = XDocument.Parse(requestXmlAsString, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
                return !TryValidateSchema(inputxml, schemaSet, out string message)
                    ? throw new ArgumentException($"The request is not confirming to the supplied schema. \r\nThe error returned was : \r\n{message}\r\nPlease ensure you use a valid request.")
                    : await SubmitRequestAsyncImpl(requestXmlAsString);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"The request is invalid. \r\nThe error returned was : \r\n{ex.Message}\r\nPlease correct the errors and try again.", nameof(requestXmlAsString), ex);
            }
        }

        /// <summary>
        /// Create a request to the TNT ExpressConnect service after validating the input against a schema
        /// </summary>
        /// <param name="requestXml">A <see cref="XDocument"/> object containing the XML message to be submitted to the web service</param>
        /// <param name="schemaSet">A <see cref="XmlSchemaSet"/> object with the validation schema</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual XDocument SubmitRequest(XDocument requestXml, XmlSchemaSet schemaSet) =>
            // If schema not valid inform user
            !TryValidateSchema(requestXml, schemaSet, out string message)
                ? throw new ArgumentException($"The request is not confirming to the supplied schema. \r\nThe error returned was : \r\n{message}\r\nPlease ensure you use a valid request.")
                : SubmitRequestImpl(requestXml.ToString());

        /// <summary>
        /// Create a request to the TNT ExpressConnect service after validating the input against a schema
        /// </summary>
        /// <param name="requestXmlAsString">A <see cref="string"/> object containing the XML message to be submitted to the web service</param>
        /// <param name="schemaSet">A <see cref="XmlSchemaSet"/> object with the validation schema</param>
        /// <returns>A <see cref="Task"/> object where the result is the XML response from the service</returns>
        public virtual XDocument SubmitRequest(string requestXmlAsString, XmlSchemaSet schemaSet)
        {
            // If not valid XML then inform caller
            XDocument inputxml;
            try
            {
                inputxml = XDocument.Parse(requestXmlAsString, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
                return !TryValidateSchema(inputxml, schemaSet, out string message)
                    ? throw new ArgumentException($"The request is not confirming to the supplied schema. \r\nThe error returned was : \r\n{message}\r\nPlease ensure you use a valid request.")
                    : SubmitRequestImpl(requestXmlAsString);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"The request is invalid. \r\nThe error returned was : \r\n{ex.Message}\r\nPlease correct the errors and try again.", nameof(requestXmlAsString), ex);
            }
        }

        /// <summary>
        /// Validates the input against a schema
        /// </summary>
        /// <param name="inputxml">An <see cref="XDocument"/> representing the request</param>
        /// <param name="schemas">The <see cref="XmlSchemaSet"/> to validate against</param>
        /// <param name="message">An <see langword="out"/> parameter containing any messages returned from the validation</param>
        /// <returns><see langword="true"/> if validate is successful, otherwise <see langword="false"/></returns>
        private static bool TryValidateSchema(XDocument inputxml, XmlSchemaSet schemas, out string message)
        {
            bool errors = false;
            string result = string.Empty;

            try
            {
                inputxml.Validate(schemas, (o, e) =>
                {
                    result += "The following messages came from validating against the schema: \r\nError in line " + e.Exception.LineNumber + ", position " + e.Exception.LinePosition + " : " + e.Exception.Message + "\r\n";
                    result += e.Severity switch
                    {
                        XmlSeverityType.Error => "ERROR: " + e.Message,
                        XmlSeverityType.Warning => "WARNING: " + e.Message,
                        _ => string.Empty
                    };

                    errors = true;
                    result += "Error mesage : " + e.Exception.Message + "\r\n";
                });
            }
            catch (Exception e)
            {
                result += "An exception of type " + e.GetType() + " was thrown, with the following message :\r\n" + e.Message + "\r\n";
            }

            message = result;
            return !errors;
        }

        /// <summary>
        /// Submits an async request to the webservice
        /// </summary>
        /// <param name="requestXmlAsString">The XML request body as <see cref="string"/></param>
        /// <returns>A <see cref="Task"/> object where the result is the response from the service formatted as an <see cref="XDocument"/></returns>
        protected virtual async Task<XDocument> SubmitRequestAsyncImpl(string requestXmlAsString)
        {
            try
            {
                RestClient client = GetHttpClient;
                RestRequest request = SetupConnectionParameters(requestXmlAsString, client);

                RestResponse response = await client.PostAsync(request);
                ValidateHttpError(response);

                return ParseToXDoc(response);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Formats the response string to an <see cref="XDocument"/>
        /// </summary>
        /// <param name="response">The response from the webservice</param>
        /// <returns>An <see cref="XDocument"/> containing the reponse</returns>
        protected virtual XDocument ParseToXDoc(RestResponse response)
        {
            ArgumentNullException.ThrowIfNull(response.Content);
            string value = response.Content;
            try
            {
                XDocument doc = XDocument.Parse(value, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
                return doc;
            }
            catch (Exception ex)
            {
                throw new Exception($"The response is invalid. \r\nThe error returned was : \r\n{ex.Message}\r\nPlease correct the errors and try again.", ex);
            }
        }

        /// <summary>
        /// Creates the request for the webservice
        /// </summary>
        /// <param name="requestXmlAsString">The XML request body as <see cref="string"/></param>
        /// <param name="client">The <see cref="RestClient"/> object to use to create the request</param>
        /// <returns>A <see cref="RestRequest"/> object</returns>
        protected virtual RestRequest SetupConnectionParameters(string requestXmlAsString, RestClient client)
        {
            // Implement throw on null when going to .NET6
            ArgumentNullException.ThrowIfNull(CustomerId);
            ArgumentNullException.ThrowIfNull(Password);

            RestRequest request = new() { Resource = URL };
            _ = request.AddHeader("Content-Type", ContentType);
            _ = request.AddHeader("Accept", "*/*");
            _ = request.AddParameter(ContentType, requestXmlAsString, ParameterType.RequestBody);
            client.Authenticator = new HttpBasicAuthenticator(CustomerId, Password);

            return request;
        }

        /// <summary>
        /// Submits a request to the webservice
        /// </summary>
        /// <param name="requestXmlAsString">The XML request body as <see cref="string"/></param>
        /// <returns>The response from the service formatted as an <see cref="XDocument"</returns>
        protected virtual XDocument SubmitRequestImpl(string requestXmlAsString)
        {
            try
            {
                RestClient client = GetHttpClient;
                RestRequest request = SetupConnectionParameters(requestXmlAsString, client);

                RestResponse response = client.Post(request);
                ValidateHttpError(response);

                return ParseToXDoc(response);
            }
            catch
            {
                throw;
            }
        }

        private static void ValidateHttpError(RestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new HttpRequestException("The request was not successful either due to network issues or server issues", null, response.StatusCode);
            if (response.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
                throw new HttpRequestException("The request is invalid formatted", null, response.StatusCode);
        }
    }
}
