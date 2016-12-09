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
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Title = "Selecione uma imagem";
            openFileDialog1.Filter = "All supported graphics | *.jpg; *.jpeg; *.png | " +
             "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                try
                {

                    image_utilizador.Source = new BitmapImage(new Uri(openFileDialog1.FileName));
                    
                    



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errou! Não introduziu corretamente! " + ex.Message);
                }

            }
        }
    }
}
