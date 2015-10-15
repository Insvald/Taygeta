// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Taygeta.Repositories.Html;
using Xunit;

namespace Taygeta.MsHtml.Test
{
    public class MsHtmlPageElementTest
    {
        [Fact]
        public void PathReturnsCorrectValue()
        {
            Assert.Equal("/BODY/DIV/SPAN", PageDocumentTestHelper.GetTestElement().Path);
        }

        [Fact]
        public void ChildrenReturnCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            IPageElement element = doc.GetElementById("div1");
            Assert.Equal(1, element.Children.Length);
            Assert.Equal("test1", element.Children[0].Attributes["id"]);
        }

        [Fact]
        public void InnerTextReturnsCorrectValue()
        {
            Assert.Equal("test1", PageDocumentTestHelper.GetTestElement().InnerText);
        }

        [Fact]
        public void TagReturnsCorrectValue()
        {
            Assert.Equal("SPAN", PageDocumentTestHelper.GetTestElement().Tag);
        }

        [Fact]
        public void ParentReturnsCorrectValue()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            IPageElement pageElement = doc.GetElementById("test1");
            IPageElement parentElement = doc.GetElementById("div1");
            Assert.Equal(parentElement, pageElement.Parent);
        }

        [Fact]
        public void SiblingsPropertiesReturnCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            IPageElement element3 = doc.GetElementById("div3");
            IPageElement element4 = doc.GetElementById("div4");
            IPageElement element5 = doc.GetElementById("div5");
            Assert.Equal(element3, element4.PreviousSibling);
            Assert.Equal(element4, element5.PreviousSibling);
            Assert.Null(element3.PreviousSibling);
            Assert.Equal(element4, element3.NextSibling);
            Assert.Equal(element5, element4.NextSibling);
            Assert.Null(element5.NextSibling);
        }

        [Fact]
        public void NodeIndexReturnsCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            IPageElement element3 = doc.GetElementById("div3");
            IPageElement element4 = doc.GetElementById("div4");
            IPageElement element5 = doc.GetElementById("div5");
            Assert.Equal(0, element3.NodeIndex);
            Assert.Equal(1, element4.NodeIndex);
            Assert.Equal(2, element5.NodeIndex);
        }
    }
}