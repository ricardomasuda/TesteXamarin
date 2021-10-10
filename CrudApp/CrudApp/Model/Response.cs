using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Model
{
    public class Response
    {
        public string Status { get; set; }
        public List<object> Conteudo { get; set; } = new List<object>();
    }
}
