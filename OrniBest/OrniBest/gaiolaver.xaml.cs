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
    /// Interaction logic for gaiolaver.xaml
    /// </summary>
    public partial class gaiolaver : Page
    {
        public gaiolaver()
        {
            try { 
            InitializeComponent();
            List<Gaiola2> utilG = new List<Gaiola2>();
            utilG = Gaiola2.lerRegistos();
            if (utilG.Count != 0)
            {
                foreach (var x in utilG)
                {
                    string mostrar = x.codgaiola.ToString();

                    lb_gaiola.Items.Add(mostrar);




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
            nav.Navigate(new Uri("MenuGaiola.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cod_gaiola = tb_codgaiola.Text;
                long codgaiolalong = Convert.ToInt64(cod_gaiola);
                List<Gaiola2> utilG = new List<Gaiola2>();
                utilG = Gaiola2.lerRegistos();

                foreach (var x in utilG)
                {

                    if (x.codgaiola == codgaiolalong)
                    {
                        tb_id.Text = x.codgaiola.ToString();
                        tb_comp.Text = x.comprimento.ToString();
                        tb_larg.Text = x.largura.ToString();
                        tb_altura.Text = x.altura.ToString();
                        tb_lotacao.Text = x.lotacao.ToString();



                    }



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não consegui encontrar essa gaiola." + " " + ex.Message);

            }
        }
}
}
