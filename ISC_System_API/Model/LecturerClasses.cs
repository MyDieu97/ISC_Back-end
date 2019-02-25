using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("LECTURER_CLASSES")]
    public class LecturerClasses
    {
        [Key]
        [Column("ASSIGNMENTID")]
        public int Id { get; set; }
        [Required]
        public Nullable<int> CLASSID { get; set; }
        [Required]
        public Nullable<int> USERID { get; set; }

        public virtual Class CLASS { get; set; }
        public virtual ICollection<DetailTimetable> DETAILSTIMETABLEs { get; set; }
        public virtual Lecture LECTURE { get; set; }
    }
}
