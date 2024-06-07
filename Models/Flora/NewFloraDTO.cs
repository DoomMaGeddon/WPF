using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Flora {
    class NewFloraDTO {
        public string Foto { get; set; } = "";
        public bool Original { get; set; } = false;
        public string? CreadorEmail { get; set; } = null;
        public string Nombre { get; set; } = "Desconocido";
        public string Especie { get; set; } = "Desconocido";
        public int Habitat { get; set; } = 1;
        public string Descripcion { get; set; } = "";
    }
}
