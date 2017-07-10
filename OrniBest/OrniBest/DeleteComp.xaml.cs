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
    /// Interação lógica para DeleteComp.xam
    /// </summary>
    public partial class DeleteComp : Page
    {
        public DeleteComp()
        {
            try { 
            InitializeComponent();
            List<competicoes2> utilG = new List<competicoes2>();
            utilG = competicoes2.lerRegistos();
            if (utilG.Count != 0)
            {
                foreach (var x in utilG)
                {
                    string mostrar = x.id_exposicao.ToString() + " - " + x.nome;

                    lb_expo.Items.Add(mostrar);




                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui ler as exposições." + " " + ex.Message);

            }
        }

        private void btt_deletef_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id_expo = Convert.ToInt32(tb_idexpo.Text);
                competicoes2.DeleteExposicao(id_expo);
                lb_expo.Items.Clear();
                List<competicoes2> utilG = new List<competicoes2>();
                utilG = competicoes2.lerRegistos();
                if (utilG.Count != 0)
                {
                    foreach (var x in utilG)
                    {
                        string mostrar = x.id_exposicao.ToString() + " - " + x.nome;

                        lb_expo.Items.Add(mostrar);




                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui apagar os dados." + " " + ex.Message);
                
            }
        }

        private void btt_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Competicoes.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
