using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class ClassRoomInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DATEADDED { get; set; }
        public int ADDEDPERSON { get; set; }
        public Nullable<int> CAPACITY { get; set; }
        public string Person { get; set; }
    }
}
