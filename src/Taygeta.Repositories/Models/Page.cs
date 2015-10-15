// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taygeta.Repositories.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        public long Id { get; set; }
        public string Url { get; set; }
        public string HomePageTitle { get; set; }  // needed for vacancy's CompanyName
        public DateTime LastModified { get; set; }
        [Column(TypeName="ntext")]
        public string Content { get; set; }
        public DateTime? Wrapped { get; set; }
        public virtual IList<Wrapper> Wrappers { get; set; } = new List<Wrapper>();
    }
}
