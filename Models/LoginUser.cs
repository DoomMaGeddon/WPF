namespace admin.domain
{
    public class LoginUser
    {
        private string email = "";
        private string nombreUsuario = "";
        private string rol = "";

        public string Email { get => email; set => email = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
