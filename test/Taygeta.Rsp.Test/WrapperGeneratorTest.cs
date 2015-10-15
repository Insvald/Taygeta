// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using System.Linq;
using Taygeta.DataAccessLayer.Test;
using Taygeta.Repositories.Html;
using Xunit;

namespace Taygeta.Rsp.Test
{
    public class WrapperGeneratorTest : DataContextTest
    {
        [Fact]
        public void CheckIfRunCreatesWrappers()
        {
            SubjectFinder finder = new SubjectFinder { Keywords = "developer, programmer, DBA, director, manager" };
            PatternSeeker ps = new PatternSeeker();
            IPageDocument doc = GetTestDocFromDatabase();
            List<List<IPageElement>> recs = ps.Run(finder.Run(doc));
            WrapperGenerator wg = new WrapperGenerator();
            // setting up wrapper generator's dictionary
            foreach (string fieldName in new[] { "Position", "Description", "Requirements", "Location", "EMail" })
                wg.FieldDictionary.Add(fieldName,
                    TestDataSupplier.Resources.Get(e => (e.CultureName == "en-US") && (e.Name == fieldName)).Select(e => e.Name).ToArray());
            foreach (var wrapper in wg.Run(recs))
                doc.Page.Wrappers.Add(wrapper);          
            Assert.True(doc.Page.Wrappers.Any());
        }
    }
}