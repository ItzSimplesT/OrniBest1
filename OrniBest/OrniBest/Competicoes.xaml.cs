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
    /// Interação lógica para Competicoes.xam
    /// </summary>
    public partial class Competicoes : Page
    {
        public Competicoes()
        {
            InitializeComponent();
            
        }

        private void btt_adicionarExposicao_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("AdicionarComp.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_editarExposicao_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditarComp.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_deleteExposicao_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("DeleteComp.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
