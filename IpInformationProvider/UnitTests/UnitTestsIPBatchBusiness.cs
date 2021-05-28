using System.Linq;
using IpWebApi.Business;
using NUnit.Framework;


namespace UnitTests
{
    [TestFixture]
    public class UnitTestsIPBatchBusiness
    {
        [Test]
        public void CreateRequest_IpListCountEqual()
        {
            // Arrange
            var business = new IpBatchBusiness();
            string[] ipList = GetIpStringListArray();

            // Act
            var result = business.CreateRequest(ipList);

            // Assert
            Assert.AreEqual(result.IpStatus.Count, 5);
        }

        [Test]
        public void ReadFile_Success()
        {
            // Arrange
            var business = new IpBatchBusiness();

            // Act
            var result = business.ReadFile();

            // Assert
            Assert.Greater(result.Length, 200);
        }

        private string[] GetIpStringListArray()
        {
            string str = "195.158.76.50, 195.158.76.51, 195.158.76.52, 195.158.76.53, 195.158.76.54";
            string[] ips = str.Split(',').ToArray();

            return ips;
        }

        private string GetIpString()
        {
            return "195.158.76.50, 195.158.76.51, 195.158.76.52, 195.158.76.53, 195.158.76.54";
        }
    }
}
