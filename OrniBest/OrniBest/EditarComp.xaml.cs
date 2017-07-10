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
    /// Interação lógica para EditarComp.xam
    /// </summary>
    public partial class EditarComp : Page
    {
        public EditarComp()
        {
            InitializeComponent();
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui ler as gaiolas." + " " + ex.Message);

            }
        }

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Competicoes.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui encontrar essa exposição." + " " + ex.Message);

            }
        }

        private void btt_editarcomp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                competicoes2 registo = new competicoes2(System.Convert.ToInt32(tb_id.Text), tb_nome.Text, data_exposicao.Text, tb_localizacao.Text, tb_morada.Text);
                competicoes2.UptadeExposicao(registo, System.Convert.ToInt32(tb_id.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui editar a Exposição" + " " + ex.Message);
                
            }
        }
    }
}
