using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using admin;
using MahApps.Metro.Controls;
using WPF.Models.Users;

namespace WPF.Data.Users
{
    public class UserListResponse {
        public List<UserDTO> Users { get; set; } = [];
    }
 
    class UserListProvider
    {
        public static async Task<List<UserDTO>> GetUserList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<UserDTO>>("/user");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se han podido recuperar los usuarios.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> DeleteUser(string email) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync("/user/" + email);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("No se ha podido eliminar el usuario.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar el usuario.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
