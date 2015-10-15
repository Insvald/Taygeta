using System;
using System.Net;
using Abot.Poco;
using Xunit;

namespace Taygeta.WebLoader.Test
{
    public class ProxyPageRequesterTest : ProxyPageRequester
    {
        public ProxyPageRequesterTest() : base(new CrawlConfiguration(), null)
        {
            ProxyAddress = new Uri("http://10.0.0.1");
        }

        [Fact]
        public void BuildRequestObjectCreatesProxy()
        {
            HttpWebRequest webRequest = BuildRequestObject(new Uri("http://google.com"));
            Assert.NotNull(webRequest.Proxy);
        }
    }
}
