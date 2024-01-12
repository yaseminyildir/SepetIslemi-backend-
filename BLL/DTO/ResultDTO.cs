using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ResultDTO
    {
        public int StatusCode { get; set; } //404
        public bool Status { get; set; } //false
        public string Message { get; set; } //
    }
}
