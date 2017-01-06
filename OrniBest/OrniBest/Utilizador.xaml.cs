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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace OrniBest
{
    /// <summary>
    /// Interaction logic for Utilizador.xaml
    /// </summary>
    public partial class Utilizador : Page
    {
        public Utilizador()
        {
            InitializeComponent();
            

            
        }

        private void btt_selecionarimagem_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofd1 = new OpenFileDialog();

            ofd1.InitialDirectory = "c:\\";
            ofd1.Title = "Selecione uma imagem";
            ofd1.Filter = "All supported graphics | *.jpg; *.jpeg; *.png | " +
             "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;

            if (ofd1.ShowDialog() == true)
            {
                try
                {

                    image_utilizador.Source = new BitmapImage(new Uri(ofd1.FileName));
                    image_utilizador.Stretch = Stretch.Fill;






                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errou! Não introduziu corretamente! " + ex.Message);
                }

            }

        }
        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
