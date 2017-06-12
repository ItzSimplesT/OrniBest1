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
using Microsoft.Win32;
using System.Diagnostics;

namespace OrniBest
{
    /// <summary>
    /// Interaction logic for passaroEdit.xaml
    /// </summary>
    public partial class passaroEdit : Page
    {
        public passaroEdit()
        {
            InitializeComponent();
            List<passaro2> utilP = new List<passaro2>();
            utilP = passaro2.lerRegistos();
            if (utilP.Count != 0)
            {
                foreach (var x in utilP)
                {
                    string mostrar = x.nanilha + "-" + x.nome;

                    lb_pass.Items.Add(mostrar);




                }
            }
            List<Especie> utilE = new List<Especie>();
            utilE = Especie.lerRegistos();
            if (utilE.Count != 0)
            {
                foreach (var x in utilE)
                {
                    string mostrar = x.id_especie + "-" + x.nome;

                    cb_especie.Items.Add(mostrar);




                }
            }
            List<Gaiola2> UtilG = new List<Gaiola2>();
            UtilG = Gaiola2.lerRegistos();
            if (UtilG.Count != 0)
            {
                foreach (var x in UtilG)
                {
                    string mostrar = x.codgaiola.ToString();

                    cb_gaiola.Items.Add(mostrar);




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

                    image.Source = new BitmapImage(new Uri(ofd1.FileName));
                    image.Stretch = Stretch.Fill;




 


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errou! Não introduziu corretamente! " + ex.Message);
                }

            }
        }
        
        private void btt_save_Click(object sender, RoutedEventArgs e)
        {
            int especie = cb_especie.SelectedIndex;
            int id_gaiola = cb_gaiola.SelectedIndex;
            int id_utilizador = 1;
            string sexo;
            string foto = "aindan";
            if (macho.IsChecked == true)
            {
                sexo = "macho";
                passaro2 registo = new passaro2(System.Convert.ToInt32(tb_anilha.Text), System.Convert.ToInt32(tb_anilhamae.Text), System.Convert.ToInt32(tb_anilhapai.Text), sexo, tb_nome.Text, foto, tb_alimento.Text, id_utilizador, especie, id_gaiola);
                passaro2.UptadePassaro(registo, System.Convert.ToInt64(tb_anilha.Text));
                

            }
            else if (femea.IsChecked == true)
            {
                sexo = "femea";
                passaro2 registo = new passaro2(System.Convert.ToInt32(tb_anilha.Text), System.Convert.ToInt32(tb_anilhamae.Text), System.Convert.ToInt32(tb_anilhapai.Text), sexo, tb_nome.Text, foto, tb_alimento.Text, id_utilizador, especie, id_gaiola);
                passaro2.UptadePassaro(registo, System.Convert.ToInt64(tb_anilha.Text));
            }
        }

        private void btt_Voltar1_Click(object sender, RoutedEventArgs e)
        {
           
            lb_pass.Items.Clear();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
          
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            string nanilha = tb_nanilha2.Text;
            long nanilhaLong = Convert.ToInt64(nanilha);
            List<passaro2> utilP = new List<passaro2>();
            utilP = passaro2.lerRegistos();

            foreach (var x in utilP)
            {
              
                if(x.nanilha == nanilhaLong)
                {
                   tb_anilha.Text = x.nanilha.ToString();
                    tb_nome.Text = x.nome.ToString();                   
                    tb_alimento.Text = x.Alimento.ToString();
                    tb_anilhamae.Text = x.nanilhamae.ToString();
                    tb_anilhapai.Text = x.nanilhapai.ToString();



                }



            }


        }
    }
}
