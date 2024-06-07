using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using admin.login.data;
using MahApps.Metro.Controls;
using WPF.Data.Artifacts;
using WPF.Data.Fauna;
using WPF.Models.Artifacts;
using WPF.Models.Fauna;
using WPF.Views.Delvers;
using WPF.Views.Fauna;
using WPF.Views.Flora;
using WPF.Views.Users;

namespace WPF.Views.Artifacts {
    /// <summary>
    /// Lógica de interacción para ArtifactList.xaml
    /// </summary>
    public partial class ArtifactList : MetroWindow {
        private readonly ObservableCollection<ArtifactDTO> catalogo = [];
        private bool _loading = false;
        public ArtifactList() {
            InitializeComponent();

            Load();

            artifactListView.ItemsSource = catalogo;
            DataContext = this;
        }

        public async void Load() {
            catalogo.Clear();
            List<ArtifactDTO> artifacts = await ArtifactListProvider.GetArtifactList();

            if (artifacts.Count == 0) {
                Close(); return;
            }

            foreach (var item in artifacts) {
                if (item != null) {
                    if (item.Foto == "") {
                        item.Foto = "../../Utils/Img/Unknown.png";
                    }

                    catalogo.Add(item);
                }
            }
        }

        private void BtnAdd(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            AddEditArtifact aev = new();
            aev.Show();

            _loading = false;
            Close();
        }

        private void BtnEdit(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            ArtifactDTO artifact = (ArtifactDTO)((Image)sender).DataContext;

            foreach (var item in catalogo) {
                if (item.Id == artifact.Id) {
                    if (item.Foto == "../../Utils/Img/Unknown.png") {
                        item.Foto = "";
                    }

                    AddEditArtifact aev = new(true, artifact);
                    aev.Show();

                    _loading = false;
                    Close();
                    break;
                }
            }
        }

        private async void BtnDelete(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            ArtifactDTO artifact = (ArtifactDTO)((Image)sender).DataContext;
            var success = await ArtifactListProvider.DeleteArtifact(artifact.Id);

            if (!success) {
                MessageBox.Show("Error al eliminar el artefacto");
                _loading = false;
                return;
            }

            MessageBox.Show("Artefacto eliminado correctamente");
            Load();
            _loading = false;
        }

        private void BtnUsuarios(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new UserList().Show();

            _loading = false;
            Close();
        }

        private void BtnFauna(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new FaunaList().Show();

            _loading = false;
            Close();
        }

        private void BtnFlora(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new FloraList().Show();

            _loading = false;
            Close();
        }

        private void BtnExploradores(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new DelverList().Show();

            _loading = false;
            Close();
        }

        private void BtnSolicitudes(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new Requests().Show();

            _loading = false;
            Close();
        }

        private async void BtnLogout(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            var response = await LoginProvider.Logout();

            if (!response) {
                MessageBox.Show("Error al cerrar sesión");
                _loading = false;
                return;
            }

            new Login().Show();
            _loading = false;
            Close();
        }
    }
}