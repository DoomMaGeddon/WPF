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
using Microsoft.Data.Sqlite;
using Npgsql;
using admin.login.data;
using MahApps.Metro.Controls;
using WPF.Data;
using WPF.Models;
using WPF.Views.Artifacts;
using WPF.Views.Delvers;
using WPF.Views.Fauna;
using WPF.Views.Flora;
using WPF.Views.Users;

namespace WPF.Views {
    /// <summary>
    /// Lógica de interacción para Requests.xaml
    /// </summary>
    public partial class Requests : MetroWindow {
        private readonly ObservableCollection<Request> solicitudes = [];
        private bool _loading = false;
        public Requests() {
            InitializeComponent();

            //Load();

            requestListBox.ItemsSource = solicitudes;
            DataContext = this;
        }

        public async void Load() {
            solicitudes.Clear();
            List<Request> requests = await RequestProvider.GetRequestList();

            if (requests.Count == 0) {
                return;
            }

            foreach (var item in requests) {
                if (item != null) {
                    solicitudes.Add(item);
                }
            }
        }

        private async void BtnApprove(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Request request = (Request)((Button)sender).DataContext;
            var success = await RequestProvider.ProcessRequest(request.Id, true);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Petición aprobada correctamente");
            Load();
            _loading = false;
        }

        private async void BtnReject(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Request request = (Request)((Button)sender).DataContext;
            var success = await RequestProvider.ProcessRequest(request.Id, false);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Petición rechazada correctamente");
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

        private void BtnExploradores(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            new DelverList().Show();

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
