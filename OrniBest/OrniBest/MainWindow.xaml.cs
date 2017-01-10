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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new PageInicial();
            
            
        }
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void comando_fechar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void comando_minimizar(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btt_utilizador_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new Utilizador();
        }

        private void btt_pinicial_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PageInicial();
            
        }
        private void frame_removenavbar(object sender, EventArgs e)
        {
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void btt_passaro_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new passaroMenu();
        }

        private void Info_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

    }
}