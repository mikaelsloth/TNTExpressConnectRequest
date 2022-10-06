namespace TNTExpressConnectShipment.Tests
{
    using Xunit;
    using TNTExpressConnectShipment;
    using System.Xml.Linq;

    public class SerializeExtensionMethodsTests
    {
        [Fact()]
        public void DeserializeFromXDocTest()
        {
            ShipmentRequest request = new();
            //{
            //    Name = "Sheep",
            //    Legs = 4,
            //    Nutrition = Nutrition.Herbivore
            //};
            ShipmentRequest? des = request.SerializeToXDoc()?.DeserializeFromXDoc<ShipmentRequest>();

            //Assert.Equal(des.Name, request.Name);
            //Assert.Equal(des.Nutrition, request.Nutrition);
            //Assert.Equal(des.Legs, request.Legs);
            Assert.NotSame(des, request);
        }

        [Fact()]
        public void SerializeToXDocTest()
        {
            ShipmentRequest request = new();
            //{
            //    Name = "Sheep",
            //    Legs = 4,
            //    Nutrition = Nutrition.Herbivore
            //};
            XDocument xdoc = Assert.IsType<XDocument>(request.SerializeToXDoc());
            var ser = "<Animal " +
                      "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                      "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  " +
                      "<Name>Sheep</Name>\r\n  <Legs>4</Legs>\r\n  " +
                      "<Nutrition>Herbivore</Nutrition>\r\n</Animal>";

            Assert.Equal(xdoc?.ToString(), ser);
        }
    }
}