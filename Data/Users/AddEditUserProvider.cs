using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using admin;
using MahApps.Metro.Controls;
using WPF.Models.Users;

namespace WPF.Data.Users
{
    class AddEditUserProvider
    {
        public static async Task<bool> UpdateUser(string email, UserDTO userPayload) {
            try {
                var client = Api.Client();

                var response = await client.PutAsJsonAsync($"/user/{email}", userPayload);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error actualizando el usuario.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> CreateUser(NewUserDTO user) {
            try {
                var client = Api.Client();

                var response = await client.PostAsJsonAsync("/user", user);

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error creando el usuario.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
