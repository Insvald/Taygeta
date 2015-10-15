// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using System.Linq;
using Taygeta.DataAccessLayer.Test;
using Taygeta.Repositories.Html;
using Taygeta.Repositories.Models;
using Xunit;

namespace Taygeta.Rsp.Test
{
    public class VacancyScraperTest : DataContextTest
    {
        [Fact]
        public void GetValueReturnsCorrectValues()
        {
            VacancyScraper scraper = new VacancyScraper();
            IPageDocument doc = GetTestDocFromDatabase();
            doc.Page.Wrappers.Add(new Wrapper
            {
                Page = doc.Page,
                PageId = doc.Page.Id,
                FieldName = "Position",
                RecordNo = 1,
                ValuePath = "/BODY/DIV#6/DIV/DIV/DIV#0/DIV#1/DIV/DIV#1/DIV#0/DIV/DIV#1/DIV#0/DIV#0/H3&CONTENT"
            });
            doc.Page.Wrappers.Add(new Wrapper
            {
                Page = doc.Page,
                PageId = doc.Page.Id,
                FieldName = "EMail",
                RecordNo = 1,
                ValuePath = "/BODY/DIV#6/DIV/DIV/DIV#0/DIV#1/DIV/DIV#1/DIV#0/DIV/DIV#1/DIV#0/DIV#1/P#5/A&HREF"
            });
            Assert.Equal("Director of Sales - Eastern Europe and Africa", scraper.GetValue(doc, 1, "Position"));
            Assert.Equal("mailto:jobs@liveu.tv?&subject=The%20subject%20of%20the%20email", scraper.GetValue(doc, 1, "EMail"));
        }

        /*
        [Fact]
        public void GetCompanyNameTest()
        {
            VacancyScraper scraper = new VacancyScraper();
            Assert.Equal("Live Broadcasting | Internet Live Broadcast, Live Video Transmission &amp; Video Streaming Software - LiveU",
                scraper.GetCompanyName(url));
        }
        */

        [Fact]
        public void RunScrapesAllVacancies()
        {
            VacancyScraper scraper = new VacancyScraper();
            IPageDocument doc = GetTestDocFromDatabase();
            doc.Page.Wrappers.Add(new Wrapper
            {
                Page = doc.Page,
                PageId = doc.Page.Id,
                FieldName = "Position",
                RecordNo = 1,
                ValuePath = "/BODY/DIV#6/DIV/DIV/DIV#0/DIV#1/DIV/DIV#1/DIV#0/DIV/DIV#1/DIV#0/DIV#0/H3&CONTENT"
            });
            doc.Page.Wrappers.Add(new Wrapper
            {
                Page = doc.Page,
                PageId = doc.Page.Id,
                FieldName = "Position",
                RecordNo = 2,
                ValuePath = "/BODY/DIV#6/DIV/DIV/DIV#0/DIV#1/DIV/DIV#1/DIV#0/DIV/DIV#1/DIV#1/DIV#0/H3&CONTENT"
            });
            IEnumerable<Vacancy> vacancies = scraper.Run(GetTestDocFromDatabase());
            Assert.NotNull(vacancies);
            Assert.Equal(2, vacancies.Count());
        }
    }
}