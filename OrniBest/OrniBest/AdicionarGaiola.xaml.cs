using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrniBest
{
    /// <summary>
    /// Interaction logic for AdicionarGaiola.xaml
    /// </summary>
    public partial class AdicionarGaiola : Page
    {
        public AdicionarGaiola()
        {
            InitializeComponent();
        }

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MenuGaiola.xaml", UriKind.RelativeOrAbsolute));

        }

        private void btt_adicionargaiola_Click(object sender, RoutedEventArgs e)
        {
            Gaiola2 registo = new Gaiola2(System.Convert.ToInt32(tb_codgaiola.Text), System.Convert.ToInt32(tb_lotacao.Text), System.Convert.ToInt32(tb_comprimento.Text), System.Convert.ToInt32(tb_largura.Text), System.Convert.ToInt32(tb_altura.Text));
            Gaiola2.AddRegistos(registo, System.Convert.ToInt32(tb_codgaiola.Text));
        }
    }
}
