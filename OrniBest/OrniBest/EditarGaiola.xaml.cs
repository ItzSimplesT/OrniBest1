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
    /// Interaction logic for EditarGaiola.xaml
    /// </summary>
    public partial class EditarGaiola : Page
    {
        public EditarGaiola()
        {
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

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MenuGaiola.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_adicionar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
