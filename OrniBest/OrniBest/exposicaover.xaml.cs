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
    /// Interaction logic for exposicaover.xaml
    /// </summary>
    public partial class exposicaover : Page
    {
        public exposicaover()
        {
            InitializeComponent();
            List<competicoes2> utilG = new List<competicoes2>();
            utilG = competicoes2.lerRegistos();
            if (utilG.Count != 0)
            {
                foreach (var x in utilG)
                {
                    string mostrar = x.id_exposicao.ToString() + " - " + x.nome;

                    lb_gcomp.Items.Add(mostrar);




                }
            }
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            string id_comp = tb_idcomp.Text;
            long codgaiolalong = Convert.ToInt64(id_comp);
            List<competicoes2> utilG = new List<competicoes2>();
            utilG = competicoes2.lerRegistos();

            foreach (var x in utilG)
            {

                if (x.id_exposicao == codgaiolalong)
                {
                    tb_id.Text = x.id_exposicao.ToString();
                    tb_nome.Text = x.nome.ToString();
                    tb_morada.Text = x.morada.ToString();
                    tb_localizacao.Text = x.cidade.ToString();
                    data_exposicao.SelectedDate = System.Convert.ToDateTime(x.data);



                }
            }
           
        }

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Competicoes.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
