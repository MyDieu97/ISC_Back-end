using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("COMPANIES")]
    public class Company
    {
        [Key]
        [Column("COMPANYID")]
        public int Id { get; set; }
        [Column("COMPANYNAME")]
        [StringLength(200)]
        public string NAME { get; set; }
        public string DIACHI { get; set; }
        public string CONTACTPERSON { get; set; }
        [Phone]
        public string PHONE { get; set; }
        public Nullable<byte> STATUS { get; set; }

        public virtual Worktrack WORKTRACK { get; set; }
    }
}
