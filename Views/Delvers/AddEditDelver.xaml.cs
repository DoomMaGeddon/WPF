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
using MahApps.Metro.Controls;
using WPF.Data.Delvers;
using WPF.Models.Delvers;

namespace WPF.Views.Delvers {
    /// <summary>
    /// Lógica de interacción para AddEditDelver.xaml
    /// </summary>
    public partial class AddEditDelver : MetroWindow {
        public bool Edit { get; set; } = false;
        public DelverDTO? Explorador { get; set; } = null;
        private bool _loading = false;
        public AddEditDelver() {
            InitializeComponent();
        }

        public AddEditDelver(bool edit, DelverDTO delver) {
            InitializeComponent();

            Edit = edit;
            Explorador = delver;

            LoadDelverData();
        }

        private void LoadDelverData() {
            lblTitle.Content = "Editar explorador";

            txtName.Text = Explorador!.Nombre;
            txtGender.Text = Explorador!.Genero;
            txtSpecies.Text = Explorador.Especie;
            txtStatus.Text = Explorador.Estado;
            cbRank.SelectedIndex = Explorador!.RangoId switch {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                _ => 0,
            };
            txtPicture.Text = Explorador!.Foto;
            switchOriginal.IsOn = Explorador.Original;
            txtCreatorEmail.Text = Explorador.CreadorEmail;

            switchOriginal.IsEnabled = false;
            txtCreatorEmail.IsReadOnly = true;
            txtCreatorEmail.IsEnabled = false;
        }

        private async void BtnEnviar(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Regex emailRegex = MyRegex();

            if (
                txtName.Text.Length == 0 || txtName.Text.Length > 100
                || txtGender.Text.Length == 0 || txtGender.Text.Length > 10
                || txtSpecies.Text.Length == 0 || txtSpecies.Text.Length > 100
                || txtStatus.Text.Length == 0 || txtStatus.Text.Length > 50
                || (!emailRegex.IsMatch(txtCreatorEmail.Text) && switchOriginal.IsOn)
            ) {
                MessageBox.Show("""
                    El nombre del explorador debe tener entre 1 y 100 caracteres.
                    El género del explorador debe tener entre 1 y 10 caracteres.
                    La especie del explorador debe tener entre 1 y 100 caracteres.
                    El estado del explorador debe tener entre 1 y 50 caracteres.
                    La descripción del animal debe tener al menos 1 carácter.
                    """.Trim(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            }

            bool result;
            var delverPayload = new NewDelverDTO {
                Foto = txtPicture.Text,
                Original = switchOriginal.IsOn,
                CreadorEmail = txtCreatorEmail.Text,
                Nombre = txtName.Text,
                Genero = txtGender.Text,
                Especie = txtSpecies.Text,
                Estado = txtStatus.Text,
                RangoId = cbRank.SelectedIndex
            };

            if (Edit) {

                result = await AddEditDelverProvider.UpdateDelver(Explorador!.Id, delverPayload);

                if (!result) {
                    MessageBox.Show("Error actualizando el explorador.", "Error", MessageBoxButton.OK);
                    _loading = false;
                    return;
                }

                MessageBox.Show("Explorador actualizado correctamente.", "Success", MessageBoxButton.OK);

                new DelverList().Show();
                Close();

                _loading = false;
                return;
            }

            result = await AddEditDelverProvider.CreateDelver(delverPayload);

            if (!result) {
                MessageBox.Show("Error creando el explorador.", "Error", MessageBoxButton.OK);
                _loading = false;
                return;
            }

            MessageBox.Show("Explorador creado correctamente.", "Success", MessageBoxButton.OK);
            new DelverList().Show();
            _loading = false;
            Close();
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex MyRegex();

        private void BtnClose(object sender, MouseButtonEventArgs e) {
            new DelverList().Show();
            Close();
        }
    }
}
