using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("CLASSROOMS")]
    public class ClassRoom
    {
        [Key]
        [Column("IDROOM")]
        public int Id { get; set; }

        [Column("ROOMNAME")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DATEADDED { get; set; }

        [DataType(DataType.Date)]
        public int ADDEDPERSON { get; set; }

        [Range(1,200)]
        public Nullable<int> CAPACITY { get; set; }
    }
}
