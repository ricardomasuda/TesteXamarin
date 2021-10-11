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
        public class SimpleRequest : IRequest
        {
            public string Action { get; set; }
            public SimpleRequest(string action)
            {
                Action = action;
            }
        }
    }
}
