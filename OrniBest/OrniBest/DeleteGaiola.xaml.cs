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
    /// Interaction logic for DeleteGaiola.xaml
    /// </summary>
    public partial class DeleteGaiola : Page
    {
        public DeleteGaiola()
        {
            InitializeComponent();
            try { 
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

        private void btt_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MenuGaiola.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_deletef_Click(object sender, RoutedEventArgs e)
        {
            try { 
            int codgaiola = Convert.ToInt32(tb_codgaiola.Text);
            Gaiola2.DeleteGaiola(codgaiola);
            lb_gaiola.Items.Clear();
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
                MessageBox.Show("Não consegui apagar os dados." + " " + ex.Message);

            }
        }
    }
}
