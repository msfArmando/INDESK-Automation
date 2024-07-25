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

namespace IndeskAutomation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IniciarAutomacao(object sender, RoutedEventArgs e)
        {
            try
            {
                var linkWebSite = "https://unibra.indesk.com.br/adm/#/app/guiche";
                var codSenha = string.Empty;
                Automations auto = new Automations();

                if (CheckBox1.IsChecked == true) codSenha = "SEC";
                if (CheckBox2.IsChecked == true) codSenha = "ATFIN";

                auto.GoToWebSite(linkWebSite);
                auto.Login(txtUserAdmin.Text, txtPasswordAdmin.Text);
                auto.CadastrarSenha(txtPermission.Text, codSenha);
                auto.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox1.IsChecked = false;
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox2.IsChecked = false;
        }
    }
}