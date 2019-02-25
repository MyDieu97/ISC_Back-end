using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("USERS")]
    public class User
    {
        [Key]
        [Column("USERID")]
        public int Id { get; set; }
        [StringLength(300)]
        public string FIRSTNAME { get; set; }
        [StringLength(200)]
        public string LASTNAME { get; set; }
        public Nullable<byte> GENDER { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string IDENTITYNUMBER { get; set; }
        [EmailAddress]
        public string EMAIL { get; set; }
        [Phone]
        public string PHONE { get; set; }
        [StringLength(500)]
        public string ADDRESS { get; set; }
        [Required]
        public Nullable<bool> IsStudent { get; set; }
        public virtual Lecture LECTURE { get; set; }
        public virtual ICollection<Student> STUDENTS { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
