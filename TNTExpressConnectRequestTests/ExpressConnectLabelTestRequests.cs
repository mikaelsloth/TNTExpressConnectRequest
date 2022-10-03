namespace TNTExpressConnectRequest.Tests
{
    using System;

    public class ExpressConnectLabelTestRequests : ExpressConnectTestRequests
    {
        public ExpressConnectLabelTestRequests() : base()
        {
            TestRequests.RemoveAt(3);
            TestRequests.RemoveAt(2);
        }

        public override string FakeDataValidationErrorRequest()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<labelRequest>\r\n" +
            "	<consignment key=\"CON1\">\r\n" +
            "		<consignmentIdentity>\r\n" +
            "			<consignmentNumber><![CDATA[123456785]]></consignmentNumber>\r\n" +
            "			<customerReference><![CDATA[CR1234567890CR1234567890]]></customerReference>\r\n" +
            "		</consignmentIdentity>\r\n" +
            "		<collectionDateTime><![CDATA[" + GetShippingDate.ToString("yyyy/MM/dd") + "T14:00:00]]></collectionDateTime>\r\n" +
            "		<sender>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Kolding]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province><![CDATA[]]></province>\r\n" +
            "			<postcode><![CDATA[7000]]></postcode>\r\n" +
            "			<country><![CDATA[DK]]></country>\r\n" +
            "		</sender>\r\n" +
            "		<delivery>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Hoofddorp]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province/>\r\n" +
            "			<postcode><![CDATA[2132 LS]]></postcode>\r\n" +
            "			<country><![CDATA[NL]]></country>\r\n" +
            "		</delivery>\r\n" +
            "		<product>\r\n" +
            "			<lineOfBusiness><![CDATA[1]]></lineOfBusiness>\r\n" +
            "			<groupId><![CDATA[0]]></groupId>\r\n" +
            "			<subGroupId><![CDATA[0]]></subGroupId>\r\n" +
            "			<id>EX</id>\r\n" +
            "			<type><![CDATA[N]]></type>\r\n" +
            "			<!--Element option is optional, maxOccurs=5-->\r\n" +
            "			<option><![CDATA[]]></option>\r\n" +
            "		</product>\r\n" +
            "		<account>\r\n" +
            "			<accountNumber><![CDATA[" + Credentials.Account + "]]></accountNumber>\r\n" +
            "			<accountCountry><![CDATA[DK]]></accountCountry>\r\n" +
            "		</account>\r\n" +
            "		<!--Element bulkShipment is optional\r\n" +
            "        <bulkShipment>\r\n" +
            "        <![CDATA[Y]]></bulkShipment>-->\r\n" +
            "		<!--Element specialInstructions is optional-->\r\n" +
            "		<specialInstructions><![CDATA[TEST DELIVERY INST]]></specialInstructions>\r\n" +
            "		<!--Element cashAmount is optional\r\n" +
            "        <cashAmount>12.34</cashAmount>-->\r\n" +
            "		<!--Element cashCurrency is optional\r\n" +
            "        <cashCurrency>GBP</cashCurrency>-->\r\n" +
            "		<!--Element cashType is optional\r\n" +
            "        <cashType>0</cashType>-->\r\n" +
            "		<!--Element customControlled is optional\r\n" +
            "        <customControlled><![CDATA[N]]></customControlled>-->\r\n" +
            "		<!--Element termsOfPayment is optional-->\r\n" +
            "		<termsOfPayment><![CDATA[S]]></termsOfPayment>\r\n" +
            "		<totalNumberOfPieces><![CDATA[1]]></totalNumberOfPieces>\r\n" +
            "		<!--Element pieceLine, maxOccurs=unbounded-->\r\n" +
            "		<pieceLine>\r\n" +
            "			<identifier><![CDATA[1]]></identifier>\r\n" +
            "			<goodsDescription>piecelinegoods desc</goodsDescription>\r\n" +
            "			<pieceMeasurements>\r\n" +
            "				<length><![CDATA[0.40]]></length>\r\n" +
            "				<width><![CDATA[0.20]]></width>\r\n" +
            "				<height><![CDATA[0.20]]></height>\r\n" +
            "				<weight><![CDATA[12.60]]></weight>\r\n" +
            "			</pieceMeasurements>\r\n" +
            "			<!--Element pieces, maxOccurs=unbounded-->\r\n" +
            "			<pieces>\r\n" +
            "				<!--Element sequenceNumbers, maxOccurs=unbounded-->\r\n" +
            "				<sequenceNumbers><![CDATA[1]]></sequenceNumbers>\r\n" +
            "				<pieceReference><![CDATA[]]></pieceReference>\r\n" +
            "			</pieces>\r\n" +
            "		</pieceLine>\r\n" +
            "	</consignment>\r\n" +
            "</labelRequest>";
        }

        public override string FakeInvalidCredentialsRequest() => FakeSuccessfullRequest();

        public override string FakeInvalidFormatRequest()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<labelRequest>\r\n" +
            "	<consignment key=\"CON1\">\r\n" +
            "		<consignmentIdentity>\r\n" +
            "			<consignmentNumber><![CDATA[123456785]]></consignmentNumber>\r\n" +
            "			<customerReference><![CDATA[CR1234567890CR1234567890]]></customerReference>\r\n" +
            "		</consignmentIdentity>\r\n" +
            "		<collectionDateTime><![CDATA[" + GetShippingDate.ToString("yyyy/MM/dd") + "]]></collectionDateTime>\r\n" +
            "		<sender>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Kolding]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province><![CDATA[]]></province>\r\n" +
            "			<postcode><![CDATA[6000]]></postcode>\r\n" +
            "			<country><![CDATA[DK]]></country>\r\n" +
            "		</sender>\r\n" +
            "		<delivery>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Hoofddorp]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province/>\r\n" +
            "			<postcode><![CDATA[2132 LS]]></postcode>\r\n" +
            "			<country><![CDATA[NL]]></country>\r\n" +
            "		</delivery>\r\n" +
            "		<product>\r\n" +
            "			<lineOfBusiness><![CDATA[2]]></lineOfBusiness>\r\n" +
            "			<groupId><![CDATA[0]]></groupId>\r\n" +
            "			<subGroupId><![CDATA[0]]></subGroupId>\r\n" +
            "			<id>EX</id>\r\n" +
            "			<type><![CDATA[N]]></type>\r\n" +
            "			<!--Element option is optional, maxOccurs=5-->\r\n" +
            "			<option><![CDATA[]]></option>\r\n" +
            "		</product>\r\n" +
            "		<account>\r\n" +
            "			<accountNumber><![CDATA[" + Credentials.Account + "]]></accountNumber>\r\n" +
            "			<accountCountry><![CDATA[DK]]></accountCountry>\r\n" +
            "		</account>\r\n" +
            "		<!--Element bulkShipment is optional\r\n" +
            "        <bulkShipment>\r\n" +
            "        <![CDATA[Y]]></bulkShipment>-->\r\n" +
            "		<!--Element specialInstructions is optional-->\r\n" +
            "		<specialInstructions><![CDATA[TEST DELIVERY INST]]></specialInstructions>\r\n" +
            "		<!--Element cashAmount is optional\r\n" +
            "        <cashAmount>12.34</cashAmount>-->\r\n" +
            "		<!--Element cashCurrency is optional\r\n" +
            "        <cashCurrency>GBP</cashCurrency>-->\r\n" +
            "		<!--Element cashType is optional\r\n" +
            "        <cashType>0</cashType>-->\r\n" +
            "		<!--Element customControlled is optional\r\n" +
            "        <customControlled><![CDATA[N]]></customControlled>-->\r\n" +
            "		<!--Element termsOfPayment is optional-->\r\n" +
            "		<termsOfPayment><![CDATA[S]]></termsOfPayment>\r\n" +
            "		<totalNumberOfPieces><![CDATA[1]]></totalNumberOfPieces>\r\n" +
            "		<!--Element pieceLine, maxOccurs=unbounded-->\r\n" +
            "		<pieceLine>\r\n" +
            "			<identifier><![CDATA[1]]></identifier>\r\n" +
            "			<goodsDescription>piecelinegoods desc</goodsDescription>\r\n" +
            "			<pieceMeasurements>\r\n" +
            "				<length><![CDATA[0.40]]></length>\r\n" +
            "				<width><![CDATA[0.20]]></width>\r\n" +
            "				<height><![CDATA[0.20]]></height>\r\n" +
            "				<weight><![CDATA[12.60]]></weight>\r\n" +
            "			</pieceMeasurements>\r\n" +
            "			<!--Element pieces, maxOccurs=unbounded-->\r\n" +
            "			<pieces>\r\n" +
            "				<!--Element sequenceNumbers, maxOccurs=unbounded-->\r\n" +
            "				<sequenceNumbers><![CDATA[1]]></sequenceNumbers>\r\n" +
            "				<pieceReference><![CDATA[]]></pieceReference>\r\n" +
            "			</pieces>\r\n" +
            "		</pieceLine>\r\n" +
            "	</consignment>\r\n" +
            "</labelRequest>";
        }

        public override string FakeSuccessfullRequest()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<labelRequest>\r\n" +
            "	<consignment key=\"CON1\">\r\n" +
            "		<consignmentIdentity>\r\n" +
            "			<consignmentNumber><![CDATA[123456785]]></consignmentNumber>\r\n" +
            "			<customerReference><![CDATA[CR1234567890CR1234567890]]></customerReference>\r\n" +
            "		</consignmentIdentity>\r\n" +
            "		<collectionDateTime><![CDATA[" + GetShippingDate.ToString("yyyy/MM/dd") + "T14:00:00]]></collectionDateTime>\r\n" +
            "		<sender>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Kolding]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province><![CDATA[]]></province>\r\n" +
            "			<postcode><![CDATA[6000]]></postcode>\r\n" +
            "			<country><![CDATA[DK]]></country>\r\n" +
            "		</sender>\r\n" +
            "		<delivery>\r\n" +
            "			<name><![CDATA[----------]]></name>\r\n" +
            "			<addressLine1><![CDATA[----------]]></addressLine1>\r\n" +
            "			<addressLine2><![CDATA[Testlinie 2]]></addressLine2>\r\n" +
            "			<addressLine3><![CDATA[Testlinie 3]]></addressLine3>\r\n" +
            "			<town><![CDATA[Hoofddorp]]></town>\r\n" +
            "			<exactMatch><![CDATA[Y]]></exactMatch>\r\n" +
            "			<province/>\r\n" +
            "			<postcode><![CDATA[2132 LS]]></postcode>\r\n" +
            "			<country><![CDATA[NL]]></country>\r\n" +
            "		</delivery>\r\n" +
            "		<product>\r\n" +
            "			<lineOfBusiness><![CDATA[2]]></lineOfBusiness>\r\n" +
            "			<groupId><![CDATA[0]]></groupId>\r\n" +
            "			<subGroupId><![CDATA[0]]></subGroupId>\r\n" +
            "			<id>EX</id>\r\n" +
            "			<type><![CDATA[N]]></type>\r\n" +
            "			<!--Element option is optional, maxOccurs=5-->\r\n" +
            "			<option><![CDATA[]]></option>\r\n" +
            "		</product>\r\n" +
            "		<account>\r\n" +
            "			<accountNumber><![CDATA[" + Credentials.Account + "]]></accountNumber>\r\n" +
            "			<accountCountry><![CDATA[DK]]></accountCountry>\r\n" +
            "		</account>\r\n" +
            "		<!--Element bulkShipment is optional\r\n" +
            "        <bulkShipment>\r\n" +
            "        <![CDATA[Y]]></bulkShipment>-->\r\n" +
            "		<!--Element specialInstructions is optional-->\r\n" +
            "		<specialInstructions><![CDATA[TEST DELIVERY INST]]></specialInstructions>\r\n" +
            "		<!--Element cashAmount is optional\r\n" +
            "        <cashAmount>12.34</cashAmount>-->\r\n" +
            "		<!--Element cashCurrency is optional\r\n" +
            "        <cashCurrency>GBP</cashCurrency>-->\r\n" +
            "		<!--Element cashType is optional\r\n" +
            "        <cashType>0</cashType>-->\r\n" +
            "		<!--Element customControlled is optional\r\n" +
            "        <customControlled><![CDATA[N]]></customControlled>-->\r\n" +
            "		<!--Element termsOfPayment is optional-->\r\n" +
            "		<termsOfPayment><![CDATA[S]]></termsOfPayment>\r\n" +
            "		<totalNumberOfPieces><![CDATA[1]]></totalNumberOfPieces>\r\n" +
            "		<!--Element pieceLine, maxOccurs=unbounded-->\r\n" +
            "		<pieceLine>\r\n" +
            "			<identifier><![CDATA[1]]></identifier>\r\n" +
            "			<goodsDescription>piecelinegoods desc</goodsDescription>\r\n" +
            "			<pieceMeasurements>\r\n" +
            "				<length><![CDATA[0.40]]></length>\r\n" +
            "				<width><![CDATA[0.20]]></width>\r\n" +
            "				<height><![CDATA[0.20]]></height>\r\n" +
            "				<weight><![CDATA[12.60]]></weight>\r\n" +
            "			</pieceMeasurements>\r\n" +
            "			<!--Element pieces, maxOccurs=unbounded-->\r\n" +
            "			<pieces>\r\n" +
            "				<!--Element sequenceNumbers, maxOccurs=unbounded-->\r\n" +
            "				<sequenceNumbers><![CDATA[1]]></sequenceNumbers>\r\n" +
            "				<pieceReference><![CDATA[]]></pieceReference>\r\n" +
            "			</pieces>\r\n" +
            "		</pieceLine>\r\n" +
            "	</consignment>\r\n" +
            "</labelRequest>";
        }
    }
}
