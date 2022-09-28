namespace TNTExpressConnectRequest.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class ExpressConnectShippingTestRequests : ExpressConnectTestRequests
    {
        public ExpressConnectShippingTestRequests() : base()
        {
        }

        public static IEnumerable<object[]> GetFailingRequests()
        {
            yield return new object[] { nameof(FakeDataValidationErrorRequest) };
            yield return new object[] { nameof(FakeInvalidCredentialsRequest) };
            yield return new object[] { nameof(FakeInvalidFormatRequest) };
        }

        public override string FakeSuccessfullRequest()
        {
            return "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<ESHIPPER>\r\n" +
            "	<LOGIN>\r\n" +
            "		<COMPANY>" + Credentials.Username + "</COMPANY>\r\n" +
            "		<PASSWORD>" + Credentials.Password + "</PASSWORD>\r\n" +
            "		<APPID>EC</APPID>\r\n" +
            "		<APPVERSION>3.1</APPVERSION>\r\n" +
            "	</LOGIN>\r\n" +
            "	<CONSIGNMENTBATCH>\r\n" +
            "		<SENDER>\r\n" +
            "			<COMPANYNAME><![CDATA[Sender TEST DO NOT COLLECT Company]]></COMPANYNAME>\r\n" +
            "			<STREETADDRESS1><![CDATA[TNT Express]]></STREETADDRESS1>\r\n" +
            "			<STREETADDRESS2><![CDATA[TNT House]]></STREETADDRESS2>\r\n" +
            "			<STREETADDRESS3><![CDATA[Holly Lane]]></STREETADDRESS3>\r\n" +
            "			<CITY><![CDATA[Kolding]]></CITY>\r\n" +
            "			<PROVINCE><![CDATA[]]></PROVINCE>\r\n" +
            "			<POSTCODE><![CDATA[6000]]></POSTCODE>\r\n" +
            "			<COUNTRY><![CDATA[DK]]></COUNTRY>\r\n" +
            "			<ACCOUNT><![CDATA[" + Credentials.Account + "]]></ACCOUNT>\r\n" +
            "			<VAT><![CDATA[SE12345678]]></VAT>\r\n" +
            "			<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "			<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "			<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "			<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "			<COLLECTION>\r\n" +
            "				<SHIPDATE><![CDATA[" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/') + "]]></SHIPDATE>\r\n" +
            "				<PREFCOLLECTTIME>\r\n" +
            "					<FROM><![CDATA[09:00]]></FROM>\r\n" +
            "					<TO><![CDATA[16:00]]></TO>\r\n" +
            "				</PREFCOLLECTTIME>\r\n" +
            "				<COLLINSTRUCTIONS />\r\n" +
            "			</COLLECTION>\r\n" +
            "		</SENDER>\r\n" +
            "		<CONSIGNMENT>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			<DETAILS>\r\n" +
            "				<RECEIVER>\r\n" +
            "					<COMPANYNAME><![CDATA[Receiver Company Name]]></COMPANYNAME>\r\n" +
            "					<STREETADDRESS1><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS1>\r\n" +
            "					<STREETADDRESS2><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS2>\r\n" +
            "					<STREETADDRESS3><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS3>\r\n" +
            "					<CITY><![CDATA[Hoofddorp]]></CITY>\r\n" +
            "					<PROVINCE />\r\n" +
            "					<POSTCODE><![CDATA[2132 LS]]></POSTCODE>\r\n" +
            "					<COUNTRY><![CDATA[NL]]></COUNTRY>\r\n" +
            "					<VAT />\r\n" +
            "					<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "					<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "					<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "					<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "				</RECEIVER>\r\n" +
            "				<CUSTOMERREF><![CDATA[Customer shipping ref]]></CUSTOMERREF>\r\n" +
            "				<CONTYPE><![CDATA[N]]></CONTYPE>\r\n" +
            "				<PAYMENTIND><![CDATA[S]]></PAYMENTIND>\r\n" +
            "				<ITEMS><![CDATA[3]]></ITEMS>\r\n" +
            "				<TOTALWEIGHT><![CDATA[1.8]]></TOTALWEIGHT>\r\n" +
            "				<TOTALVOLUME><![CDATA[0.027]]></TOTALVOLUME>\r\n" +
            "				<CURRENCY><![CDATA[EUR]]></CURRENCY>\r\n" +
            "				<GOODSVALUE><![CDATA[180.00]]></GOODSVALUE>\r\n" +
            "				<INSURANCEVALUE><![CDATA[]]></INSURANCEVALUE>\r\n" +
            "				<INSURANCECURRENCY><![CDATA[]]></INSURANCECURRENCY>\r\n" +
            "				<DIVISION><![CDATA[G]]></DIVISION>\r\n" +
            "				<SERVICE><![CDATA[15N]]></SERVICE>\r\n" +
            "				<OPTION><![CDATA[]]></OPTION>\r\n" +
            "				<DESCRIPTION><![CDATA[assorted office accessories]]></DESCRIPTION>\r\n" +
            "				<DELIVERYINST><![CDATA[Please pass to reception window - 3rd on the left]]></DELIVERYINST>\r\n" +
            "				<HAZARDOUS><![CDATA[N]]></HAZARDOUS>\r\n" +
            "				<UNNUMBER />\r\n" +
            "				<PACKINGGROUP />\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 1]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 2]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.2]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 3]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.3]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "			</DETAILS>\r\n" +
            "		</CONSIGNMENT>\r\n" +
            "	</CONSIGNMENTBATCH>\r\n" +
            "	<ACTIVITY>\r\n" +
            "		<CREATE>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</CREATE>\r\n" +
            "		<SHIP>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</SHIP>\r\n" +
            "		<PRINT>\r\n" +
            "			<CONNOTE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</CONNOTE>\r\n" +
            "			<MANIFEST>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</MANIFEST>\r\n" +
            "			<INVOICE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</INVOICE>\r\n" +
            "		</PRINT>\r\n" +
            "	</ACTIVITY>\r\n" +
            "</ESHIPPER>";
        }

        public override string FakeDataValidationErrorRequest()
        {
            return "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<ESHIPPER>\r\n" +
            "	<LOGIN>\r\n" +
            "		<COMPANY>" + Credentials.Username + "</COMPANY>\r\n" +
            "		<PASSWORD>" + Credentials.Password + "</PASSWORD>\r\n" +
            "		<APPID>EC</APPID>\r\n" +
            "		<APPVERSION>3.1</APPVERSION>\r\n" +
            "	</LOGIN>\r\n" +
            "	<CONSIGNMENTBATCH>\r\n" +
            "		<SENDER>\r\n" +
            "			<COMPANYNAME><![CDATA[Sender TEST DO NOT COLLECT Company]]></COMPANYNAME>\r\n" +
            "			<STREETADDRESS1><![CDATA[TNT Express]]></STREETADDRESS1>\r\n" +
            "			<STREETADDRESS2><![CDATA[TNT House]]></STREETADDRESS2>\r\n" +
            "			<STREETADDRESS3><![CDATA[Holly Lane]]></STREETADDRESS3>\r\n" +
            "			<CITY><![CDATA[Kolding]]></CITY>\r\n" +
            "			<PROVINCE><![CDATA[]]></PROVINCE>\r\n" +
            "			<POSTCODE><![CDATA[7000]]></POSTCODE>\r\n" +
            "			<COUNTRY><![CDATA[DK]]></COUNTRY>\r\n" +
            "			<ACCOUNT><![CDATA[" + Credentials.Account + "]]></ACCOUNT>\r\n" +
            "			<VAT><![CDATA[SE12345678]]></VAT>\r\n" +
            "			<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "			<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "			<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "			<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "			<COLLECTION>\r\n" +
            "				<SHIPDATE><![CDATA[" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/') + "]]></SHIPDATE>\r\n" +
            "				<PREFCOLLECTTIME>\r\n" +
            "					<FROM><![CDATA[09:00]]></FROM>\r\n" +
            "					<TO><![CDATA[16:00]]></TO>\r\n" +
            "				</PREFCOLLECTTIME>\r\n" +
            "				<COLLINSTRUCTIONS />\r\n" +
            "			</COLLECTION>\r\n" +
            "		</SENDER>\r\n" +
            "		<CONSIGNMENT>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			<DETAILS>\r\n" +
            "				<RECEIVER>\r\n" +
            "					<COMPANYNAME><![CDATA[Receiver Company Name]]></COMPANYNAME>\r\n" +
            "					<STREETADDRESS1><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS1>\r\n" +
            "					<STREETADDRESS2><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS2>\r\n" +
            "					<STREETADDRESS3><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS3>\r\n" +
            "					<CITY><![CDATA[Hoofddorp]]></CITY>\r\n" +
            "					<PROVINCE />\r\n" +
            "					<POSTCODE><![CDATA[2132 LS]]></POSTCODE>\r\n" +
            "					<COUNTRY><![CDATA[NL]]></COUNTRY>\r\n" +
            "					<VAT />\r\n" +
            "					<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "					<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "					<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "					<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "				</RECEIVER>\r\n" +
            "				<CUSTOMERREF><![CDATA[Customer shipping ref]]></CUSTOMERREF>\r\n" +
            "				<CONTYPE><![CDATA[N]]></CONTYPE>\r\n" +
            "				<PAYMENTIND><![CDATA[S]]></PAYMENTIND>\r\n" +
            "				<ITEMS><![CDATA[3]]></ITEMS>\r\n" +
            "				<TOTALWEIGHT><![CDATA[1.8]]></TOTALWEIGHT>\r\n" +
            "				<TOTALVOLUME><![CDATA[0.027]]></TOTALVOLUME>\r\n" +
            "				<CURRENCY><![CDATA[EUR]]></CURRENCY>\r\n" +
            "				<GOODSVALUE><![CDATA[180.00]]></GOODSVALUE>\r\n" +
            "				<INSURANCEVALUE><![CDATA[]]></INSURANCEVALUE>\r\n" +
            "				<INSURANCECURRENCY><![CDATA[]]></INSURANCECURRENCY>\r\n" +
            "				<DIVISION><![CDATA[G]]></DIVISION>\r\n" +
            "				<SERVICE><![CDATA[15N]]></SERVICE>\r\n" +
            "				<OPTION><![CDATA[]]></OPTION>\r\n" +
            "				<DESCRIPTION><![CDATA[assorted office accessories]]></DESCRIPTION>\r\n" +
            "				<DELIVERYINST><![CDATA[Please pass to reception window - 3rd on the left]]></DELIVERYINST>\r\n" +
            "				<HAZARDOUS><![CDATA[N]]></HAZARDOUS>\r\n" +
            "				<UNNUMBER />\r\n" +
            "				<PACKINGGROUP />\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 1]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 2]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.2]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 3]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.3]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "			</DETAILS>\r\n" +
            "		</CONSIGNMENT>\r\n" +
            "	</CONSIGNMENTBATCH>\r\n" +
            "	<ACTIVITY>\r\n" +
            "		<CREATE>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</CREATE>\r\n" +
            "		<SHIP>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</SHIP>\r\n" +
            "		<PRINT>\r\n" +
            "			<CONNOTE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</CONNOTE>\r\n" +
            "			<MANIFEST>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</MANIFEST>\r\n" +
            "			<INVOICE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</INVOICE>\r\n" +
            "		</PRINT>\r\n" +
            "	</ACTIVITY>\r\n" +
            "</ESHIPPER>";
        }

        public override string FakeInvalidCredentialsRequest()
        {
            return "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<ESHIPPER>\r\n" +
            "	<LOGIN>\r\n" +
            "		<COMPANY>" + Credentials.Username + "_ZZZ" + "</COMPANY>\r\n" +
            "		<PASSWORD>" + Credentials.Password + "_ZZZ" + "</PASSWORD>\r\n" +
            "		<APPID>EC</APPID>\r\n" +
            "		<APPVERSION>3.1</APPVERSION>\r\n" +
            "	</LOGIN>\r\n" +
            "	<CONSIGNMENTBATCH>\r\n" +
            "		<SENDER>\r\n" +
            "			<COMPANYNAME><![CDATA[Sender TEST DO NOT COLLECT Company]]></COMPANYNAME>\r\n" +
            "			<STREETADDRESS1><![CDATA[TNT Express]]></STREETADDRESS1>\r\n" +
            "			<STREETADDRESS2><![CDATA[TNT House]]></STREETADDRESS2>\r\n" +
            "			<STREETADDRESS3><![CDATA[Holly Lane]]></STREETADDRESS3>\r\n" +
            "			<CITY><![CDATA[Kolding]]></CITY>\r\n" +
            "			<PROVINCE><![CDATA[]]></PROVINCE>\r\n" +
            "			<POSTCODE><![CDATA[6000]]></POSTCODE>\r\n" +
            "			<COUNTRY><![CDATA[DK]]></COUNTRY>\r\n" +
            "			<ACCOUNT><![CDATA[" + Credentials.Account + "]]></ACCOUNT>\r\n" +
            "			<VAT><![CDATA[SE12345678]]></VAT>\r\n" +
            "			<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "			<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "			<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "			<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "			<COLLECTION>\r\n" +
            "				<SHIPDATE><![CDATA[" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/') + "]]></SHIPDATE>\r\n" +
            "				<PREFCOLLECTTIME>\r\n" +
            "					<FROM><![CDATA[09:00]]></FROM>\r\n" +
            "					<TO><![CDATA[16:00]]></TO>\r\n" +
            "				</PREFCOLLECTTIME>\r\n" +
            "				<COLLINSTRUCTIONS />\r\n" +
            "			</COLLECTION>\r\n" +
            "		</SENDER>\r\n" +
            "		<CONSIGNMENT>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			<DETAILS>\r\n" +
            "				<RECEIVER>\r\n" +
            "					<COMPANYNAME><![CDATA[Receiver Company Name]]></COMPANYNAME>\r\n" +
            "					<STREETADDRESS1><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS1>\r\n" +
            "					<STREETADDRESS2><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS2>\r\n" +
            "					<STREETADDRESS3><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS3>\r\n" +
            "					<CITY><![CDATA[Hoofddorp]]></CITY>\r\n" +
            "					<PROVINCE />\r\n" +
            "					<POSTCODE><![CDATA[2132 LS]]></POSTCODE>\r\n" +
            "					<COUNTRY><![CDATA[NL]]></COUNTRY>\r\n" +
            "					<VAT />\r\n" +
            "					<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "					<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "					<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "					<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "				</RECEIVER>\r\n" +
            "				<CUSTOMERREF><![CDATA[Customer shipping ref]]></CUSTOMERREF>\r\n" +
            "				<CONTYPE><![CDATA[N]]></CONTYPE>\r\n" +
            "				<PAYMENTIND><![CDATA[S]]></PAYMENTIND>\r\n" +
            "				<ITEMS><![CDATA[3]]></ITEMS>\r\n" +
            "				<TOTALWEIGHT><![CDATA[1.8]]></TOTALWEIGHT>\r\n" +
            "				<TOTALVOLUME><![CDATA[0.027]]></TOTALVOLUME>\r\n" +
            "				<CURRENCY><![CDATA[EUR]]></CURRENCY>\r\n" +
            "				<GOODSVALUE><![CDATA[180.00]]></GOODSVALUE>\r\n" +
            "				<INSURANCEVALUE><![CDATA[]]></INSURANCEVALUE>\r\n" +
            "				<INSURANCECURRENCY><![CDATA[]]></INSURANCECURRENCY>\r\n" +
            "				<DIVISION><![CDATA[G]]></DIVISION>\r\n" +
            "				<SERVICE><![CDATA[15N]]></SERVICE>\r\n" +
            "				<OPTION><![CDATA[]]></OPTION>\r\n" +
            "				<DESCRIPTION><![CDATA[assorted office accessories]]></DESCRIPTION>\r\n" +
            "				<DELIVERYINST><![CDATA[Please pass to reception window - 3rd on the left]]></DELIVERYINST>\r\n" +
            "				<HAZARDOUS><![CDATA[N]]></HAZARDOUS>\r\n" +
            "				<UNNUMBER />\r\n" +
            "				<PACKINGGROUP />\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 1]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 2]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.2]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 3]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.3]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "			</DETAILS>\r\n" +
            "		</CONSIGNMENT>\r\n" +
            "	</CONSIGNMENTBATCH>\r\n" +
            "	<ACTIVITY>\r\n" +
            "		<CREATE>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</CREATE>\r\n" +
            "		<SHIP>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</SHIP>\r\n" +
            "		<PRINT>\r\n" +
            "			<CONNOTE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</CONNOTE>\r\n" +
            "			<MANIFEST>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</MANIFEST>\r\n" +
            "			<INVOICE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</INVOICE>\r\n" +
            "		</PRINT>\r\n" +
            "	</ACTIVITY>\r\n" +
            "</ESHIPPER>";
        }

        public override string FakeInvalidFormatRequest()
        {
            return "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<ESHIPPER>\r\n" +
            "	<LOGIN>\r\n" +
            "		<COMPANY>" + Credentials.Username + "</COMPANY>\r\n" +
            "		<PASSWORD>" + Credentials.Password + "</PASSWORD>\r\n" +
            "		<APPID>EC</APPID>\r\n" +
            "		<APPVERSION>3.1</APPVERSION>\r\n" +
            "	</LOGIN>\r\n" +
            "	<CONSIGNMENTBATCH>\r\n" +
            "		<SENDER>\r\n" +
            "			<COMPANYNAME><![CDATA[Sender TEST DO NOT COLLECT Company]]></COMPANYNAME>\r\n" +
            "			<STREETADDRESS1><![CDATA[TNT Express]]></STREETADDRESS1>\r\n" +
            "			<STREETADDRESS2><![CDATA[TNT House]]></STREETADDRESS2>\r\n" +
            "			<STREETADDRESS3><![CDATA[Holly Lane]]></STREETADDRESS3>\r\n" +
            "			<CITY><![CDATA[Kolding]]></CITY>\r\n" +
            "			<PROVINCE><![CDATA[]]></PROVINCE>\r\n" +
            "			<POSTCODE><![CDATA[6000]]></POSTCODE>\r\n" +
            "			<COUNTRY><![CDATA[DK]]></COUNTRY>\r\n" +
            "			<ACCOUNT><![CDATA[" + Credentials.Account + "]]></ACCOUNT>\r\n" +
            "			<VAT><![CDATA[SE12345678]]></VAT>\r\n" +
            "			<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "			<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "			<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "			<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "			<COLLECTION>\r\n" +
            "				<SHIPDATE><![CDATA[" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/').Replace('-', '/') + "]]></SHIPDATE>\r\n" +
            "				<PREFCOLLECTTIME>\r\n" +
            "					<FROM><![CDATA[09:00]]></FROM>\r\n" +
            "					<TO><![CDATA[16:00]]></TO>\r\n" +
            "				</PREFCOLLECTTIME>\r\n" +
            "				<COLLINSTRUCTIONS />\r\n" +
            "			</COLLECTION>\r\n" +
            "		</SENDER>\r\n" +
            "		<CONSIGNMENT>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			<DETAILS>\r\n" +
            "				<RECEIVER>\r\n" +
            "					<COMPANYNAME><![CDATA[Receiver Company Name]]></COMPANYNAME>\r\n" +
            "					<STREETADDRESS1><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS1>\r\n" +
            "					<STREETADDRESS2><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS2>\r\n" +
            "					<STREETADDRESS3><![CDATA[TEST DO NOT COLLECT]]></STREETADDRESS3>\r\n" +
            "					<CITY><![CDATA[Hoofddorp]]></CITY>\r\n" +
            "					<PROVINCE />\r\n" +
            "					<POSTCODE><![CDATA[2132 LS]]></POSTCODE>\r\n" +
            "					<COUNTRY><![CDATA[NL]]></COUNTRY>\r\n" +
            "					<VAT />\r\n" +
            "					<CONTACTNAME><![CDATA[Mr Contact]]></CONTACTNAME>\r\n" +
            "					<CONTACTDIALCODE><![CDATA[01827]]></CONTACTDIALCODE>\r\n" +
            "					<CONTACTTELEPHONE><![CDATA[717733]]></CONTACTTELEPHONE>\r\n" +
            "					<CONTACTEMAIL><![CDATA[contact@tnt.com]]></CONTACTEMAIL>\r\n" +
            "				</RECEIVER>\r\n" +
            "				<CUSTOMERREF><![CDATA[Customer shipping ref]]></CUSTOMERREF>\r\n" +
            "				<CONTYPE><![CDATA[N]]></CONTYPE>\r\n" +
            "				<PAYMENTIND><![CDATA[S]]></PAYMENTIND>\r\n" +
            "				<ITEMS><![CDATA[3]]></ITEMS>\r\n" +
            "				<TOTALWEIGHT><![CDATA[1.8]]></TOTALWEIGHT>\r\n" +
            "				<TOTALVOLUME><![CDATA[0.027]]></TOTALVOLUME>\r\n" +
            "				<CURRENCY><![CDATA[EUR]]></CURRENCY>\r\n" +
            "				<GOODSVALUE><![CDATA[180.00]]></GOODSVALUE>\r\n" +
            "				<INSURANCEVALUE><![CDATA[]]></INSURANCEVALUE>\r\n" +
            "				<INSURANCECURRENCY><![CDATA[]]></INSURANCECURRENCY>\r\n" +
            "				<DIVISION><![CDATA[G]]></DIVISION>\r\n" +
            "				<OPTION><![CDATA[]]></OPTION>\r\n" +
            "				<DESCRIPTION><![CDATA[assorted office accessories]]></DESCRIPTION>\r\n" +
            "				<DELIVERYINST><![CDATA[Please pass to reception window - 3rd on the left]]></DELIVERYINST>\r\n" +
            "				<HAZARDOUS><![CDATA[N]]></HAZARDOUS>\r\n" +
            "				<UNNUMBER />\r\n" +
            "				<SERVICE><![CDATA[15N]]></SERVICE>\r\n" +
            "				<PACKINGGROUP />\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 1]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 2]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.2]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.2]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "				<PACKAGE>\r\n" +
            "					<ITEMS><![CDATA[1]]></ITEMS>\r\n" +
            "					<DESCRIPTION><![CDATA[box 3]]></DESCRIPTION>\r\n" +
            "					<LENGTH><![CDATA[0.1]]></LENGTH>\r\n" +
            "					<HEIGHT><![CDATA[0.3]]></HEIGHT>\r\n" +
            "					<WIDTH><![CDATA[0.3]]></WIDTH>\r\n" +
            "					<WEIGHT><![CDATA[0.6]]></WEIGHT>\r\n" +
            "				</PACKAGE>\r\n" +
            "			</DETAILS>\r\n" +
            "		</CONSIGNMENT>\r\n" +
            "	</CONSIGNMENTBATCH>\r\n" +
            "	<ACTIVITY>\r\n" +
            "		<CREATE>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</CREATE>\r\n" +
            "		<SHIP>\r\n" +
            "			<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "		</SHIP>\r\n" +
            "		<PRINT>\r\n" +
            "			<CONNOTE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</CONNOTE>\r\n" +
            "			<MANIFEST>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</MANIFEST>\r\n" +
            "			<INVOICE>\r\n" +
            "				<CONREF><![CDATA[TESTREF1]]></CONREF>\r\n" +
            "			</INVOICE>\r\n" +
            "		</PRINT>\r\n" +
            "	</ACTIVITY>\r\n" +
            "</ESHIPPER>";
        }
    }
}
