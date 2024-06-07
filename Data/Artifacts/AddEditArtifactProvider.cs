using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Fauna;
using WPF.Models.Artifacts;
using System.Net.Http.Json;

namespace WPF.Data.Artifacts {
    class AddEditArtifactProvider {
        public static async Task<bool> UpdateArtifact(int id, NewArtifactDTO artifactPayload) {
            try {
                var client = Api.Client();

                var response = await client.PutAsJsonAsync($"/artifact/{id}", artifactPayload);

                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error actualizando el artefacto.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> CreateArtifact(NewArtifactDTO artifactPayload) {
            try {
                var client = Api.Client();

                var response = await client.PostAsJsonAsync("/artifact", artifactPayload);

                return response.IsSuccessStatusCode;
            } catch (Exception ex) {
                MessageBox.Show("Error creando el artefacto.\n" + ex.Message, "Error");
                return false;
            }
        }

        public static async Task<List<string>> GetDelversIdList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<string[]>("/delver/ids/all/list");

                if (response != null) {
                    return [.. response];
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido recuperar los IDs de exploradores.\n" + ex.Message, "Error");
                return [];
            }
        }
    }
}
