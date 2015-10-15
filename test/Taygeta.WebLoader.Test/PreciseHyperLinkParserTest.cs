using HtmlAgilityPack;
using Taygeta.MsHtml.Test;
using Taygeta.Repositories.Models;
using Xunit;

namespace Taygeta.WebLoader.Test
{   
    public class PreciseHyperLinkParserTest : PreciseHyperLinkParser
    {
        [Fact]
        public void GetLinksReturnsCorrectValue()
        {
            // check that there is no exception and it returns empty list
            Assert.Equal(0, GetLinks(null).Count);

            // check with the predefined html
            HtmlDocument doc = new HtmlDocument();
            Page page = PageDocumentTestHelper.GetTestPage(3);
            doc.LoadHtml(page.Content);
            HtmlNodeCollection col = new HtmlNodeCollection(doc.DocumentNode);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                col.Add(link);
            Assert.Equal(129, GetLinks(col).Count);
        }
    }
}