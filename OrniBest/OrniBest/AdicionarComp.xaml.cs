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
    /// Interação lógica para AdicionarComp.xam
    /// </summary>
    public partial class AdicionarComp : Page
    {
        public AdicionarComp()
        {
            InitializeComponent();
        }

        private void btt_adicionarcomp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                competicoes2 registo = new competicoes2(System.Convert.ToInt32(tb_idexposicao.Text), tb_nome.Text, data_exposicao.Text, tb_localizacao.Text, tb_morada.Text);
                competicoes2.AddRegistos(registo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui inserir dados. " + " " + ex.Message);
                
            }
        }

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Competicoes.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
