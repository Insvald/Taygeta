// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using Microsoft.Data.Entity;
using Taygeta.MsHtml.Test;
using Taygeta.Repositories;
using Taygeta.Repositories.Models;
using System.Linq;
using Taygeta.MSHtml;
using Taygeta.Repositories.Html;

namespace Taygeta.DataAccessLayer.Test
{
    public class DataContextTest : IDisposable
    {
        private bool _disposed;
        private readonly DataContext _dataContext;
        private readonly Page _page;
        public IDataSupplier TestDataSupplier { get; }

        // creating in-memory database
        public DataContextTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase(false);
            _dataContext = new DataContext(optionsBuilder.Options);
            TestDataSupplier = _dataContext;
            _dataContext.ResourceTable.AddRange(
                new Resource { Name = "Description", CultureName = "en-US", Value = "description, responsibilities" },
                new Resource { Name = "EMail", CultureName = "en-US", Value = "mailto" },
                new Resource { Name = "Location", CultureName = "en-US", Value = "location, Israel, Tel Aviv" },
                new Resource { Name = "Requirements", CultureName = "en-US", Value = "requirements, required, skills, experience, degree, bachelor, advantage, mandatory" },
                new Resource { Name = "vacancyPageTitle", CultureName = "en-US", Value = "work, job, career, vacancy, vacancies" },
                new Resource { Name = "vacancyPageTitle", CultureName = "he-IL", Value = "דרושים, משרות, קריירה" },
                new Resource { Name = "vacancySubjectItem", CultureName = "en-US", Value = "developer, programmer, DBA, director, manager" });

            TestDataSupplier.Pages.Add(PageDocumentTestHelper.GetTestPage(3));
            TestDataSupplier.Save();
            _page = TestDataSupplier.Pages.Get().First();
        }

        public Page GetTestPageFromDatabase()
        {
            return _page;
        }

        public IPageDocument GetTestDocFromDatabase()
        {
            return new MsHtmlPageDocument(GetTestPageFromDatabase());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dataContext.Dispose();
                _disposed = true;
            }
        }

        ~DataContextTest()
        {
            Dispose(false);
        }
    }
}
