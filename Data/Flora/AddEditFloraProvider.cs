using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using System.Net.Http.Json;
using WPF.Models.Flora;

namespace WPF.Data.Flora {
    class AddEditFloraProvider {
        public static async Task<bool> UpdateFlora(int id, NewFloraDTO plantPayload) {
            try {
                var client = Api.Client();

                var response = await client.PutAsJsonAsync($"/flora/{id}", plantPayload);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error actualizando la planta.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> CreateFlora(NewFloraDTO plantPayload) {
            try {
                var client = Api.Client();

                var response = await client.PostAsJsonAsync("/flora", plantPayload);

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error creando la planta.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
