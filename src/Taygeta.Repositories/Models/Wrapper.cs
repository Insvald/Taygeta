// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taygeta.Repositories.Models
{
    [Table("Wrappers")]
    public class Wrapper
    {
        //public int Id { get; set; }
        public long PageId { get; set; }
        public virtual Page Page { get; set; }
        public int RecordNo { get; set; }
        [MaxLength(256)]
        public string FieldName { get; set; }
        public string ValuePath { get; set; }
    }
}
