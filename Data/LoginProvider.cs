using admin.domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using WPF.Views;

namespace admin.login.data
{
    internal class LoginRequest
    {
        public required string Email { get; set; }
        public required string Contrasenya { get; set; }
    }

    public class LoginResponse
    {
        public LoginUser? User { get; set; } = null;
        public string? Token { get; set; } = null;
    }

    public class LoginProvider
    {
        public static async Task<LoginResponse> Login(string email, string contrasenya)
        {
            var client = Api.Client();

            var loginRequest = new LoginRequest {
                Email = email,
                Contrasenya = contrasenya
            };
            try {
                var response = await client.PostAsJsonAsync("/user/login", loginRequest);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (responseData != null && responseData.User?.Rol == "Admin") {
                    return responseData ?? new LoginResponse();
                }
            } catch (Exception) {
                return new LoginResponse();
            }

            throw new HttpRequestException("La respuesta no es válida");
        }

        public static async Task<bool> Logout() {
            var client = Api.Client();

            try {
                var response = await client.PostAsync("/user/logout", new StringContent(""));
                response.EnsureSuccessStatusCode();

                Store.Instance.RemoveStateItem("UserDTO");
                Store.Instance.RemoveStateItem("Token");

                return response.IsSuccessStatusCode;
            } catch (Exception) {
                MessageBox.Show("Error al cerrar sesión", "Error");
                return false;
            }
        }

        public static async Task<bool> IsTokenValid()
        {
            var client = Api.Client();
            var response = await client.GetAsync("/me");
            return response.IsSuccessStatusCode;
        }
    }
}
