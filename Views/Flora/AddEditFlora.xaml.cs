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
using WPF.Data.Flora;
using WPF.Models.Flora;

namespace WPF.Views.Flora {
    /// <summary>
    /// Lógica de interacción para AddEditFlora.xaml
    /// </summary>
    public partial class AddEditFlora : MetroWindow {
        public bool Edit { get; set; } = false;
        public FloraDTO? Planta { get; set; } = null;
        private bool _loading = false;
        public AddEditFlora() {
            InitializeComponent();
        }

        public AddEditFlora(bool edit, FloraDTO plant) {
            InitializeComponent();

            Edit = edit;
            Planta = plant;

            LoadPlantData();
        }

        private void LoadPlantData() {
            lblTitle.Content = "Editar planta";

            txtName.Text = Planta!.Nombre;
            txtPicture.Text = Planta!.Foto;
            txtSpecies.Text = Planta.Especie;
            cbHabitat.SelectedIndex = Planta.Habitat - 1;
            txtDescription.Text = Planta.Descripcion;
            switchOriginal.IsOn = Planta.Original;
            txtCreatorEmail.Text = Planta.CreadorEmail;

            switchOriginal.IsEnabled = false;
            txtCreatorEmail.IsReadOnly = true;
            txtCreatorEmail.IsEnabled = false;
        }

        private async void BtnEnviar(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Regex emailRegex = MyRegex();

            if (!Edit && (
                txtName.Text.Length == 0 || txtName.Text.Length > 100
                || txtSpecies.Text.Length == 0 || txtSpecies.Text.Length > 50
                || txtDescription.Text.Length == 0
                || (!emailRegex.IsMatch(txtCreatorEmail.Text) && switchOriginal.IsOn)
                )
            ) {
                MessageBox.Show("""
                    El nombre de la planta debe tener entre 1 y 100 caracteres.
                    La especie de la planta debe tener entre 1 y 10 caracteres.
                    La descripción de la planta debe tener al menos 1 carácter.
                    """.Trim(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            }

            bool result;
            var plantPayload = new NewFloraDTO {
                Foto = txtPicture.Text,
                Original = switchOriginal.IsOn,
                CreadorEmail = txtCreatorEmail.Text,
                Nombre = txtName.Text,
                Especie = txtSpecies.Text,
                Habitat = cbHabitat.SelectedIndex + 1,
                Descripcion = txtDescription.Text
            };

            if (Edit) {

                result = await AddEditFloraProvider.UpdateFlora(Planta!.Id, plantPayload);

                if (!result) {
                    MessageBox.Show("Error actualizando la planta.", "Error", MessageBoxButton.OK);
                    _loading = false;
                    return;
                }

                MessageBox.Show("Planta actualizada correctamente.", "Success", MessageBoxButton.OK);

                new FloraList().Show();
                Close();

                _loading = false;
                return;
            }

            result = await AddEditFloraProvider.CreateFlora(plantPayload);

            if (!result) {
                MessageBox.Show("Error creando la planta.", "Error", MessageBoxButton.OK);
                _loading = false;
                return;
            }

            MessageBox.Show("Planta creada correctamente.", "Success", MessageBoxButton.OK);
            new FloraList().Show();
            _loading = false;
            Close();
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex MyRegex();

        private void BtnClose(object sender, MouseButtonEventArgs e) {
            new FloraList().Show();
            Close();
        }
    }
}
