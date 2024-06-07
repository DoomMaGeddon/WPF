using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.Windows;
using WPF.Models.Artifacts;
using System.Net.Http.Json;

namespace WPF.Data.Artifacts {
    class ArtifactListProvider {
        public static async Task<List<ArtifactDTO>> GetArtifactList() {
            try {
                var client = Api.Client();

                var response = await client.GetFromJsonAsync<List<ArtifactDTO>>("/artifact");

                if (response != null) {
                    return response;
                } else {
                    return [];
                }
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido recuperar el catálogo de artefactos.\n" + ex.Message, "Error");
                return [];
            }
        }

        public static async Task<bool> DeleteArtifact(int id) {
            try {
                var client = Api.Client();

                var response = await client.DeleteAsync("/artifact/" + id);

                if (!response.IsSuccessStatusCode) {
                MessageBox.Show("No se ha podido elimiar el artefacto.\n");
                    return false;
                }

                return true;
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido elimiar el artefacto.\n" + ex.Message, "Error");
                return false;
            }
        }
    }
}
