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
    /// Interaction logic for familia.xaml
    /// </summary>
    public partial class familia : Page
    {
        public familia()
        {
            InitializeComponent();
        }

        private void btt_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            List<passaro2> utilP = new List<passaro2>();
            utilP = passaro2.lerRegistos();
            if(tb_anilhamae.Text != "" && tb_anilhapai.Text != "")
            {
                if (utilP.Count != 0)
                {
                    foreach (var x in utilP)
                    {
                        if (tb_anilhamae.Text == x.nanilhamae.ToString() && tb_anilhapai.Text == x.nanilhapai.ToString())
                        {
                            string mostrar = x.nanilha + "-" + x.nome;
                            lb_pass.Items.Add(mostrar);


                        }   
                        else
                        {

                            MessageBox.Show("Não encontramos na base dados a anilha que procura!");

                        }
                    }
                }

            }
            else if (tb_anilhamae.Text != "" && tb_anilhapai.Text == "")
            {
                if (utilP.Count != 0)
                {
                    foreach (var x in utilP)
                    {
                        if (tb_anilhamae.Text == x.nanilhamae.ToString())
                        {
                            string mostrar = x.nanilha + "-" + x.nome;
                            lb_pass.Items.Add(mostrar);


                        }
                        else
                        {

                            MessageBox.Show("Não encontramos na base dados a anilha que procura!");

                        }
                    }
                }

            }
            else if (tb_anilhamae.Text == "" && tb_anilhapai.Text != "")
            {
                if (utilP.Count != 0)
                {
                    foreach (var x in utilP)
                    {
                        if (tb_anilhapai.Text == x.nanilhapai.ToString())
                        {
                            string mostrar = x.nanilha + "-" + x.nome;
                            lb_pass.Items.Add(mostrar);


                        }
                        else
                        {

                            MessageBox.Show("Não encontramos na base dados a anilha que procura!");

                        }
                    }
                }

            }

        }
    }
}
