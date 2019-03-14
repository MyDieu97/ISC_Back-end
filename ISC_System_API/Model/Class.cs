using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("CLASSES")]
    public class Class
    {
        [Key]
        [Column("CLASSID")]
        public int Id { get; set; }
        [Required]
        public int COURSEID { get; set; }
        [Required]
        public int SUBJECTID { get; set; }
        [Column("CLASSNAME")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("PERCENTBANNEDTEST")] 
        public Nullable<double> PercentBan { get; set; } 
        public Nullable<double> PASSINGSCORE { get; set; }
        public Boolean ISDELETE { get; set; }
        public virtual Course COURSE { get; set; }
        public virtual Subject SUBJECT { get; set; }
    }
}
