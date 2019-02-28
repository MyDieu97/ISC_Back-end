using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("ACADEMIC")]
    public class Academic
    {
        [Key]
        public int Id { get; set; }
        [Column("AcademicName")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lecturer> Lectures { get; set; }
    }
}
