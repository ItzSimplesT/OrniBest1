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
    /// Interaction logic for MenuGaiola.xaml
    /// </summary>
    public partial class MenuGaiola : Page
    {
        public MenuGaiola()
        {
            InitializeComponent();
        }

        private void btt_AdicionarGaiola_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("AdicionarGaiola.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
