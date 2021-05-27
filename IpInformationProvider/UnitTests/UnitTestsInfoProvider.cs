using IIpInformationProvider;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests
{

    [TestFixture]
    public class UnitTestsInfoProvider
    {
        [Test]
        public async Task TestApiAsync()
        {
            IIpInfoProvider iip = new IIpInfoProvider();
            var result = await iip.GetDetails("195.158.76.51");

            Assert.IsTrue(result.City == "Qormi");
            Assert.IsTrue(result.Country == "Malta");
        }
    }
}
