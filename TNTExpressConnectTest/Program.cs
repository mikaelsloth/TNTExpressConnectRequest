// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using TNTExpressConnectRequest.Tests;

ExpressConnectShippingTests request = new();
string content = new ExpressConnectShippingTestRequests().FakeInvalidCredentialsRequest();

//string input = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><document><CREATE><CONREF>TESTREF1</CONREF><CONNUMBER>GE986049714DK</CONNUMBER><SUCCESS>Y</SUCCESS></CREATE><TRANSITTIMES><estimatedTimeOfArrival>2022-09-28T18:00:00</estimatedTimeOfArrival><PickupDate>2022-09-27T00:00:00</PickupDate><serviceCallCutOffTimes><callCutOffDateAndTime>2022-09-27T16:45:00</callCutOffDateAndTime><icaStartDateAndTime>2022-09-27T10:00:00</icaStartDateAndTime><icaEndDateAndTime>2022-09-27T18:15:00</icaEndDateAndTime></serviceCallCutOffTimes></TRANSITTIMES><SHIP><CONSIGNMENT><CONREF>TESTREF1</CONREF><CONNUMBER>GE986049714DK</CONNUMBER><SUCCESS>Y</SUCCESS></CONSIGNMENT></SHIP><PRINT><CONNOTE>CREATED</CONNOTE><MANIFEST>CREATED</MANIFEST><INVOICE>CREATED</INVOICE></PRINT></document>";
//XDocument doc = XDocument.Parse(input);
//XElement? create = doc.Root?.Element("CREATE");
//Console.WriteLine(create == null ? "not found" : create.ToString());

try
{
    await request.A01_SubmitShippingRequestAsync_XDocument(content, nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest));
    await request.A230_GetResultAsync_InvalidCredentials();
}
catch { Console.WriteLine("errors happened"); }

