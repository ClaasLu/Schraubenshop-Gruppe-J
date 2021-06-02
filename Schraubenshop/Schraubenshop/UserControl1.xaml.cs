using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        const int maxKh = 30;
        const int maxKd = 46;
        const int maxGl = 75;
        const int maxSl = 70;

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
            System.Environment.Exit(0);
        }

        private void hideAllGrids()
        {
            grid_Sechskant.Visibility = Visibility.Hidden;
            grid_Zylinderkopf.Visibility = Visibility.Hidden;
            grid_Gewindestift.Visibility = Visibility.Hidden;
            grid_Senkschraube.Visibility = Visibility.Hidden;
            grid_Startauswahl.Visibility = Visibility.Hidden;
            grid_Ausgabe.Visibility = Visibility.Hidden;

            btn_ContinueSk.Visibility = Visibility.Hidden;
            btn_ContinueZk.Visibility = Visibility.Hidden;
            btn_ContinueGs.Visibility = Visibility.Hidden;
            btn_ContinueSenk.Visibility = Visibility.Hidden;

            btn_Catia.Visibility = Visibility.Hidden;
            btn_CatiaZk.Visibility = Visibility.Hidden;
            btn_CatiaGs.Visibility = Visibility.Hidden;
            btn_CatiaSenk.Visibility = Visibility.Hidden;

            lab_kdmax.Visibility = Visibility.Hidden;
            lab_khmax.Visibility = Visibility.Hidden;
            lab_glmax.Visibility = Visibility.Hidden;
            lab_slmax.Visibility = Visibility.Hidden;
            lab_Gewinde.Visibility = Visibility.Hidden;

            lab_kdmaxZk.Visibility = Visibility.Hidden;
            lab_khmaxZk.Visibility = Visibility.Hidden;
            lab_glmaxZk.Visibility = Visibility.Hidden;
            lab_slmaxZk.Visibility = Visibility.Hidden;
            lab_GewindeZk.Visibility = Visibility.Hidden;


            lab_glmaxGs.Visibility = Visibility.Hidden;

            lab_kdmaxSenk.Visibility = Visibility.Hidden;           
            lab_glmaxSenk.Visibility = Visibility.Hidden;
            lab_slmaxSenk.Visibility = Visibility.Hidden;
            lab_GewindeSk.Visibility = Visibility.Hidden;


            chb_Info.IsChecked = false;
            chb_InfoZk.IsChecked = false;
            chb_InfoGs.IsChecked = false;
            chb_InfoSenk.IsChecked = false;
        }

        //Fensterfixierung
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).ResizeMode = ResizeMode.NoResize;
        }

        //Order Button in Ausgabe
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {           

            MessageBox.Show("Vielen Dank für Ihre Bestellung!");

            hideAllGrids();

            grid_Startauswahl.Visibility = Visibility.Visible;
        }

        //Ausgabebilder Hidden
        private void imgHidden()
        {
            img_Sechskantschraube.Visibility = Visibility.Hidden;
            img_Zylinderschraube.Visibility = Visibility.Hidden;
            img_Gewindestift.Visibility = Visibility.Hidden;
            img_Senkschraube.Visibility = Visibility.Hidden;
        }
        #endregion
                
        #region Sechskant

        // Auswahl Sechskant
        private void btn_Sechskant_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Sechskant.Visibility = Visibility.Visible;

        }

        // Back button
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;

        }

        // InfoBox
        private void chb_Info_Click(object sender, RoutedEventArgs e)
        {
            if (lab_kdmax.Visibility == Visibility.Hidden)
            {
                lab_kdmax.Visibility = Visibility.Visible;
                lab_khmax.Visibility = Visibility.Visible;
                lab_glmax.Visibility = Visibility.Visible;
                lab_slmax.Visibility = Visibility.Visible;
                lab_Gewinde.Visibility = Visibility.Visible;
            }
            else
            {
                lab_kdmax.Visibility = Visibility.Hidden;
                lab_khmax.Visibility = Visibility.Hidden;
                lab_glmax.Visibility = Visibility.Hidden;
                lab_slmax.Visibility = Visibility.Hidden;
                lab_Gewinde.Visibility = Visibility.Hidden;
            }

        }

        #region Hintergrund färben

        // Hintergrund färben Sechskantschraube
        private void tb_Kopfhoehe_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh && res <= maxKh)
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

            if (Double.TryParse(tb.Text, out res) && res >= minKd && res <= maxKd && res > myScrew.Gewindedurchmesser)
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

            if (Double.TryParse(tb.Text, out res) && res >= minGl && res <= maxGl)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_Schaftlänge_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= 0 && res <= maxSl)
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
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_Kopfhoehe.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_Gewindelaenge.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_Schaftlänge.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSK();

                tb_Sechskant_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Sechskant_Kh.Text = Convert.ToString(myScrew.Kopfhoehe);
                tb_Sechskant_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Sechskant_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Sechskant_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

                btn_ContinueSk.Visibility = Visibility.Visible;
                btn_Catia.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_Kopfdurchmesser.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_Kopfdurchmesser.Background = Brushes.Red;
                }
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

        #region Drehrichtung
        private void Rechtsgewinde_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Rechtsgewinde";
            myScrew.Drehsinn = true;
        }

        private void Linksgewinde_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Linksgewinde";
            myScrew.Drehsinn = false;
        }
        #endregion

        #region Ausgabe
        private void btn_ContinueSk_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_Kopfhoehe.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_Gewindelaenge.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_Schaftlänge.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSK();

                tb_Sechskant_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Sechskant_Kh.Text = Convert.ToString(myScrew.Kopfhoehe);
                tb_Sechskant_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Sechskant_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Sechskant_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);
                

                hideAllGrids();

                imgHidden();
                img_Sechskantschraube.Visibility = Visibility.Visible;

                myMaterial.MaterialAg();
                grid_Ausgabe.Visibility = Visibility.Visible;

                tb_SchraubenartAg.Text = "Sechskantschraube";
                tb_GewindeAg.Text = myScrew.Gewinderichtung;
                tb_BezeichnungAg.Text = "M" + Convert.ToString(myScrew.Gewindedurchmesser) + "x" + Convert.ToString(myScrew.Gesamtlaenge);
                tb_KopfAg.Text = "SW: " + Convert.ToString(myScrew.Kopfdurchmesser) + ";    Kopfhöhe: " + Convert.ToString(myScrew.Kopfhoehe) + "mm";

                tb_GewichtAg.Text = "Gewicht: " + Convert.ToString(myScrew.Gewicht) + "g";
                tb_MaterialAg.Text = "Material: " + myMaterial.Materialausgabe;

                tb_PreisAg.Text = "Preis: " + Convert.ToString(myScrew.Preis) + " Euro";
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_Kopfdurchmesser.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_Kopfdurchmesser.Background = Brushes.Red;
                }
            }

            
        }
        #endregion

        #endregion

        #region Zylinderkopf

        // Auswahl Zylinderkopf
        private void btn_Zylinderkopf_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Zylinderkopf.Visibility = Visibility.Visible;
        }

        // Back Button
        private void btn_backZK_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrids();
            grid_Startauswahl.Visibility = Visibility.Visible;
        }

        // Info Box
        private void chb_InfoZk_Click(object sender, RoutedEventArgs e)
        {

            if (lab_kdmaxZk.Visibility == Visibility.Hidden)
            {
                lab_kdmaxZk.Visibility = Visibility.Visible;
                lab_khmaxZk.Visibility = Visibility.Visible;
                lab_glmaxZk.Visibility = Visibility.Visible;
                lab_slmaxZk.Visibility = Visibility.Visible;
                lab_GewindeZk.Visibility = Visibility.Visible;
            }
            else
            {
                lab_kdmaxZk.Visibility = Visibility.Hidden;
                lab_khmaxZk.Visibility = Visibility.Hidden;
                lab_glmaxZk.Visibility = Visibility.Hidden;
                lab_slmaxZk.Visibility = Visibility.Hidden;
                lab_GewindeZk.Visibility = Visibility.Hidden;
            }


        }

        #region Hintergrund färben

        // Hintergrund färben Zylinderkopf
        private void tb_KopfhoeheZk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh && res <= maxKh)
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

            if (Double.TryParse(tb.Text, out res) && res >= minKd && res <= maxKd && res > myScrew.Gewindedurchmesser)
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

            if (Double.TryParse(tb.Text, out res) && res >= minGl && res <= maxGl)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
            
        }

        private void tb_SchaftlängeZk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= 0 && res <= maxSl)
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
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_KopfhoeheZk.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_GewindelaengeZk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeZk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSenk();

                tb_Zylinderkopf_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Zylinderkopf_Kh.Text = Convert.ToString(myScrew.Kopfhoehe);
                tb_Zylinderkopf_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Zylinderkopf_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Zylinderkopf_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

                btn_ContinueZk.Visibility = Visibility.Visible;
                btn_CatiaZk.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_KopfdurchmesserZk.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_KopfdurchmesserZk.Background = Brushes.Red;
                }
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

        #region Drehrichtung
        private void RechtsgewindeZk_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Rechtsgewinde";
            myScrew.Drehsinn = true;
        }

        private void LinksgewindeZk_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Linkssgewinde";
            myScrew.Drehsinn = false;
        }
        #endregion

        #region Ausgabe
        private void btn_ContinueZk_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_KopfhoeheZk.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_GewindelaengeZk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeZk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSenk();

                tb_Zylinderkopf_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Zylinderkopf_Kh.Text = Convert.ToString(myScrew.Kopfhoehe);
                tb_Zylinderkopf_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Zylinderkopf_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Zylinderkopf_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

              

                hideAllGrids();

                imgHidden();
                img_Zylinderschraube.Visibility = Visibility.Visible;

                myMaterial.MaterialAg();
                grid_Ausgabe.Visibility = Visibility.Visible;

                tb_SchraubenartAg.Text = "Zylinderkopfschraube";
                tb_GewindeAg.Text = myScrew.Gewinderichtung;
                tb_BezeichnungAg.Text = "M" + Convert.ToString(myScrew.Gewindedurchmesser) + "x" + Convert.ToString(myScrew.Gesamtlaenge);
                tb_KopfAg.Text = "Kopfdurchmesser: " + Convert.ToString(myScrew.Kopfdurchmesser) + "mm;    Kopfhöhe: " + Convert.ToString(myScrew.Kopfhoehe) + "mm";

                tb_GewichtAg.Text = "Gewicht: " + Convert.ToString(myScrew.Gewicht) + "g";
                tb_MaterialAg.Text = "Material: " + myMaterial.Materialausgabe;

                tb_PreisAg.Text = "Preis: " + Convert.ToString(myScrew.Preis) + " Euro";

            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_KopfdurchmesserZk.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_KopfdurchmesserZk.Background = Brushes.Red;
                }
            }

            
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

        // Info Box
        private void chb_InfoGs_Click(object sender, RoutedEventArgs e)
        {
            if (lab_glmaxGs.Visibility == Visibility.Hidden)
            {
                lab_glmaxGs.Visibility = Visibility.Visible;
            }
            else
            {
                lab_glmaxGs.Visibility = Visibility.Hidden;
            }
        }


        #region Hintergrund färben

        private void tb_GewindelaengeGS_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minGl && res <= maxGl)
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



            if (double.TryParse(tb_GewindelaengeGS.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Gewindelaenge = laenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungGS();

                tb_Gewindestift_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Gewindestift_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

                btn_ContinueGs.Visibility = Visibility.Visible;
                btn_CatiaGs.Visibility = Visibility.Visible;


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

        #region Drehrichtung
        private void RechtsgewindeGS_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Rechtsgewinde";
            myScrew.Drehsinn = true;
        }

        private void LinksgewindeGS_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Linksgewinde";
            myScrew.Drehsinn = false;
        }
        #endregion

        #region Ausgabe
        private void btn_ContinueGs_Click(object sender, RoutedEventArgs e)
        {
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_GewindelaengeGS.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Gewindelaenge = laenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungGS();

                tb_Gewindestift_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Gewindestift_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

                
                hideAllGrids();

                imgHidden();
                img_Gewindestift.Visibility = Visibility.Visible;

                myMaterial.MaterialAg();
                grid_Ausgabe.Visibility = Visibility.Visible;
                tb_KopfAg.Visibility = Visibility.Hidden;

                tb_SchraubenartAg.Text = "Gewindestift";
                tb_GewindeAg.Text = myScrew.Gewinderichtung; ;
                tb_BezeichnungAg.Text = "M" + Convert.ToString(myScrew.Gewindedurchmesser) + "x" + Convert.ToString(myScrew.Gewindelaenge);

                tb_GewichtAg.Text = "Gewicht: " + Convert.ToString(myScrew.Gewicht) + "g";
                tb_MaterialAg.Text = "Material: " + myMaterial.Materialausgabe;

                tb_PreisAg.Text = "Preis: " + Convert.ToString(myScrew.Preis) + " Euro";

                
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }

            
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

        // Info Box
        private void chb_InfoSenk_Click(object sender, RoutedEventArgs e)
        {
            if (lab_kdmaxSenk.Visibility == Visibility.Hidden)
            {
                lab_kdmaxSenk.Visibility = Visibility.Visible;                
                lab_glmaxSenk.Visibility = Visibility.Visible;
                lab_slmaxSenk.Visibility = Visibility.Visible;
                lab_GewindeSk.Visibility = Visibility.Visible;
            }
            else
            {
                lab_kdmaxSenk.Visibility = Visibility.Hidden;                
                lab_glmaxSenk.Visibility = Visibility.Hidden;
                lab_slmaxSenk.Visibility = Visibility.Hidden;
                lab_GewindeSk.Visibility = Visibility.Hidden;
            }
        }

        #region Hintergrund färben

        private void tb_KopfhoeheSenk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= minKh && res <= maxKh)
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

            if (Double.TryParse(tb.Text, out res) && res >= minKd && res <= maxKd && res > myScrew.Gewindedurchmesser)
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

            if (Double.TryParse(tb.Text, out res) && res >= minGl && res <= maxGl)
            {
                tb.Background = Brushes.LightGreen;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
        }

        private void tb_SchaftlängeSenk_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double res;

            if (Double.TryParse(tb.Text, out res) && res >= 0 && res <= maxSl)
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
            
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_GewindelaengeSenk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeSenk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSenk();
                tb_Senkschraube_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Senkschraube_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Senkschraube_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Senkschraube_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);

                btn_ContinueSenk.Visibility = Visibility.Visible;
                btn_CatiaSenk.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_KopfdurchmesserSenk.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_KopfdurchmesserSenk.Background = Brushes.Red;
                }
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

        #region Drehrichtung
        private void RechtsgewindeSenk_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Rechtsgewinde";
            myScrew.Drehsinn = true;
        }

        private void LinksgewindeSenk_Checked(object sender, RoutedEventArgs e)
        {
            myScrew.Gewinderichtung = "Linksgewinde";
            myScrew.Drehsinn = false;
        }
        #endregion

        #region Ausgabe
        private void btn_ContinueSenk_Click(object sender, RoutedEventArgs e)
        {
           
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_GewindelaengeSenk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeSenk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;

                myScrew.BerechnungSenk();
                tb_Senkschraube_Kd.Text = Convert.ToString(myScrew.Kopfdurchmesser);
                tb_Senkschraube_Sl.Text = Convert.ToString(myScrew.Schaftlaenge);
                tb_Senkschraube_Gl.Text = Convert.ToString(myScrew.Gewindelaenge);
                tb_Senkschraube_Gd.Text = Convert.ToString(myScrew.Gewindedurchmesser);                

                hideAllGrids();

                imgHidden();
                img_Senkschraube.Visibility = Visibility.Visible;

                myMaterial.MaterialAg();
                grid_Ausgabe.Visibility = Visibility.Visible;

                tb_SchraubenartAg.Text = "Senkschraube";
                tb_GewindeAg.Text = myScrew.Gewinderichtung;
                tb_BezeichnungAg.Text = "M" + Convert.ToString(myScrew.Gewindedurchmesser) + "x" + Convert.ToString(myScrew.Gesamtlaenge);
                tb_KopfAg.Text = "Kopfdurchmesser: " + Convert.ToString(myScrew.Kopfdurchmesser) + "mm;    Kopfhöhe: " + Convert.ToString(myScrew.Kopfhoehe) + "mm";

                tb_GewichtAg.Text = "Gewicht: " + Convert.ToString(myScrew.Gewicht) + "g";
                tb_MaterialAg.Text = "Material: " + myMaterial.Materialausgabe;

                tb_PreisAg.Text = "Preis: " + Convert.ToString(myScrew.Preis) + " Euro";
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_KopfdurchmesserSenk.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_KopfdurchmesserSenk.Background = Brushes.Red;
                }
            }

        }












        #endregion

        #endregion

        private void btn_Catia_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_Kopfhoehe.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_Gewindelaenge.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_Schaftlänge.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;
                myScrew.Gesamtlaenge = laenge + schaftlaenge;

                myScrew.Schraubenart = 1;
                new CatiaControl(myScrew);


            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_Kopfdurchmesser.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_Kopfdurchmesser.Background = Brushes.Red;
                }
            }
        }

        private void btn_CatiaZk_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_KopfhoeheZk.Text, out kopfhoehe) && kopfhoehe >= minKh && kopfhoehe <= maxKh
                && double.TryParse(tb_GewindelaengeZk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeZk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Kopfhoehe = kopfhoehe;
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;
                myScrew.Gesamtlaenge = laenge + schaftlaenge;

                myScrew.Schraubenart = 2;
                new CatiaControl(myScrew);


            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_Kopfdurchmesser.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_Kopfdurchmesser.Background = Brushes.Red;
                }
            }
        }

        private void btn_CatiaGs_Click(object sender, RoutedEventArgs e)
        {
            double laenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();



            if (double.TryParse(tb_GewindelaengeGS.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                myScrew.Gewindelaenge = laenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;                

                myScrew.Schraubenart = 3;
                new CatiaControl(myScrew);
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }
        }

        private void btn_CatiaSenk_Click(object sender, RoutedEventArgs e)
        {
           
            double kd;
            double laenge;
            double schaftlaenge;
            double dichte = myMaterial.Dichteauswahl();
            double preisfaktor = myMaterial.Preisfaktorauswahl();
            



            if (double.TryParse(tb_GewindelaengeSenk.Text, out laenge) && laenge >= minGl && laenge <= maxGl
                && double.TryParse(tb_KopfdurchmesserSenk.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser
                && double.TryParse(tb_SchaftlängeSenk.Text, out schaftlaenge) && schaftlaenge >= 0 && schaftlaenge <= maxSl
                && dichte != 0
                && myScrew.Gewindedurchmesser != 0)
            {
                
                myScrew.Gewindelaenge = laenge;
                myScrew.Kopfdurchmesser = kd;
                myScrew.Schaftlaenge = schaftlaenge;
                myScrew.Dichte = dichte;
                myScrew.Preisfaktor = preisfaktor;
                myScrew.Gesamtlaenge = laenge + schaftlaenge;

                myScrew.Schraubenart = 4;
                new CatiaControl(myScrew);


            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");

                if (double.TryParse(tb_Kopfdurchmesser.Text, out kd) && kd >= minKd && kd <= maxKd && kd > myScrew.Gewindedurchmesser)
                {
                    tb_Kopfdurchmesser.Background = Brushes.LightGreen;
                }
                else
                {
                    tb_Kopfdurchmesser.Background = Brushes.Red;
                }
            }
        }
    }
}

