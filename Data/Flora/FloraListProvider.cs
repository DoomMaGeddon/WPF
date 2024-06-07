using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Flora;
using System.Net.Http.Json;

namespace WPF.Data.Flora {
    class FloraListProvider {
        public static async Task<List<FloraDTO>> GetFloraList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<FloraDTO>>("/flora");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido recuperar la flora.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> DeleteFlora(int id) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync("/flora/" + id);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("No se ha podido eliminar la planta.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar la planta.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
