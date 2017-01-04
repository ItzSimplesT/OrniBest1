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
    /// Interaction logic for passaroMenu.xaml
    /// </summary>
    public partial class passaroMenu : Page
    {
        

        public passaroMenu()
        {
            InitializeComponent();
        }

        private void btt_editarPassaro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroEdit.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_deletePassaro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroDelete.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_adicionarPassaro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaro.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
