using NUnit.Framework;
using System.Net;
using TimeTracker.Domain.Common;

namespace TimeTracker.Domain.Tests.Common
{
    [TestFixture]
    public class IpHelperTests
    {
        public void GetIpAddress_GivenEmptyAddressList_ShouldReturnEmptyString()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = IpHelper.GetIpAddress();
            //---------------Test Result -----------------------
            Assert.IsEmpty(results);
        }

        [Test]
        public void GetIpAddress_GivenAddressList_ShouldReturnIpAddress()
        {
            //---------------Set up test pack-------------------
            var hostName = "www.iamahost.com";
            IPHostEntry host = Dns.Resolve(hostName);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = IpHelper.GetIpAddress();
            //---------------Test Result -----------------------
            Assert.IsNotEmpty(results);
        }
    }
}
