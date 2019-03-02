using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("LECTURES")]
    public class Lecturer
    {
        [Required]
        [Key]
        public int USERID { get; set; }
        [Required]
        public Nullable<int> USE_USERID { get; set; }
        [Column("DEGREE")]
        public Nullable<int> DEGREEID { get; set; }
        public Nullable<int> ACADEMICRANK { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> STARTDAY { get; set; }
        public virtual ICollection<LecturerClasses> LECTURER_CLASSES { get; set; }
        [ForeignKey("USE_USERID")]
        public virtual User USER { get; set; }
        [ForeignKey("DEGREEID")]
        public virtual Degree DEGREE { get; set; }
        [ForeignKey("ACADEMICRANK")]
        public virtual Academic ACADEMIC { get; set; }
    }
}
