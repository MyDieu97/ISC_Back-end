using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("TestResults")]
    public class TestResult
    {
        [Key]
        [Column("Result_ID")]
        public int Id { get; set; }
        [Required]
        public Nullable<int> UserID { get; set; }
        public double Score { get; set; }
        public Nullable<bool> IsPassing { get; set; }
        public int Subject_EntranceTestID { get; set; }
        [ForeignKey("UserID")]
        public virtual User USER { get; set; }
        [ForeignKey("Subject_EntranceTestID")]
        public virtual SubjectEntranceTest SubjectEntranceTest { get; set; }

    }
}
