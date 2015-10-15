// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Taygeta.DataAccessLayer.Test;
using Taygeta.Repositories.Html;
using Xunit;

namespace Taygeta.Rsp.Test
{
    public class PatternSeekerTest : DataContextTest
    {
        [Fact]
        public void RunReturnsNotNullValue()
        {
            SubjectFinder finder = new SubjectFinder { Keywords = "developer, programmer, DBA, director, manager" };
            IPageElement element = finder.Run(GetTestDocFromDatabase());
            Assert.NotNull(element);
            PatternSeeker ps = new PatternSeeker();
            Assert.NotNull(ps.Run(element));
        }
    }
}