using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("DETAILSTIMETABLE")]
    public class DetailTimetable
    {
        [Key]
        [Column("IDDETAIL")]
        public int Id { get; set; }
        [Required]
        public Nullable<int> IDROOM { get; set; }
        [Required]
        public Nullable<int> IDRECORD { get; set; }
        [Required]
        public Nullable<int> ASSIGNMENTID { get; set; }
        [Required]
        public Nullable<System.DateTime> STARTTIME { get; set; }
        [Required]
        public Nullable<System.DateTime> ENDTIME { get; set; }
        [ForeignKey("IDROOM")]
        public virtual ClassRoom CLASSROOM { get; set; }
        [ForeignKey("ASSIGNMENTID")]
        public virtual LecturerClasses LECTURER_CLASSES { get; set; }
        [ForeignKey("IDRECORD")]
        public virtual Timetable TIMETABLE { get; set; }
    }
}
