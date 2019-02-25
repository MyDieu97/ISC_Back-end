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
        public virtual ClassRoom CLASSROOM { get; set; }
        public virtual LecturerClasses LECTURER_CLASSES { get; set; }
        public virtual Timetable TIMETABLE { get; set; }
    }
}
