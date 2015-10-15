// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Taygeta.MsHtml.Test;
using Taygeta.Repositories.Html;
using Xunit;

namespace Taygeta.Repositories.Test
{
    public class UniquePathTest
    {
        [Fact]
        public void UniquePathReturnsCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            Assert.Equal("/BODY/DIV#2/DIV#2/A", doc.GetElementById("a1").GetUniquePath());
            Assert.Equal("/BODY/DIV#4", doc.GetElementById("div6").GetUniquePath());
        }
    }
}