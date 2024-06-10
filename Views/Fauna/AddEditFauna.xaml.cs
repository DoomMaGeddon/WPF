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
using WPF.Data.Fauna;
using WPF.Models.Fauna;

namespace WPF.Views.Fauna {
    /// <summary>
    /// Lógica de interacción para AddEditFauna.xaml
    /// </summary>
    public partial class AddEditFauna : MetroWindow {
        public bool Edit { get; set; } = false;
        public FaunaDTO? Animal { get; set; } = null;
        private bool _loading = false;

        public AddEditFauna() {
            InitializeComponent();
        }

        public AddEditFauna(bool edit, FaunaDTO animal) {
            InitializeComponent();

            Edit = edit;
            Animal = animal;

            LoadAnimalData();
        }

        private void LoadAnimalData() {
            lblTitle.Content = "Editar animal";

            txtName.Text = Animal!.Nombre;
            txtPicture.Text = Animal!.Foto;
            txtSpecies.Text = Animal.Especie;
            cbHabitat.SelectedIndex = Animal.Habitat - 1;
            txtDanger.Text = Animal.Peligro;
            txtDiet.Text = Animal.Dieta;
            txtDescription.Text = Animal.Descripcion;
            switchOriginal.IsOn = Animal.Original;
            txtCreatorEmail.Text = Animal.CreadorEmail;

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
                || txtSpecies.Text.Length == 0 || txtSpecies.Text.Length > 50 
                || txtDanger.Text.Length == 0 || txtDanger.Text.Length > 50
                || txtDiet.Text.Length > 20
                || txtDescription.Text.Length == 0
                || (!emailRegex.IsMatch(txtCreatorEmail.Text) && switchOriginal.IsOn)
            ) {
                MessageBox.Show("""
                    El nombre del animal debe tener entre 1 y 100 caracteres.
                    La especie del animal debe tener entre 1 y 50 caracteres.
                    El peligro del animal debe tener entre 1 y 50 caracteres.
                    La dieta del animal debe tener un máximo de 50 caracteres, en caso de querer especificarla.
                    La descripción del animal debe tener al menos 1 carácter.
                    """.Trim(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            }

            bool result;
            var animalPayload = new NewFaunaDTO {
                Foto = txtPicture.Text,
                Original = switchOriginal.IsOn,
                CreadorEmail = txtCreatorEmail.Text,
                Nombre = txtName.Text,
                Especie = txtSpecies.Text,
                Habitat = cbHabitat.SelectedIndex + 1,
                Peligro = txtDanger.Text,
                Dieta = txtDiet.Text,
                Descripcion = txtDescription.Text
            };

            if (Edit) {
                
                result = await AddEditFaunaProvider.UpdateFauna(Animal!.Id, animalPayload);

                if (!result) {
                    MessageBox.Show("Error actualizando el animal.", "Error", MessageBoxButton.OK);
                    _loading = false;
                    return;
                }

                MessageBox.Show("Animal actualizado correctamente.", "Success", MessageBoxButton.OK);

                new FaunaList().Show();
                Close();

                _loading = false;
                return;
            }

            result = await AddEditFaunaProvider.CreateFauna(animalPayload);

            if (!result) {
                MessageBox.Show("Error creando el animal.", "Error", MessageBoxButton.OK);
                _loading = false;
                return;
            }

            MessageBox.Show("Animal creado correctamente.", "Success", MessageBoxButton.OK);
            new FaunaList().Show();
            _loading = false;
            Close();
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex MyRegex();

        private void BtnClose(object sender, MouseButtonEventArgs e) {
            new FaunaList().Show();
            Close();
        }
    }
}
