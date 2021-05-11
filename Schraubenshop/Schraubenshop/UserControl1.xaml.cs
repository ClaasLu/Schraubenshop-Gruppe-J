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

        //Magic numbers für die Mindestgrößen
        const int minKh = 3;
        const int minKd = 5;        
        const int minGl = 5;

        Schraube myScrew = new Schraube();
        Material myMaterial = new Material();


        #region Start; Ende; Allgemeines

        // Startansicht
        public UserControl1()
        {
            InitializeComponent();

            // Sichtbarkeit am Anfang
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;




        }
        // Shutdown
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void hideAllGrids()
        {
            grid_Sechskant.Visibility = Visibility.Hidden;
            grid_Zylinderkopf.Visibility = Visibility.Hidden;
            grid_Gewindestift.Visibility = Visibility.Hidden;
            grid_Senkschraube.Visibility = Visibility.Hidden;
            grid_Startauswahl.Visibility = Visibility.Hidden;

        }

        #endregion

        #region Sechskant

        // Auswahl Sechskant
        private void btn_Sechskant_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Sechskant.Visibility = Visibility.Visible;
            myScrew.Kopfart = 1;
        }

        // Back button
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;
        }

        #region Hintergrund färben

        // Hintergrund färben Sechskantschraube
        private void tb_Kopfhoehe_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_Kopfdurchmesser_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKd)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }


        private void tb_Gewindelaenge_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minGl)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }




        #endregion

        #region Berechnung

        private void btn_CalculateSK_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_Kopfhoehe.Text, out kopfhoehe) && kopfhoehe >= minKh
                && double.TryParse(tb_Gewindelaenge.Text, out laenge) && laenge >= minGl
                && double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSK();
                MessageBox.Show("Preis:" + myScrew.Preis.ToString());
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }

        }
        #endregion

        #region Material Eingabe

        private void cb_Stahl_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 1;
        }

        private void cb_Edelstahl_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 2;

        }

        private void cb_Titan_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 3;

        }

        private void cb_Messing_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 4;

        }
        #endregion

        #region Gewindedurchmessereingabe

        private void cb_M1_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 1;
        }

        private void cb_M2_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 2;

        }

        private void cb_M3_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 3;

        }

        private void cb_M4_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 4;


        }

        private void cb_M5_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 5;

        }

        private void cb_M6_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 6;

        }

        private void cb_M8_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 8;

        }

        private void cb_M10_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 10;

        }

        private void cb_M12_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 12;

        }

        private void cb_M16_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 16;

        }

        private void cb_M20_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 20;

        }

        private void cb_M24_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 24;

        }

        private void cb_M30_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 30;

        }

        #endregion
        #endregion

        #region Zylinderkopf

        // Auswahl Zylinderkopf
        private void btn_Zylinderkopf_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Zylinderkopf.Visibility = Visibility.Visible;
            myScrew.Kopfart = 2;
        }

        // Back Button
        private void btn_backZK_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;
        }

        #region Hintergrund färben

        // Hintergrund färben Zylinderkopf
        private void tb_KopfhoeheZk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }

            
        }

        private void tb_KopfdurchmesserZk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKd)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_GewindelaengeZk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minGl)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
            
        }


        #endregion

        #region Berechnung
        private void btn_CalculateZK_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;            
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_KopfhoeheZk.Text, out kopfhoehe) && kopfhoehe >= minKh
                && double.TryParse(tb_GewindelaengeZk.Text, out laenge) && laenge >= minGl
                && double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSenk();
                MessageBox.Show("Preis:"+ myScrew.Preis.ToString());
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }
        }



        #endregion

        #region Material Eingabe

        private void cb_StahlZK_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 1;

        }

        private void cb_EdelstahlZK_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 2;

        }

        private void cb_TitanZK_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 3;

        }

        private void cb_MessingZK_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 4;

        }
        #endregion

        #region Gewindedurchmessereingabe
        private void cb_M1ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 1;

        }

        private void cb_M2ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 2;

        }

        private void cb_M3ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 3;

        }

        private void cb_M4ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 4;

        }

        private void cb_M5ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 5;

        }

        private void cb_M6ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 6;

        }

        private void cb_M8ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 8;

        }

        private void cb_M10ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 10;

        }

        private void cb_M12ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 12;

        }

        private void cb_M16ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 16;

        }

        private void cb_M20ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 20;

        }

        private void cb_M24ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 24;

        }

        private void cb_M30ZK_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 30;

        }

        #endregion

        #endregion

        #region Gewindestift

        // Auswahl Gewindestift
        private void btn_Gewindestift_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Gewindestift.Visibility = Visibility.Visible;


        }

        // Back Button
        private void btn_backGS_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;
        }


        #region Hintergrund färben

        private void tb_GewindelaengeGS_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }
        #endregion

        #region Berechnung

        private void btn_CalculateGS_Click(object sender, RoutedEventArgs e)
        {
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_GewindelaengeGS.Text, out laenge) && laenge >= minGl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Gewindelaenge = laenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungGS();
                MessageBox.Show("Preis:" + myScrew.Preis.ToString());
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }


        }
        #endregion

        #region Material Eingabe
        private void cb_StahlGS_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 1;
        }

        private void cb_EdelstahlGS_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 2;
        }

        private void cb_TitanGS_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 3;
        }

        private void cb_MessingGS_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 4;
        }
        #endregion

        #region Gewindedurchmesser Eingabe
        private void cb_M1GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 1;
        }

        private void cb_M2GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 2;
        }

        private void cb_M3GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 3;
        }

        private void cb_M4GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 4;
        }

        private void cb_M5GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 5;
        }

        private void cb_M6GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 6;
        }

        private void cb_M8GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 8;
        }

        private void cb_M10GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 10;
        }

        private void cb_M12GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 12;
        }

        private void cb_M16GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 16;
        }

        private void cb_M20GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 20;
        }

        private void cb_M24GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 24;
        }

        private void cb_M30GS_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 30;
        }
        #endregion



        #endregion

        #region Senkschraube

        // Auswahl Senkschraube
        private void btn_Senkschraube_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Senkschraube.Visibility = Visibility.Visible;

        }

        // Back Button
        private void btn_backSenk_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;
        }

        #region Hintergrund färben

        private void tb_KopfhoeheSenk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_KopfdurchmesserSenk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_GewindelaengeSenk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }




        #endregion

        #region Berechnung

        private void btn_CalculateSenk_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_KopfhoeheSenk.Text, out kopfhoehe) && kopfhoehe >= minKh
                && double.TryParse(tb_GewindelaengeSenk.Text, out laenge) && laenge >= minGl
                && double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungZK();
                MessageBox.Show("Preis:" + myScrew.Preis.ToString());
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }
        }
        #endregion

        #region Material Eingabe

        private void cb_StahlSenk_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 1;


        }

        private void cb_EdelstahlSenk_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 2;


        }

        private void cb_TitanSenk_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 3;

        }

        private void cb_MessingSenk_Selected(object sender, RoutedEventArgs e)
        {
            myMaterial.Materialschraube = 4;

        }

        #endregion

        #region Gewindedurchmesser Eingabe

        private void cb_M1Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 1;
        }

        private void cb_M2Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 2;
        }

        private void cb_M3Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 3;
        }

        private void cb_M4Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 4;
        }

        private void cb_M5Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 5;
        }

        private void cb_M6Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 6;
        }

        private void cb_M8Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 8;
        }

        private void cb_M10Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 10;
        }

        private void cb_M12Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 12;
        }

        private void cb_M16Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 16;
        }

        private void cb_M20Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 20;
        }

        private void cb_M24Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 24;
        }

        private void cb_M30Senk_Selected(object sender, RoutedEventArgs e)
        {
            myScrew.Gewindedurchmesser = 30;
        }







        #endregion

        #endregion

        
    }
}

