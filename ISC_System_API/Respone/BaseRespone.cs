using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class BaseRespone
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public BaseRespone() { }

        public BaseRespone(object data)
        {
            this.Data = data;
        }
    }
}
