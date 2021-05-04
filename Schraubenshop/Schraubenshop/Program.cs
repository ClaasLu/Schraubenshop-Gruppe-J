using System;
using System.Threading;

namespace Schraubenshop
{


    public static class Program
    {

        //Magic numbers für die Mindestgrößen
        const int minKh = 3;
        const int minKd = 5;
        const int minGd = 1;
        const int minGl = 5;

        [STAThread]
        static void Main()
        {
            new GUI_control();


            // Begrüßung
            // Console.WriteLine("Herzlich Willkommen beim Schrauben-Assistenten GJ_V1!");
            //  Console.WriteLine("Hier können Sie Ihre Schraube individuell gestalten und berechnen lassen.");
            // Console.WriteLine();
            // Console.WriteLine("Drücken Sie eine beliebige Taste zum Starten.");
            // Console.ReadKey();
            // Console.Clear();


            //Einkaufsschleife
            do
            {
                Einkauf();
            } while (EinkaufFortsetzen());

            //Verabschiedung
            // Console.Clear();
            // Console.WriteLine("Vielen Dank für ihren Besuch. Auf Wiedersehen!");
            // Thread.Sleep(3000);           
        }

        //Unterprogramm bei falscher Eingabe
        static void FalscheEingabe()
        {
            Console.WriteLine("Falsche Eingabe! Bitte kurz warten.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        // Boolean zum Einkauf fortsetzen
        static bool EinkaufFortsetzen()
        {
            int eingabe;
            
            while (true)
            {
                Console.WriteLine("Für eine weitere Berechnung drücken Sie die 1, mit der 2 schließen sie das Programm.");
                if (int.TryParse(Console.ReadLine(), out eingabe) && eingabe == 1 || eingabe == 2)
                {
                    Console.Clear();
                    if (eingabe == 1)
                    {
                        return true;
                    }
                    else if (eingabe == 2)
                    {
                        return false;
                    }
                   
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        // Einkaufsprogramm
        static void Einkauf()
        {

            // Daten setzen
            int kopfart = EingabeKopfart();
            double kopfhoehe = EingabeKopfhoehe();
            double kd = EingabeKd();
            double gd = EingabeGd();
            double laenge = EingabeLaenge();

            //Konstruktor Material
            Material selectedMaterial = WahlMaterial();

            double dichte = selectedMaterial.Dichteauswahl();
            double preisfaktor = selectedMaterial.Preisfaktorauswahl();

            //neue Schraube anlegen
            Schraube selectedPart = new Schraube(kopfart, kopfhoehe, kd, gd, laenge, dichte, preisfaktor);


            // Schraubendaten berechnen
            if (kopfart == 1)
            {
                selectedPart.BerechnungSK();
            }
            else    // Kopfart == 2                                           
            {
                selectedPart.BerechnungZK();
            }

            //Schraubendaten ausgeben
            selectedPart.Ausgabe();
        }

        //Daten einlesen in mehreren Unterprogrammen
        static int EingabeKopfart()
        {
            int kopfart;

            while (true)
            {
                Console.WriteLine("Bitte wählen Sie die KOPFART aus: 1=Sechskant 2=Zylinderkopf");

                //Abfrage, ob überhaupt eine Zahl eingegeben wurde um Fehlermeldungen zu vermeiden
                if (int.TryParse(Console.ReadLine(), out kopfart) && kopfart == 1 || kopfart == 2)
                {
                    return kopfart;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        static double EingabeKopfhoehe()
        {
            double kopfhoehe;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte geben Sie ihre gewünschte KOPFHÖHE in mm an (min. 3mm).");

                if (double.TryParse(Console.ReadLine(), out kopfhoehe) && kopfhoehe >= minKh)
                {
                    return kopfhoehe;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        static double EingabeKd()
        {
            double kd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte geben Sie ihren gewünschten KOPFDURCHMESSER in mm an (min. 5mm).");
                if (double.TryParse(Console.ReadLine(), out kd) && kd >= minKd)
                {
                    return kd;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        static double EingabeGd()
        {
            double gd;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte geben Sie ihren gewünschten GEWINDEDURCHMESSER für das metrische Standardgewinde ein (min. 1).");

                if (double.TryParse(Console.ReadLine(), out gd) && gd >= minGd)
                {
                    return gd;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        static double EingabeLaenge()
        {
            double laenge;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte geben Sie ihre gewünschte GEWINDELÄNGE in mm ein (min. 5mm).");

                if (double.TryParse(Console.ReadLine(), out laenge) && laenge >= minGl)
                {
                    return laenge;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }

        static Material WahlMaterial()
        {
            int material;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie ihr MATERIAL aus: 1=Stahl (verz.) 2=Edelstahl 3=Titan 4=Messing");

                if (int.TryParse(Console.ReadLine(), out material) && material <= 4 && material > 0)
                {
                    Material selectedMAterial = new Material(material);
                    return selectedMAterial;
                }
                else
                {
                    FalscheEingabe();
                }
            }
        }
    }
}


