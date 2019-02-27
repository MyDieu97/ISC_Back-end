using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("DEGREE")]
    public class Degree
    {
        [Key]
        public int Id { get; set; }

        [Column("DegreeName")]
        public string Name { get; set; }

        [ForeignKey("DEGREE")]
        public virtual ICollection<Lecturer> Lectures { get; set; }
    }
}
