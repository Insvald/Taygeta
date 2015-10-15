// The Taygeta Project
// (c) 2015 Ilya Rovensky

using JetBrains.Annotations;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Taygeta.Repositories;
using Taygeta.Repositories.Models;

namespace Taygeta.DataAccessLayer
{
    /// <summary>
    /// EF context for data access
    /// </summary>
    public class DataContext : DbContext, IDataSupplier
    {
        public DbSet<Page> PageTable { get; set; }
        public DbSet<Wrapper> WrapperTable { get; set; }
        public DbSet<Resource> ResourceTable { get; set; }
        public DbSet<Vacancy> VacancyTable { get; set; }
        public DbSet<LogEntry> LogTable { get; set; }

        public DataContext()
        {
            CreateRepos();            
        }

        public DataContext([NotNull] DbContextOptions options) : base(options)
        {
            CreateRepos();
        }

        private void CreateRepos()
        {
            Pages = new DataRepository<Page>(this);
            Wrappers = new DataRepository<Wrapper>(this);
            Resources = new DataRepository<Resource>(this);
            Vacancies = new DataRepository<Vacancy>(this);
            LogEntries = new DataRepository<LogEntry>(this);
        }

        protected override void OnModelCreating([NotNull] ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // composite key
            builder.Entity<Resource>().Key(k => new { k.Name, LanguageCode = k.CultureName });

            var wrapperBuilder = builder.Entity<Wrapper>();
            // composite key
            wrapperBuilder.Key(w => new { w.PageId, w.RecordNo, w.FieldName });
            // disable auto-generation
            wrapperBuilder.Property(w => w.PageId).ValueGeneratedNever();
            wrapperBuilder.Property(w => w.RecordNo).ValueGeneratedNever();

            // foreign key
            wrapperBuilder.Reference(typeof(Page)).InverseCollection("Wrappers").ForeignKey("PageId");
        }

        #region IDataSupplier implementation
        /// <inheritdoc />
        public void Save()
        {
            SaveChanges();
        }

        /// <inheritdoc />
        public IRepository<Page> Pages { get; private set; }
        
        /// <inheritdoc />
        public IRepository<Wrapper> Wrappers { get; private set; }

        /// <inheritdoc />
        public IRepository<Resource> Resources { get; private set; }

        /// <inheritdoc />
        public IRepository<Vacancy> Vacancies { get; private set; }

        /// <inheritdoc />
        public IRepository<LogEntry> LogEntries { get; private set; }
        #endregion
    }
}
