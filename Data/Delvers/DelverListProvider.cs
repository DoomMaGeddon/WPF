using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Fauna;
using WPF.Models.Delvers;
using System.Net.Http.Json;

namespace WPF.Data.Delvers {
    public class DelverListProvider {
        public static async Task<List<DelverDTO>> GetDelverList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<DelverDTO>>("/delver");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido recuperar la lista de exploradores.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> DeleteDelver(int id) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync("/delver/" + id);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("No se ha podido eliminar el explorador.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar el explorador.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
