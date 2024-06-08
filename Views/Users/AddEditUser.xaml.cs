using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using MahApps.Metro.Controls;
using WPF.Data.Users;
using WPF.Models;
using WPF.Models.Users;

namespace WPF.Views.Users
{
    /// <summary>
    /// Lógica de interacción para AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : MetroWindow
    {
        public bool Edit { get; set; } = false;
        public UserDTO? User { get; set; } = null;
        private bool _loading = false;

        public AddEditUser()
        {
            InitializeComponent();
        }
        
        public AddEditUser(bool edit, UserDTO user)
        {
            InitializeComponent();

            Edit = edit;
            User = user;

            LoadUserData();
        }

        private void LoadUserData() {
            lblTitle.Content = "Editar usuario";

            txtUsername.Text = User!.NombreUsuario;
            txtEmail.Text = User!.Email;
            cbRole.SelectedIndex = User!.Rol switch {
                "Admin" => 0,
                "Científico" => 1,
                _ => 2,
            };
            txtDescription.Text = User!.Descripcion ?? "";
            upDownExperience.Value = User!.Experiencia;
            cbRank.SelectedIndex = User!.RangoId switch {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                _ => 0,
            };
            switchNotifications.IsOn = User!.Notificaciones;

            txtEmail.IsEnabled = false;
            txtEmail.IsReadOnly = true;
            txtPassword.IsEnabled = false;
        }

        private async void BtnEnviar(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Regex emailRegex = MyRegex();

            if (!Edit && (
                !emailRegex.IsMatch(txtEmail.Text) || txtUsername.Text.Length == 0 || txtUsername.Text.Length > 12 || 
                txtPassword.Password.Length < 8 || txtPassword.Password.Length > 255 || txtUsername.Text.Length == 0 
                )
            ) {
                MessageBox.Show("El usuario nuevo debe tener al menos un email válido, un nombre de usuario de máximo 12 caracteres, y una contraseña de al menos 8 caracteres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            } else if (Edit && (
                txtUsername.Text.Length == 0 || txtUsername.Text.Length > 12
                )
            ) {
                MessageBox.Show("El usuario nuevo debe tener al menos un email válido, un nombre de usuario de máximo 12 caracteres, y una contraseña de al menos 8 caracteres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            }

            bool result;

            if (Edit) {
                var userUpdatePayload = new UserDTO {
                    Email = txtEmail.Text,
                    NombreUsuario = txtUsername.Text,
                    Descripcion = txtDescription.Text,
                    Rol = ((ComboBoxItem)cbRole.SelectedItem).Tag.ToString() ?? "Estándar",
                    Experiencia = (int)upDownExperience.Value!,
                    RangoId = cbRank.SelectedIndex,
                    Notificaciones = switchNotifications.IsOn
                };
                result = await AddEditUserProvider.UpdateUser(User!.Email, userUpdatePayload);

                if (!result) {
                    MessageBox.Show("Error actualizando el usuario.", "Error", MessageBoxButton.OK);
                    _loading = false;
                    return;
                }

                MessageBox.Show("Usuario actualizado correctamente.", "Success", MessageBoxButton.OK);
                new UserList().Show();
                _loading = false;
                Close();
                return;
            }

            var userCreatePayload = new NewUserDTO {
                Email = txtEmail.Text,
                NombreUsuario = txtUsername.Text,
                Descripcion = txtDescription.Text,
                Contrasenya = txtPassword.Password,
                Rol = ((ComboBoxItem)cbRole.SelectedItem).Tag.ToString() ?? "Estándar",
                Experiencia = (int)upDownExperience.Value!,
                RangoId = cbRank.SelectedIndex,
                Notificaciones = switchNotifications.IsOn
            };
            result = await AddEditUserProvider.CreateUser(userCreatePayload);

            if (!result) {
                MessageBox.Show("Error creando el usuario.", "Error", MessageBoxButton.OK);
                _loading = false;
                return;
            }

            MessageBox.Show("Usuario creado correctamente.", "Success", MessageBoxButton.OK);
            new UserList().Show();
            _loading = false;
            Close();
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex MyRegex();

        private void BtnClose(object sender, MouseButtonEventArgs e) {
            new UserList().Show();
            Close();
        }
    }
}
