using Moq;
using NUnit.Framework;
using IpWebApi.Business;
using IpWebApi.Controllers;
using System.Threading.Tasks;
using IIpInformationProvider;
using Microsoft.AspNetCore.Mvc;


namespace UnitTests
{


    [TestFixture]
    public class UnitTestsIpWebApiIPController
    {

        [Test]
        public async Task GetIpDetailsAsync_ReturnSuccess()
        {
            // Arrange
            var mockIpBusiness = new Mock<IIpBusinessInterface>();
            mockIpBusiness.Setup(repo => repo.GetIpDetailsAsync("195.158.76.51"))
                .ReturnsAsync(GetIpDetailsSample(false));
            var controller = new IPController(mockIpBusiness.Object);

            // Act
            var result = await controller.GetIpDetailsAsync("195.158.76.51");

            // Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public async Task GetIpDetailsAsync_Return500()
        {
            // Arrange
            var mockIpBusiness = new Mock<IIpBusinessInterface>();
            mockIpBusiness.Setup(repo => repo.GetIpDetailsAsync("195.158.76.51"))
                .ReturnsAsync(GetIpDetailsSample(true));
            var controller = new IPController(mockIpBusiness.Object);

            // Act
            var result = await controller.GetIpDetailsAsync("195.158.76.51");
            
            // Assert
            Assert.AreEqual(500, ((StatusCodeResult)result.Result).StatusCode);
        }

        private IpDetails GetIpDetailsSample(bool returnNull)
        {
            if (!returnNull)
            {
                var ipDetails = new IpDetails
                {

                    City = "Qormi",
                    Country = "Malta",
                    Continent = "Europe",
                    Latitude = 35.882999420166,
                    Longitude = 14.493800163269
                };

                return ipDetails;
            }
            else
            {
                return null;
            }
        }


    }
}



