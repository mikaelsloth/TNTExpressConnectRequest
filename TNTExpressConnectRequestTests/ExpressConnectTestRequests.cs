namespace TNTExpressConnectRequest.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public abstract class ExpressConnectTestRequests : IEnumerable<object[]>
    {
        protected readonly List<object[]> TestRequests;

        public ExpressConnectTestRequests()
        {
            Credentials = ExpressConnectCredentials.Instance;
            TestRequests = new List<object[]>()
            {
                new object[] { FakeSuccessfullRequest() },
                new object[] { FakeDataValidationErrorRequest() },
                new object[] { FakeInvalidCredentialsRequest() },
                new object[] { FakeInvalidFormatRequest() }
            };
        }

        internal ExpressConnectCredentials Credentials { get; }

        internal static DateTime GetShippingDate
        {
            get
            {
                DateTime date = DateTime.Now;
                while (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                {
                    _ = date.AddDays(1);
                }

                return date;
            }
        }

        public static XDocument ConvertStringToXDocument(string requestXmlAsString)
        {
            try
            {
                return XDocument.Parse(requestXmlAsString, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
            }
            catch
            {
                throw;
            }
        }

        public abstract string FakeDataValidationErrorRequest();
        public abstract string FakeInvalidCredentialsRequest();
        public abstract string FakeInvalidFormatRequest();
        public abstract string FakeSuccessfullRequest();

        public virtual IEnumerator<object[]> GetEnumerator() => TestRequests.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}