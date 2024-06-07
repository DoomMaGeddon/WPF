using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models {
    public class Request {
        public int Id { get; set; }
        public string EmailUsuario { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; } = "";
    }
}
