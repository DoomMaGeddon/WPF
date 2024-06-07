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
using WPF.Models.Fauna;
using WPF.Views.Artifacts;
using WPF.Views.Delvers;
using WPF.Views.Flora;
using WPF.Views.Users;

namespace WPF.Views.Fauna {
    /// <summary>
    /// Lógica de interacción para FaunaList.xaml
    /// </summary>
    public partial class FaunaList : MetroWindow {
        private readonly ObservableCollection<FaunaDTO> fauna = [];
        private bool _loading = false;
        public FaunaList() {
            InitializeComponent();

            Load();

            faunaListView.ItemsSource = fauna;
            DataContext = this;
        }

        public async void Load() {
            fauna.Clear();
            List<FaunaDTO> animals = await FaunaListProvider.GetFaunaList();

            if (animals.Count == 0) {
                Close(); return;
            }

            foreach (var item in animals) {
                if (item != null) {
                    if (item.Foto == "") {
                        item.Foto = "../../Utils/Img/Unknown.png";
                    }

                    fauna.Add(item);
                }
            }
        }

        private void BtnAdd(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            AddEditFauna aev = new();
            aev.Show();

            _loading = false;
            Close();
        }

        private void BtnEdit(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            FaunaDTO animal = (FaunaDTO)((Image)sender).DataContext;

            foreach (var item in fauna) {
                if (item.Id == animal.Id) {
                    if (item.Foto == "../../Utils/Img/Unknown.png") {
                        item.Foto = "";
                    }

                    AddEditFauna aev = new(true, animal);
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

            FaunaDTO animal = (FaunaDTO)((Image)sender).DataContext;
            var success = await FaunaListProvider.DeleteFauna(animal.Id);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Animal eliminado correctamente");
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
