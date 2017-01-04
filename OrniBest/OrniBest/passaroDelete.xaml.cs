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
    /// Interaction logic for passaroDelete.xaml
    /// </summary>
    public partial class passaroDelete : Page
    {
        public passaroDelete()
        {
            InitializeComponent();
        }

        private void btt_deletef_Click(object sender, RoutedEventArgs e)
        {
            var res = Xceed.Wpf.Toolkit.MessageBox.Show(
                           "Tens a certeza que quer apagar?",
                           "Atenção",
                           MessageBoxButton.YesNoCancel,
                           MessageBoxImage.None,
                           (Style)Resources["MessageBoxStyle1"]
                       );


            if ("No" == res.ToString())
            {
            }
            if ("Yes" == res.ToString())
            {
            }

        }

        private void btt_voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroMenu.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
