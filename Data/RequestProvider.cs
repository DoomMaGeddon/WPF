using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Users;
using WPF.Models;
using System.Net.Http.Json;

namespace WPF.Data {
    public class RequestProvider {
        public static async Task<List<Request>> GetRequestList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<Request>>("/request");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se han podido recuperar las peticiones.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> ProcessRequest(int email, bool approved) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync($"/request/{email}/{approved}");

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("No se ha podido procesar la petición.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido procesar la petición.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
