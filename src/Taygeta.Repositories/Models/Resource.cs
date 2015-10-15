// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taygeta.Repositories.Models
{
    [Table("Resources")]
    public class Resource
    {
        [MaxLength(440)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string CultureName { get; set; }
        public string Value { get; set; }
    }
}