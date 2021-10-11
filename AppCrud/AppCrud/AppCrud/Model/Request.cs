using System;
using System.Collections.Generic;
using System.Text;

namespace AppCrud.Model
{
    class Request
    {
        public interface IRequest
        {
            string Action { get; set; }
        }
    }
}
