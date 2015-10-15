// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Taygeta.DataAccessLayer.Test;
using Xunit;
using Taygeta.Rsp;

namespace Taygeta.Rsp.Test
{
    public class RspExtractorTest : DataContextTest
    {
        protected RspExtractor CreateRspExtractor()
        {
            return new RspExtractor(GetTestDocFromDatabase(), TestDataSupplier);
        }

        [Fact]
        public void ProcessPageThrowsNoException()
        {
            CreateRspExtractor().ProcessPage();
        }

        [Fact]
        public void RunThrowsNoException()
        {
            CreateRspExtractor().Run();
        }
    }
}