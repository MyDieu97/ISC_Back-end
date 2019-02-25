using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("COURSES")]
    public class Course
    {
        [Key]
        [Column("COURSEID")]
        public int Id { get; set; }
        [Column("COURSENAME")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> STARTDATE { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public string NOTE { get; set; }
        public virtual ICollection<Class> CLASSES { get; set; }
        public virtual ICollection<EntranceTest> ENTRANCETESTS { get; set; }
    }
}
