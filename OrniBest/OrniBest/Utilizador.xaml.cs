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
            List<Clube2> utilP = new List<Clube2>();
            utilP = Clube2.lerRegistos();
            if (utilP.Count != 0)
            {
                foreach (var x in utilP)
                {
                    string mostrar = x.id_clube + "-" + x.nome;

                    cb_clube.Items.Add(mostrar);
                    




                }
            }

            List<utilizador2> utilU = new List<utilizador2>();
            utilU = utilizador2.lerRegistos();
            if (utilU.Count != 0)
            {
                foreach (var x in utilU)
                {
                    tb_nome.Text = x.nome;
                    tb_morada.Text = x.morada;
                    tb_STAM.Text = x.stam.ToString();
                    tb_telemovel.Text = x.telemovel.ToString();
                    tb_codigopostal.Text = x.codigo_postal.ToString();
                    data_nascimento.Text = x.data_nascimento.ToString();
                    



                    





                }
            }

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

        private void bt_salvar_Click(object sender, RoutedEventArgs e)
        {
            int clube = cb_clube.SelectedIndex;
            DateTime now = DateTime.Now;
            if(data_nascimento.Text >=  now)
            utilizador2 registo = new utilizador2(tb_nome.Text, System.Convert.ToInt32(tb_telemovel.Text),tb_STAM.Text,data_nascimento.Text,tb_morada.Text, tb_codigopostal.Text, clube);
            utilizador2.AddRegistos(registo);
        }
    }
}
