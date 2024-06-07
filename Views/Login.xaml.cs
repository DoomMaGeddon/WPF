using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using admin;
using admin.login.data;
using MahApps.Metro.Controls;
using WPF.Views.Users;

namespace WPF.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : MetroWindow {
        private bool _loading = false;

        public Login() {
            InitializeComponent();

            HandleAlreadyLogged();
        }

        private async void HandleAlreadyLogged() {
            Store.Instance.LoadState();

            var token = Store.Instance.GetStateItem("Token");

            if ((token ?? "") == "") {
                return;
            }

            if (!await LoginProvider.IsTokenValid()) {
                Store.Instance.RemoveStateItem("Token");
                Store.Instance.RemoveStateItem("UserDTO");
                return;
            }

            new UserList().Show();
            Close();
        }

        private async void LoginClicked(object sender, RoutedEventArgs e) {
            if (_loading) {
                return;
            }

            _loading = true;

            if (email.Text.Length == 0 || password.Password.Length < 8) {
                MessageBox.Show("Debes introducir un correo y una contraseña de 8 caracteres como mínimo.", "Error");
            }

            var response = await LoginProvider.Login(email.Text, password.Password);

            if (response.User != null && response.Token != null) {
                Store.Instance.SetStateItem("UserDTO", response.User);
                Store.Instance.SetStateItem("Token", response.Token);

                new UserList().Show();
                _loading = false;
                Close();
            } else {
                MessageBox.Show("No se ha podido iniciar sesión. Asegúrese de que está utilizando credenciales de administrador", "Error");
                _loading = false;
            }            
        }
    }
}