//using IIpInformationProvider;
//using IpWebApi.Business;
//using IpWebApi.Controllers;
//using IpWebApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Caching.Memory;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using NSubstitute;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace UnitTests
//{
    

//    [TestClass]
//    public class UnitTestsIpWebApi
//    {
//        private IEnumerable<Details> details { get; set; }


//        [TestMethod]
//        public void ConfirmDbContextUsesDummyData()
//        {
//            // Arrange
//            var mockContext = new Mock<IpDetailsDbContext>();

//            // Populate Customers "table"
//            var customerDbSet = details.GetQueryableMockDbSet();
//            foreach (var detail in Details)
//            {
//                customerDbSet.Add(customer);
//            }

//            mockContext.Setup(context => context.Customers).Returns(customerDbSet);
//            var dbContext = mockContext.Object;

//            // Act
//            var customerData = dbContext.Customers;

//            // Assert
//            Assert.IsTrue(customerData.Count() == 3);
//        }


//        //[Test]
//        //public void TestApi()
//        //{
//        //    //var mockRepo = new Mock<IpBusinessInterface>();
//        //    //mockRepo.Setup(x => x.GetIpDetailsAsync("195.158.76.59")).ReturnsAsync(new IpDetails
//        //    //{
//        //    //    City = "city",
//        //    //    Continent = "continent",
//        //    //    Country = "country",
//        //    //    Latitude = 12.23,
//        //    //    Longitude = 23.34
//        //    //});

//        //    //IPController controller = new IPController(mockRepo.Object);
//        //    //var result = await controller.GetIpDetailsAsync("195.158.76.59");
//        //    //OkObjectResult okResult = result as OkObjectResult;
//        //    //OkResult o = result as OkResult;

//        //    //NUnit.Framework.Assert.AreEqual(200, okResult.StatusCode);

//        //    var mockSet = new Mock<DbSet<Details>>();
//        //    var mockContext = new Mock<IpBusinessInterface>();
//        //    mockContext.Setup(m => m.GetIpDetailsAsync).Returns(mockSet.Object);


//        //    var ipbusiness = new IpBusiness(Substitute.For<IpDetailsDbContext>(),
//        //                                      Substitute.For<IMemoryCache>());
//        //    //var holdingsModel = new HoldingsModel
//        //    //{
//        //    //    AccountCode = "",
//        //    //    CoinPair = "",
//        //    //    MutationTokenSequenceNumber = 12345,
//        //    //    Provider = "Provider",
//        //    //    Suspense = new List<ReserveHoldingsModel>(),
//        //    //    Transaction = new List<ReleaseHoldingsModel>()
//        //    //};

//        //    var s = ipbusiness.GetIpDetailsAsync("195.158.76.59");

//        //    //Assert.Throws<ModelNotValidException>(() => holdServ.CreateHoldings(holdingsModel));
//        //}
//    }
//}
    


