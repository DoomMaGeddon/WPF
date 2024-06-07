using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Delvers;
using System.Net.Http.Json;

namespace WPF.Data.Delvers {
    class AddEditDelverProvider {
        public static async Task<bool> UpdateDelver(int id, NewDelverDTO delverPayload) {
            try {
                var client = Api.Client();

                var response = await client.PutAsJsonAsync($"/delver/{id}", delverPayload);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error actualizando el explorador.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> CreateDelver(NewDelverDTO delverPayload) {
            try {
                var client = Api.Client();

                var response = await client.PostAsJsonAsync("/delver", delverPayload);

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error creando el explorador.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
