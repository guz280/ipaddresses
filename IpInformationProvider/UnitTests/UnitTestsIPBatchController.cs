//using IIpInformationProvider;
//using IpWebApi.Business;
//using IpWebApi.Controllers;
//using IpWebApi.Models;
//using Microsoft.Extensions.Caching.Memory;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using NUnit.Framework.Internal;

//namespace UnitTests
//{
//    [TestFixture]
//    public class UnitTestsIPBatchController
//    {

//        [Test]
//        public async Task GetIpDetailsAsync_ReturnSuccess()
//        {
//            string[] ipList = GetIpStringListArray();

//            // Arrange
//            var mockServiceProvider = new Mock<IServiceProvider>();
//            var mockIpBatchBusiness = new Mock<IpBatchBusinessInterface>();
//            var mockMemoryCache = new Mock<IMemoryCache>();
//            var t = Mock.
//            mockIpBatchBusiness.Setup(repo => repo.CreateRequest(ipList))
//                .Returns(GetIpRequestSample(false));
//            mockIpBatchBusiness.Setup(repo => repo.ReadFile())
//                .Returns(GetIpString());
//            mockMemoryCache.Setup();
//            var controller = new IPBatchController(mockServiceProvider.Object, mockIpBatchBusiness.Object, mockMemoryCache.Object);

//            // Act
//            var result = controller.UpdateRequest();

//            // Assert
//            NUnit.Framework.Assert.IsNotNull(result);
//        }


//        public Test GetSystemUnderTest()
//        {
//            var services = new ServiceCollection();
//            services.AddMemoryCache();
//            var serviceProvider = services.BuildServiceProvider();

//            var memoryCache = serviceProvider.GetService<IMemoryCache>();
//            return new Test(memoryCache);
//        }
//        //[Test]
//        //public async Task GetIpDetailsAsync_Return500()
//        //{
//        //    // Arrange
//        //    var mockRepo = new Mock<IpBusinessInterface>();
//        //    mockRepo.Setup(repo => repo.GetIpDetailsAsync("195.158.76.51"))
//        //        .ReturnsAsync(GetIpDetailsSample(false));
//        //    var controller = new IPBatchController(mockRepo.Object);

//        //    // Act
//        //    var result = await controller.GetIpDetailsAsync("195.158.76.51");

//        //    // Assert
//        //    NUnit.Framework.Assert.AreEqual(500, ((StatusCodeResult)result.Result).StatusCode);
//        //}


//        private string[] GetIpStringListArray()
//        {
//            string str = "195.158.76.50, 195.158.76.51, 195.158.76.52, 195.158.76.53, 195.158.76.54";
//            string[] ips = str.Split(',').ToArray();

//            return ips;
//        }

//        private string GetIpString()
//        {
//            return "195.158.76.50, 195.158.76.51, 195.158.76.52, 195.158.76.53, 195.158.76.54";
//        }


//        private IpRequest GetIpRequestSample(bool returnNull)
//        {
//            if (!returnNull)
//            {
//                Dictionary<string, Status> ipStatus = new Dictionary<string, Status>();
//                ipStatus.Add("195.158.76.50", new Status
//                {
//                    //Todo = true,
//                    Processed = false
//                });

//                var ipRequest = new IpRequest
//                {
//                    guid = Guid.NewGuid(),
//                    IpStatus = ipStatus
//                };

//                return ipRequest;
//            }

//            return null;
//        }
//    }
//}
