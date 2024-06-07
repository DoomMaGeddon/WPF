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
using admin;
using admin.login.data;
using MahApps.Metro.Controls;
using Microsoft.Data.Sqlite;
using Npgsql;
using WPF.Data.Users;
using WPF.Models.Users;
using WPF.Views.Artifacts;
using WPF.Views.Delvers;
using WPF.Views.Fauna;
using WPF.Views.Flora;

namespace WPF.Views.Users
{
    /// <summary>
    /// Lógica de interacción para UserList.xaml
    /// </summary>
    public partial class UserList : MetroWindow
    {
        private readonly ObservableCollection<UserDTO> usuarios = [];
        private bool _loading = false;
        public UserList()
        {
            InitializeComponent();

            Load();

            userListBox.ItemsSource = usuarios;
            DataContext = this;
        }

        public async void Load() {
            usuarios.Clear();
            List<UserDTO> users = await UserListProvider.GetUserList();

            if (users.Count == 0) {
                Close(); return;
            }

            foreach (var item in users) {
                if (item != null) {
                    usuarios.Add(item);
                }
            }
        }

        private void BtnAdd(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            AddEditUser aev = new();
            aev.Show();

            _loading = false;
            Close();
        }

        private void BtnEdit(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            UserDTO user = (UserDTO)((Button)sender).DataContext;

            foreach (var item in usuarios) {
                if (item.Email == user.Email) {
                    AddEditUser aev = new(true, user);
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

            UserDTO user = (UserDTO)((Button)sender).DataContext;
            var success = await UserListProvider.DeleteUser(user.Email);

            if (!success) {
                _loading = false;
                return;
            }

            MessageBox.Show("Usuario eliminado correctamente");
            Load();
            _loading = false;
        }

        private void BtnBackup(object sender, RoutedEventArgs e) {
            try {
                using (NpgsqlConnection connPg = new(connectionString: "Server=localhost;Port=5432;Username=postgres;Password=12345;Database=GiA")) {
                    connPg.Open();

                    using SqliteConnection connSqlite = new("Data Source=./../../../Utils/backup.db");
                    connSqlite.Open();

                    string createTableUsuariosQuery = @"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            email TEXT NOT NULL,
                            nombreUsuario TEXT NOT NULL,
                            fotoPerfil TEXT,
                            contrasenya TEXT NOT NULL,
                            descripcion TEXT,
                            rol TEXT NOT NULL,
                            experiencia INTEGER NOT NULL,
                            notificaciones INTEGER NOT NULL,
                            rangoId INTEGER,
                            PRIMARY KEY (email)
                        );";

                    using (SqliteCommand cmdSqlite = new(createTableUsuariosQuery, connSqlite)) {
                        cmdSqlite.ExecuteNonQuery();
                    }

                    using NpgsqlCommand cmdPg = new("SELECT * FROM usuarios", connPg);

                    using NpgsqlDataReader reader = cmdPg.ExecuteReader();

                    while (reader.Read()) {
                        using SqliteCommand cmdSqlite = new("INSERT INTO usuarios (email, nombreUsuario, fotoPerfil, contrasenya, descripcion, rol, experiencia, notificaciones, rangoId) " +
                            "VALUES (@email, @nombreUsuario, @fotoPerfil, @contrasenya, @descripcion, @rol, @experiencia, @notificaciones, @rangoId)", connSqlite);

                        cmdSqlite.Parameters.AddWithValue("@email", reader["email"]);
                        cmdSqlite.Parameters.AddWithValue("@nombreUsuario", reader["nombreUsuario"]);
                        cmdSqlite.Parameters.AddWithValue("@fotoPerfil", reader["fotoPerfil"]);
                        cmdSqlite.Parameters.AddWithValue("@contrasenya", reader["contrasenya"]);
                        cmdSqlite.Parameters.AddWithValue("@descripcion", reader["descripcion"]);
                        cmdSqlite.Parameters.AddWithValue("@rol", reader["rol"]);
                        cmdSqlite.Parameters.AddWithValue("@experiencia", reader["experiencia"]);
                        cmdSqlite.Parameters.AddWithValue("@notificaciones", reader["notificaciones"]);
                        cmdSqlite.Parameters.AddWithValue("@rangoId", reader["rangoId"]);

                        cmdSqlite.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Copia de seguridad realizada con éxito.", "Éxito");
            } catch (Exception ex) {
                MessageBox.Show("Error al realizar la copia de seguridad: " + ex.Message, "Error");
            }
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
