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
using WPF.Data.Fauna;
using WPF.Data.Flora;
using WPF.Models.Fauna;
using WPF.Models.Flora;
using WPF.Views.Artifacts;
using WPF.Views.Delvers;
using WPF.Views.Fauna;
using WPF.Views.Users;

namespace WPF.Views.Flora {
    /// <summary>
    /// Lógica de interacción para FloraList.xaml
    /// </summary>
    public partial class FloraList : MetroWindow {
        private readonly ObservableCollection<FloraDTO> flora = [];
        private bool _loading = false;
        public FloraList() {
            InitializeComponent();

            Load();

            floraListView.ItemsSource = flora;
            DataContext = this;
        }

        public async void Load() {
            flora.Clear();
            List<FloraDTO> plants = await FloraListProvider.GetFloraList();

            if (plants.Count == 0) {
                Close(); return;
            }

            foreach (var item in plants) {
                if (item != null) {
                    if (item.Foto == "") {
                        item.Foto = "../../Utils/Img/Unknown.png";
                    }

                    flora.Add(item);
                }
            }
        }

        private void BtnAdd(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            AddEditFlora aev = new();
            aev.Show();
            _loading = false;
            Close();
        }

        private void BtnEdit(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            FloraDTO plant = (FloraDTO)((Image)sender).DataContext;

            foreach (var item in flora) {
                if (item.Id == plant.Id) {
                    if (item.Foto == "../../Utils/Img/Unknown.png") {
                        item.Foto = "";
                    }

                    AddEditFlora aev = new(true, plant);
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

            FloraDTO plant = (FloraDTO)((Image)sender).DataContext;
            var success = await FloraListProvider.DeleteFlora(plant.Id);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Planta eliminada correctamente");
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

        private void BtnArtefactos(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new ArtifactList().Show();

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
