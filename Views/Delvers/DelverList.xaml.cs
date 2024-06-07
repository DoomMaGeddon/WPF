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
using WPF.Data.Delvers;
using WPF.Models.Delvers;
using WPF.Views.Artifacts;
using WPF.Views.Fauna;
using WPF.Views.Flora;
using WPF.Views.Users;

namespace WPF.Views.Delvers {
    /// <summary>
    /// Lógica de interacción para DelverList.xaml
    /// </summary>
    public partial class DelverList : MetroWindow {
        private readonly ObservableCollection<DelverDTO> exploradores = [];
        private bool _loading = false;
        public DelverList() {
            InitializeComponent();

            Load();

            delverListView.ItemsSource = exploradores;
            DataContext = this;
        }

        public async void Load() {
            exploradores.Clear();
            List<DelverDTO> delvers = await DelverListProvider.GetDelverList();

            if (delvers.Count == 0) {
                Close(); return;
            }

            foreach (var item in delvers) {
                if (item != null) {
                    if (item.Foto == "") {
                        item.Foto = "../../Utils/Img/Unknown.png";
                    }

                    exploradores.Add(item);
                }
            }
        }

        private void BtnAdd(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            AddEditDelver aev = new();
            aev.Show();

            _loading = false;
            Close();
        }

        private void BtnEdit(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            DelverDTO delver = (DelverDTO)((Image)sender).DataContext;

            foreach (var item in exploradores) {
                if (item.Id == delver.Id) {
                    if (item.Foto == "../../Utils/Img/Unknown.png") {
                        item.Foto = "";
                    }

                    AddEditDelver aev = new(true, delver);
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

            DelverDTO delver = (DelverDTO)((Image)sender).DataContext;
            var success = await DelverListProvider.DeleteDelver(delver.Id);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Explorador eliminado correctamente");
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

        private void BtnArtefactos(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new ArtifactList().Show();

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
