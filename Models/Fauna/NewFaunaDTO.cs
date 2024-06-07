using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Fauna {
    public class NewFaunaDTO {
        public string Foto { get; set; } = "";
        public bool Original { get; set; } = false;
        public string? CreadorEmail { get; set; } = null;
        public string Nombre { get; set; } = "Desconocido";
        public string Especie { get; set; } = "Desconocido";
        public int Habitat { get; set; } = 1;
        public string Peligro { get; set; } = "Ninguno";
        public string Dieta { get; set; } = "Desconocida";
        public string Descripcion { get; set; } = "";
    }
}
