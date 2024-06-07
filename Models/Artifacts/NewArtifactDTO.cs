using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Artifacts {
    class NewArtifactDTO {
        public string Foto { get; set; } = "";
        public bool Original { get; set; } = false;
        public string? CreadorEmail { get; set; } = null;
        public string Nombre { get; set; } = "Desconocido";
        public string Grado { get; set; } = "Desconocido";
        public string Efecto { get; set; } = "Desconocido";
        public string Descripcion { get; set; } = "";
        public string? Origen { get; set; } = "Desconocido";
        public int? DuenyoId { get; set; } = null;
    }
}
