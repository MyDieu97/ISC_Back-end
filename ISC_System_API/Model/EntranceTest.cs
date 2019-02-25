﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("ENTRANCETESTS")]
    public class EntranceTest
    {
        [Key]
        [Column("ENTRANCETESTID")]
        public int Id { get; set; }
        [Required]
        public Nullable<int> COURSEID { get; set; }
        public Nullable<System.DateTime> TESTDATE { get; set; }

        public virtual Course COURSES { get; set; }
        public virtual SubjectEntranceTest SUBJECTS_ENTRANCETESTS { get; set; }
    }
}
