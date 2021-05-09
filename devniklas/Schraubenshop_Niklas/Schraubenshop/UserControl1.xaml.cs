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

       

        // Startansicht
        public UserControl1()
        {
            InitializeComponent();

            // Sichtbarkeit am Anfang
            grid_Startauswahl.Visibility = Visibility.Visible;
            grid_Sechskant.Visibility = Visibility.Hidden;
            grid_Zylinderkopf.Visibility = Visibility.Hidden;

        }


        // Auswahl Sechskant
        private void btn_Sechskant_Click(object sender, RoutedEventArgs e)
        {
            grid_Startauswahl.Visibility = Visibility.Hidden;
            grid_Sechskant.Visibility = Visibility.Visible;
        }

        // Auswahl Zylinderkopf
        private void btn_Zylinderkopf_Click(object sender, RoutedEventArgs e)
        {
            grid_Startauswahl.Visibility = Visibility.Hidden;
            grid_Zylinderkopf.Visibility = Visibility.Visible;
        }

        // Shutdown
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

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

            if (Double.TryParse(tb.Text, out res) &&  res >= minKd)
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

        // Zylinderkopf
        private void btn_CalculateZK_Click(object sender, RoutedEventArgs e)
        {
            double kopfhoehe;
            double kd;
            double gd;
            double laenge;

            gd = 1;

            double dichte = 0.001;
            double preisfaktor = 1.2;

            

            if (double.TryParse(tb_KopfhoeheZk.Text, out kopfhoehe) && kopfhoehe>= minKh  
                && double.TryParse(tb_GewindelaengeZk.Text, out laenge) && laenge>= minGl 
                && double.TryParse(tb_KopfdurchmesserZk.Text, out kd) && kd >= minKd)
            {
                Schraube selectedPart = new Schraube(kopfhoehe, kd, gd, laenge, dichte, preisfaktor);
                selectedPart.BerechnungZK();
            }
            else
            {
                MessageBox.Show("Bitte überprüfen Sie Ihre Eingaben!");
            }
        }
    }
}

