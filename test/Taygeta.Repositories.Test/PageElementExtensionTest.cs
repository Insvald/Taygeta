// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using Taygeta.MsHtml.Test;
using Taygeta.Repositories.Html;
using Xunit;

namespace Taygeta.Repositories.Test
{
    public class PageElementExtensionTests
    {
        [Fact]
        public void DistanceToThrowsNotSupportException()
        {
            Assert.Throws<NotSupportedException>(
                () => PageDocumentTestHelper.GetTestElement().DistanceTo(
                    PageDocumentTestHelper.GetTestDoc(2).GetElementById("test3")));
        }

        [Fact]
        public void DistanceToReturnsCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            IPageElement element1 = doc.GetElementById("test1");
            IPageElement element2 = doc.GetElementById("test2");

            Assert.Equal(2, element1.DistanceTo(element2));

            doc = PageDocumentTestHelper.GetTestDoc(2);
            IPageElement element3 = doc.GetElementById("test3");
            IPageElement element4 = doc.GetElementById("test4");

            Assert.Equal(1, element3.DistanceTo(element4));
        }

        [Fact]
        public void GetSiblingsTagsReturnsCorrectValues()
        {
            string left;
            string right;          
            PageDocumentTestHelper.GetTestDoc().GetElementById("div3").GetSiblingsTags(out left, out right);
            Assert.Null(left);
            Assert.Equal("DIV", right);
        }

        [Fact]
        public void ParentAtLevelReturnsCorrectValue()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            Assert.Equal(doc.GetElementById("div2"), doc.GetElementById("a1").GetParentAtLevel(2));
        }
    }
}