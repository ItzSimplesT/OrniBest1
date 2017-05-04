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

        private void btt_deletef_Click(object sender, RoutedEventArgs e)
        {
            int n_anilhapagar = Convert.ToInt32(tb_n_anilha.Text);
            passaro2.DeletePassaro(n_anilhapagar);
            lb_pass.Items.Clear();
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

        private void btt_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("passaroMenu.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
