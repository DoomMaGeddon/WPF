using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Users;
using System.Net.Http.Json;
using WPF.Models.Fauna;

namespace WPF.Data.Fauna {
    class AddEditFaunaProvider {
        public static async Task<bool> UpdateFauna(int id, NewFaunaDTO animalPayload) {
            try {
                var client = Api.Client();

                var response = await client.PutAsJsonAsync($"/fauna/{id}", animalPayload);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error actualizando el animal.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> CreateFauna(NewFaunaDTO animalPayload) {
            try {
                var client = Api.Client();

                var response = await client.PostAsJsonAsync("/fauna", animalPayload);

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error creando el animal.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
