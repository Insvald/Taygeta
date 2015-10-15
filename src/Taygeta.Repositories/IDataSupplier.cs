// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Taygeta.Repositories.Models;

namespace Taygeta.Repositories
{
    public interface IDataSupplier
    {
        void Save();

        IRepository<Page> Pages { get; }
        IRepository<Wrapper> Wrappers { get; }
        IRepository<Resource> Resources { get; }
        IRepository<Vacancy> Vacancies { get; }
        IRepository<LogEntry> LogEntries { get; }
    }
}
