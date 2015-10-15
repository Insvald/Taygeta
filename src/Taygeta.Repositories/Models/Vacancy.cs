// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taygeta.Repositories.Models
{
    [Table("Vacancies")]
    public class Vacancy
    {
        [Key]
        public long Id { get; set; }
        public string Url { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        [MaxLength(254)]
        public string EMail { get; set; }

        public DateTime Published { get; set; }
        public DateTime? Closed { get; set; }
    }
}
