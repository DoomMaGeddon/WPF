using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Delvers {
    class NewDelverDTO {
        public string Foto { get; set; } = "";
        public bool Original { get; set; } = false;
        public string? CreadorEmail { get; set; } = null;
        public string Nombre { get; set; } = "Desconocido";
        public string Genero { get; set; } = "Desconocido";
        public string Especie { get; set; } = "Desconocido";
        public string Estado { get; set; } = "Desconocido";
        public int? RangoId { get; set; } = null;
    }
}
