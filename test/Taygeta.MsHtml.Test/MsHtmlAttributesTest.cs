// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Xunit;

namespace Taygeta.MsHtml.Test
{
    public class MsHtmlAttributesTest
    {
        [Fact]
        public void AttributesReturnCorrectValue()
        {
            Assert.Equal("red", PageDocumentTestHelper.GetTestElement().Attributes["color"]);
            //BUG: class is not read correctly for some reason (http://stackoverflow.com/questions/531508/getattribute-cannot-return-class-in-ie7)
            //Assert.AreEqual("someclass", e.Attributes["class"]); 
        }
    }
}