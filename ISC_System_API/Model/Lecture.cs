using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("LECTURES")]
    public class Lecture
    {
        [Required]
        [Key]
        public int USERID { get; set; }
        [Required]
        public Nullable<int> USE_USERID { get; set; }
        public Nullable<int> DEGREE { get; set; }
        public Nullable<int> ACADEMICRANK { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> STARTDAY { get; set; }
        public virtual ICollection<LecturerClasses> LECTURER_CLASSES { get; set; }
        public virtual User USER { get; set; }
        public virtual Degree DEGREEs { get; set; }
        public virtual Academic ACADEMICs { get; set; }
    }
}
