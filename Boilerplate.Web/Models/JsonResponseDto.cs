using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Web.Models
{
    public class JsonResponseDto<T>
    {
        public bool IsSuccess { get { return string.IsNullOrEmpty(ErrorMessage); } }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
