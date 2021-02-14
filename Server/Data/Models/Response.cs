using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.Server.Data.Models
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        }
    }