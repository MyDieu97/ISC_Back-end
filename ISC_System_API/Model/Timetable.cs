using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("TIMETABLES")]
    public class Timetable
    {
        [Key]
        [Column("IDRECORD")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> STARTDATE { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public virtual ICollection<Timetable> DETAILSTIMETABLEs { get; set; }
    }
}
