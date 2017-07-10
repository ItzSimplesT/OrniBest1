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
    /// Interaction logic for passaroverxaml.xaml
    /// </summary>
    public partial class passaroverxaml : Page
    {
        public passaroverxaml()
        {
            InitializeComponent();
            try { 
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui ler os pássaros." + " " + ex.Message);

            }
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui ler as especies." + " " + ex.Message);

            }
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui ler as gaiolas." + " " + ex.Message);

            }
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nanilha = tb_nanilha2.Text;
                long nanilhaLong = Convert.ToInt64(nanilha);
                List<passaro2> utilP = new List<passaro2>();
                utilP = passaro2.lerRegistos();

                foreach (var x in utilP)
                {

                    if (x.nanilha == nanilhaLong)
                    {
                        tb_anilha.Text = x.nanilha.ToString();
                        tb_nome.Text = x.nome.ToString();
                        tb_alimento.Text = x.Alimento.ToString();
                        tb_anilhamae.Text = x.nanilhamae.ToString();
                        tb_anilhapai.Text = x.nanilhapai.ToString();
                        cb_especie.SelectedIndex = System.Convert.ToInt32(x.id_especie) - 1;
                        cb_gaiola.SelectedIndex = System.Convert.ToInt32(x.id_gaiola) - 1;
                        if (x.genero == "macho")
                        {
                            macho.IsChecked = true;


                        }
                        if (x.genero == "femea")
                        {
                            femea.IsChecked = true;


                        }




                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não consegui encontrar esse pássaro." + " " + ex.Message);
                
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
    }
}
