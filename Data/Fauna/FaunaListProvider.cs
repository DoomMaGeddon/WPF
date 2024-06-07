using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Users;
using WPF.Models.Fauna;
using System.Net.Http.Json;

namespace WPF.Data.Fauna {
    class FaunaListProvider {
        public static async Task<List<FaunaDTO>> GetFaunaList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<FaunaDTO>>("/fauna");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido recuperar la fauna.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> DeleteFauna(int id) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync("/fauna/" + id);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("No se ha podido eliminar el animal.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar el animal.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
