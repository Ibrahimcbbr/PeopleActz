using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Responses.Common
{
    public class Result<T>
    {
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string Info { get; set; }
        public dynamic Payload { get; set; }
    }
}
