// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Linq;
using Xunit;
using Taygeta.Repositories.Models;

namespace Taygeta.DataAccessLayer.Test
{
    public class DataRepostioryTest : DataContextTest
    {
        [Fact]
        public void KeywordsGetReturnsCorrectValues()
        {
            Assert.Equal(7, TestDataSupplier.Resources.Get().Count());
            Assert.Equal(6, TestDataSupplier.Resources.Get(e => e.CultureName == "en-US").Count());
            Assert.Equal("mailto", TestDataSupplier.Resources.Get(e => e.Name == "EMail").First().Value);
        }

        [Fact]
        public void KeywordsAddAndRemoveSaveChanges()
        {
            Resource resource = new Resource() { Name = "addtest", CultureName = "en", Value = "addtest" };
            TestDataSupplier.Resources.Add(resource);
            TestDataSupplier.Save();
            Assert.Equal(resource, TestDataSupplier.Resources.Get(e => e.Name == "addtest").First());
            TestDataSupplier.Resources.Remove(resource);
            TestDataSupplier.Save();
            Assert.Null(TestDataSupplier.Resources.Get(e => e.Name == "addtest").FirstOrDefault());
        }

        [Fact]
        public void KeywordsUpdateSavesChanges()
        {
            Resource resource = TestDataSupplier.Resources.Get(e => e.Name == "EMail").First();
            Assert.Equal("mailto", TestDataSupplier.Resources.Get(e => e.Name == "EMail").First().Value);
            resource.Value = "mailto2";
            TestDataSupplier.Resources.Update(resource);
            TestDataSupplier.Save();
            Assert.Equal("mailto2", TestDataSupplier.Resources.Get(e => e.Name == "EMail").First().Value);
            resource.Value = "mailto";
            TestDataSupplier.Resources.Update(resource);
            TestDataSupplier.Save();
            Assert.Equal("mailto", TestDataSupplier.Resources.Get(e => e.Name == "EMail").First().Value);
        }
    }
}
