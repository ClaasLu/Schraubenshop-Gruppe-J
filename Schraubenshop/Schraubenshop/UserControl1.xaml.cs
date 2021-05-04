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

namespace Schraubenshop
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        double kopfhoehe;

        public UserControl1()
        {
            InitializeComponent();
            
        }

        private void btn_Sechskant_Click(object sender, RoutedEventArgs e)
        {
            grid_Startauswahl.Visibility = Visibility.Hidden;
            grid_Sechskant.Visibility = Visibility.Visible;
        }

        private void btn_Zylinderkopf_Click(object sender, RoutedEventArgs e)
        {
            grid_Startauswahl.Visibility = Visibility.Hidden;
            grid_Zylinderkopf.Visibility = Visibility.Visible;
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void Gewindedurchmesser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_CalculateSK_Click(object sender, RoutedEventArgs e)
        {

        }

        static void tb_Kopfhoehe_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb_Kopfhoehe = (TextBox)sender;
            double kopfhoehe;


                if (double.TryParse(tb_Kopfhoehe.Text, out kopfhoehe)) // && kopfhoehe  >= minKh)
                {
                    tb_Kopfhoehe.Background = Brushes.LightGreen;
                    //return kopfhoehe;    
                }
                else
                {
                    tb_Kopfhoehe.Background = Brushes.OrangeRed;
                }
        }
    }
}
