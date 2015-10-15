// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace Taygeta.Repositories.Models
{
    [Table("Logs")]
    public class LogEntry
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public LogEntry() { }

        private string LimitValue([CanBeNull] string stringToLimit, [NotNull] string propertyName)
        {
            if (!string.IsNullOrEmpty(stringToLimit))
            {
                int maxLength = this.GetAnnotatedLength(propertyName);
                if (stringToLimit.Length > maxLength)
                    return stringToLimit.Substring(0, maxLength);
            }

            return stringToLimit;            
        }

        /// <summary>
        /// Assigns values checking the sizes of strings
        /// </summary>
        /// <param name="date"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public LogEntry(DateTime date, [CanBeNull] string thread, [CanBeNull] string level, 
            [CanBeNull] string logger, [CanBeNull] string message, [CanBeNull] string exception)
        {
            Date = date;
            Thread = LimitValue(thread, nameof(Thread));
            Level = LimitValue(level, nameof(Level));
            Logger = LimitValue(logger, nameof(Logger));
            Message = LimitValue(message, nameof(Message));
            Exception = LimitValue(exception, nameof(Exception));
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(255)]
        public string Thread { get; set; }
        [Required]
        [StringLength(50)]
        public string Level { get; set; }
        [Required]
        [StringLength(255)]
        public string Logger { get; set; }
        [Required]
        [StringLength(4000)]
        public string Message { get; set; }
        [StringLength(2000)]
        public string Exception { get; set; }
    }
}
