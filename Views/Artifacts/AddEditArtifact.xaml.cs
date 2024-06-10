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
using WPF.Data.Artifacts;
using WPF.Models.Artifacts;

namespace WPF.Views.Artifacts {
    /// <summary>
    /// Lógica de interacción para AddEditArtifact.xaml
    /// </summary>
    public partial class AddEditArtifact : MetroWindow {
        public bool Edit { get; set; } = false;
        public ArtifactDTO? Artefacto { get; set; } = null;
        public List<string>? IDsExploradores { get; set; } = [];
        private bool _loading = false;
        public AddEditArtifact() {
            InitializeComponent();

            LoadDelverIds();
        }

        public AddEditArtifact(bool edit, ArtifactDTO artifact) {
            InitializeComponent();

            Edit = edit;
            Artefacto = artifact;

            LoadDelverIds();
            LoadArtifactData();
        }

        private void LoadArtifactData() {
            lblTitle.Content = "Editar artefacto";

            txtName.Text = Artefacto!.Nombre;
            txtPicture.Text = Artefacto!.Foto;
            foreach (var item in cbGrade.Items) {
                if (item is ComboBoxItem cbItem && cbItem.Content.ToString() == Artefacto.Grado) {
                    cbGrade.SelectedItem = cbItem;
                    break;
                } else {
                    cbGrade.SelectedIndex = 0;
                }
            }
            txtEffect.Text = Artefacto.Efecto;
            txtDescription.Text = Artefacto.Descripcion;
            txtOrigin.Text = Artefacto.Origen;
            txtOwnerId.Text = Artefacto.DuenyoId + "";
            switchOriginal.IsOn = Artefacto.Original;
            txtCreatorEmail.Text = Artefacto.CreadorEmail;

            switchOriginal.IsEnabled = false;
            txtCreatorEmail.IsReadOnly = true;
            txtCreatorEmail.IsEnabled = false;
        }

        private async void LoadDelverIds() {
            List<string> listaIDs = await AddEditArtifactProvider.GetDelversIdList();
            if (listaIDs.Count > 0) {
                IDsExploradores = listaIDs;
            }
        }

        private async void BtnEnviar(object sender, RoutedEventArgs e) {
            if (_loading) return;
            _loading = true;

            Regex emailRegex = MyRegex();

            if (
                txtName.Text.Length == 0 || txtName.Text.Length > 100
                || txtEffect.Text.Length == 0
                || txtDescription.Text.Length == 0
                || (txtOwnerId.Text.Length > 0 && !IDsExploradores!.Contains(txtOwnerId.Text))
                || (!emailRegex.IsMatch(txtCreatorEmail.Text) && switchOriginal.IsOn)
            ) {
                MessageBox.Show("""
                    El nombre del artefacto debe tener entre 1 y 100 caracteres.
                    El efecto del artefacto debe tener al menos 1 carácter.
                    La descripción del artefacto debe tener al menos 1 carácter.
                    El ID del dueño debe ser el de un explorador existente. 
                    En caso de no conocer el ID o no querer introducirlo, dejar en blanco.
                    """.Trim(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loading = false;
                return;
            }

            bool result;
            var artifactPayload = new NewArtifactDTO {
                Foto = txtPicture.Text,
                Original = switchOriginal.IsOn,
                CreadorEmail = txtCreatorEmail.Text,
                Nombre = txtName.Text,
                Grado = ((ComboBoxItem)cbGrade.SelectedItem).Tag.ToString()!,
                Efecto = txtEffect.Text,
                Descripcion = txtDescription.Text,
                Origen = txtOrigin.Text
            };

            if (txtOwnerId.Text != "") {
                artifactPayload.DuenyoId = int.Parse(txtOwnerId.Text);
            }

            if (Edit) {

                result = await AddEditArtifactProvider.UpdateArtifact(Artefacto!.Id, artifactPayload);

                if (!result) {
                    MessageBox.Show("Error actualizando el artefacto.", "Error", MessageBoxButton.OK);
                    _loading = false;
                    return;
                }

                MessageBox.Show("Artefacto actualizado correctamente.", "Success", MessageBoxButton.OK);

                new ArtifactList().Show();
                Close();

                _loading = false;
                return;
            }

            result = await AddEditArtifactProvider.CreateArtifact(artifactPayload);

            if (!result) {
                MessageBox.Show("Error creando el artefacto.", "Error", MessageBoxButton.OK);
                _loading = false;
                return;
            }

            MessageBox.Show("Artefacto creado correctamente.", "Success", MessageBoxButton.OK);
            new ArtifactList().Show();
            _loading = false;
            Close();
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex MyRegex();

        private void BtnClose(object sender, MouseButtonEventArgs e) {
            new ArtifactList().Show();
            Close();
        }
    }
}
