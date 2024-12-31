﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Shared
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
