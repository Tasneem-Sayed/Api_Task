using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryService.WebAPI.Mapper

{
    public class ApiResponse<Type>
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public Type Data { get; set; } // Success
        public Type Error { get; set; } // Faild

    }
}
