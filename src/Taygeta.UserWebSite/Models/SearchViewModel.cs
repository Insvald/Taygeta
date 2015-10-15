// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using Taygeta.Repositories.Models;

namespace Taygeta.UserWebSite.Models
{
    public class SearchViewModel
    {
        public string Job { get; set; }
        public string Location { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int RecordCount { get; set; } // needed for pagination
        public IList<Vacancy> Vacancies { get; set; }
    }
}
