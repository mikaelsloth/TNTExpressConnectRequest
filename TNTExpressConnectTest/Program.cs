// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TNTExpressConnectShipment;

Login login = new()
{
    APPID = "EC",
    APPVERSION = "3.1",
    COMPANY = "",
    PASSWORD = ""
};

PrefCollectTime time = new()
{
    FROM = "12:00",
    TO = "16:00"
};

Collection collection = new()
{
    SHIPDATE = DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/'),
    PREFCOLLECTTIME = time
};

SenderAddress sender = new()
{
    ACCOUNT = "100022094",
    CITY = "Kolding",
    COMPANYNAME = "Test",
    CONTACTDIALCODE = "+45",
    CONTACTTELEPHONE = "23684664",
    CONTACTNAME = "Test",
    COUNTRY = "DK",
    POSTCODE = "6000",
    STREETADDRESS1 = "Test",
    COLLECTION = collection
};

ReceiverAddress receiver = new()
{
    CITY = "Stockholm",
    COMPANYNAME = "Test",
    CONTACTDIALCODE = "+46",
    CONTACTNAME = "Test",
    CONTACTTELEPHONE = "123456789",
    COUNTRY = "SE",
    POSTCODE = "10012",
    STREETADDRESS1 = "Test"
};

Package pack = new()
{
    DESCRIPTION = "Test",
    HEIGHT = 0.25m,
    ITEMS = 1,
    LENGTH = 0.40m,
    WEIGHT = 5.000m,
    WIDTH = 0.30m
};

Package[] packages = new Package[] { pack };

Details details = new()
{
    CONTYPE = "N",
    CURRENCY = "DKK",
    CUSTOMERREF = "testing",
    DELIVERYINST = string.Empty,
    DESCRIPTION = "Goods",
    DIVISION = "G",
    GOODSVALUE = 100.00m,
    ITEMS = packages.Sum(p => p.ITEMS),
    PACKAGE = packages,
    PAYMENTIND = "S",
    RECEIVER = receiver,
    SERVICE = "15N",
    TOTALVOLUME = Math.Round(packages.Sum(p => p.WIDTH * p.HEIGHT * p.LENGTH), 3, MidpointRounding.AwayFromZero),
    TOTALWEIGHT = packages.Sum(p => p.WEIGHT)
};

string conref = Convert.ToBase64String(Guid.NewGuid().ToByteArray())[2..22];

Consignment con = new()
{
    CONREF = conref,
    Item = details
};

ConsignmentBatch batch = new()
{
    CONSIGNMENT = new Consignment[] { con },
    SENDER = sender
};

string[] items = new string[] { conref };

BookActivity book = new()
{
    ShowBookingRef = true,
    CONREF = items
};

ShipActivity ship = new()
{
    CONREF = items
};

Connote connote = new()
{
    CONREF = items
};

Manifest manifest = new()
{
    CONREF = items
};

PrintActivity print = new()
{
    CONNOTE = connote,
    MANIFEST = manifest
};

Activity activity = new()
{
    BOOK = book,
    SHIP = ship,
    PRINT = print
};

ShipmentRequest request = new()
{
    LOGIN = login,
    ACTIVITY = activity,
    CONSIGNMENTBATCH = batch,
};

// Create the XmlSerializer.
XmlSerializer s = new(typeof(ShipmentRequest));

using MemoryStream ms = new();
XmlWriterSettings settings = new()
{
    OmitXmlDeclaration = true,
    Encoding = Encoding.UTF8,
     Indent = true,
    IndentChars = "\t"
};

XmlWriter xtw = XmlWriter.Create(ms, settings);
// To write the file, a TextWriter is required.
//using TextWriter writer = new StreamWriter("C:\\Temp\\shipping.xml");

s.Serialize(xtw, request);
