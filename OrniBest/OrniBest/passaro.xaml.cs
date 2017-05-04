﻿using System;
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
    /// Interaction logic for passaro.xaml
    /// </summary>
    public partial class passaro : Page
    {
        public passaro()
        {
            InitializeComponent();
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
        }

       

        private void btt_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btt_adicionar_Click(object sender, RoutedEventArgs e)
        {

            int especie = cb_especie.SelectedIndex;
            int id_gaiola = 0;
            int id_utilizador = 1;
            string sexo;
            string foto = "aindan";
            if (macho.IsChecked == true)
            {
                sexo = "macho";
                passaro2 registo = new passaro2(System.Convert.ToInt32(tb_anilha.Text), System.Convert.ToInt32(tb_anilhamae.Text), System.Convert.ToInt32(tb_anilhapai.Text), sexo, tb_nome.Text, foto, tb_alimento.Text, id_utilizador, especie, id_gaiola);
                passaro2.AddRegistos(registo);

            }
            if (femea.IsChecked == true)
            {
                sexo = "femea";
                passaro2 registo = new passaro2(System.Convert.ToInt32(tb_anilha.Text), System.Convert.ToInt32(tb_anilhamae.Text), System.Convert.ToInt32(tb_anilhapai.Text), sexo, tb_nome.Text, foto, tb_alimento.Text, id_utilizador, especie, id_gaiola);
                passaro2.AddRegistos(registo);
            }




        }

        private void btt_selecionari_Click(object sender, RoutedEventArgs e)
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

        private void cb_especie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
           
        }
    }
}
