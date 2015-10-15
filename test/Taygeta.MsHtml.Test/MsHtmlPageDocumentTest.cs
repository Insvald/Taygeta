// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.IO;
using Taygeta.MSHtml;
using Taygeta.Repositories.Html;
using Taygeta.Repositories.Models;
using Xunit;

namespace Taygeta.MsHtml.Test
{
    public static class PageDocumentTestHelper
    {
        public static Page GetTestPage(int testFileNumber = 1)
        {
            string fileName;
            switch (testFileNumber)
            {
                case 1:
                    fileName = "../HTML/mshtml-test.html";
                    break;
                case 2:
                    fileName = "../HTML/mshtml-test2.html";
                    break;
                case 3:
                    fileName = "../HTML/LiveU-Careers.html";
                    break;
                default:
                    throw new FileNotFoundException();
            }
            return new Page { Content = File.ReadAllText(fileName) };
        }

        public static IPageDocument GetTestDoc(int testFileNumber = 1)
        {
            return new MsHtmlPageDocument(GetTestPage(testFileNumber));
        }

        public static IPageElement GetTestElement()
        {
            return GetTestDoc().GetElementById("test1");
        }

        /*
        public static Page GetTestPageFromWeb()
        {
            using (WebClient client = new WebClient())
                return new Page {Content = client.DownloadString("http://www.liveu.tv/careers")};
        }

        public static IPageDocument GetTestDocFromWeb()
        {
            return new MsHtmlPageDocument(GetTestPageFromWeb());
        }*/
    }

    public class MsHtmlPageDocumentTest
    {
        [Fact]
        public void GetElementByIdReturnsCorrectValues()
        {
            IPageDocument doc = PageDocumentTestHelper.GetTestDoc();
            Assert.Equal("test1", doc.GetElementById("test1").InnerText);
            Assert.Equal("test2", doc.GetElementById("test2").InnerText);
            Assert.Null(doc.GetElementById("test3"));
        }
    }
}