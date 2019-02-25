using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("WORKTRACKS")]
    public class Worktrack
    {
        [Key]
        public int COMPANYID { get; set; }
        public Nullable<int> IDSTUDENT { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> STARTDATE { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CONTRACTDATE { get; set; }
        public Nullable<byte> STATUS { get; set; }
        public string NOTE { get; set; }
        public virtual Company Company { get; set; }
        public virtual Student STUDENT { get; set; }
    }
}
