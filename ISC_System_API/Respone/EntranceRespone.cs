using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class EntranceRespone
    {
        public int Id { get; set; }
        public Nullable<int> COURSEID { get; set; }
        public Nullable<System.DateTime> TESTDATE { get; set; }
        public string CourseName { get; set; }
    }
}
