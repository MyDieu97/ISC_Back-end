using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("MAJORS")]
    public class Major
    {
        [Key]
        [Column("MAJORID")]
        public int Id { get; set; }

        [Column("MAJORNAME")]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Student> STUDENTS { get; set; }
    }
}
