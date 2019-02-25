using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("UNIVERSITYS")]
    public class University
    {
        [Key]
        [Column("UNIVERSITYID")]
        public int Id { get; set; }
        [Column("UNIVERSITYNAME")]
        public string Name { get; set; }
        public virtual ICollection<Student> STUDENTS { get; set; }
    }
}
