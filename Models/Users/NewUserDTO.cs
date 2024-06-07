using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Users
{
    public class NewUserDTO
    {
        private string email = "";
        private string nombreUsuario = "";
        private string contrasenya = "";
        private string rol = "";
        private int experiencia = 0;
        private bool notificaciones = true;

        public string Email { get => email; set => email = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string? Descripcion { get; set; } = "";
        public string Contrasenya { get => contrasenya; set => contrasenya = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Experiencia { get => experiencia; set => experiencia = value; }
        public int? RangoId { get; set; } = 0;
        public bool Notificaciones { get => notificaciones; set => notificaciones = value; }
    }
}
