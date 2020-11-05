using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapNav.Controllers;
using MapNav.Models;
using Newtonsoft.Json.Linq;

namespace MapNav.Tests.Controllers
{
    [TestClass]
    public class MapNavControllerTest
    {
        [TestMethod]
        public void GetMapNav_WithInput_ReturnsTheCorrectDistance()
        {
            MapNavController controller = new MapNavController();

            MapNavInput input = new MapNavInput { Data = "L3, R2, L5, R1, L1, L2" };
            var result = controller.GetMapNav(input);

            Assert.AreEqual(10, JObject.Parse(result)["data"]);
        }

        [TestMethod]
        public void GetMapNav_WithInputNoSpaces_ReturnsTheCorrectDistance()
        {
            MapNavController controller = new MapNavController();

            MapNavInput input = new MapNavInput { Data = "L4,R2,L5,L6,R10,L2" };
            var result = controller.GetMapNav(input);

            Assert.AreEqual(25, JObject.Parse(result)["data"]);
        }

        [TestMethod]
        public void GetMapNav_WithLargeInput_ReturnsTheCorrectDistance()
        {
            MapNavController controller = new MapNavController();

            MapNavInput input = new MapNavInput { Data = "L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1" };
            var result = controller.GetMapNav(input);

            Assert.AreEqual(209, JObject.Parse(result)["data"]);
        }

    }
}
