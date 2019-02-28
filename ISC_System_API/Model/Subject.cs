using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("SUBJECTS")]
    public class Subject
    {
        [Key]
        [Column("SUBJECTID")]
        public int SubjectId { get; set; }
        [Column("SUBJECTNAME")]
        public string Name { get; set; }
        [Required]
        [Range(1,100)]
        public Nullable<short> NUMBERLESSON { get; set; }
    }
}
