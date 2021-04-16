using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //für Thread.Sleep();



namespace Schraubenshop
{

    class Program
    {

        //Magic numbers für die Mindestgrößen
        const int minKh = 3;
        const int minKd = 5;
        const int minGd = 1;
        const int minGl = 5;


        static void Main()
        {

            // für die Einkaufsschleife 
            int Einkauf = 1;          

            // Begrüßung
            Console.WriteLine("Herzlich Willkommen beim Schrauben-Assistenten GJ_V1!");    
            Thread.Sleep(5000);
            Console.Clear();

            while (Einkauf == 1)
            {

                // Daten einlesen
                int kopfart;
                double kopfhoehe;
                double kd;
                double gd;
                double laenge;
                int material;
                double dichte;
                double preisfaktor;


                do
                {
                    Console.WriteLine("Bitte wählen Sie die KOPFART aus: 1=Sechskant 2=Zylinderkopf"); 
                    kopfart = Convert.ToInt32(Console.ReadLine());

                    if (kopfart != 1 & kopfart != 2)
                    {
                        FalscheEingabe();
                    }

                }
                while (kopfart != 1 & kopfart != 2);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihre gewünschte KOPFHÖHE in mm an (min. 3mm).");
                    kopfhoehe = Convert.ToDouble(Console.ReadLine());

                    if (kopfhoehe < minKh) 
                    {
                        FalscheEingabe();
                    }
                }
                while (kopfhoehe < minKh);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihren gewünschten KOPFDURCHMESSER in mm an (min. 5mm).");
                    kd = Convert.ToDouble(Console.ReadLine());

                    if (kd < minKd)
                    {
                        FalscheEingabe();
                    }
                }
                while (kd < minKd);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihren gewünschten GEWINDEDURCHMESSER für das metrische Standardgewinde ein (min. 1).");
                    gd = Convert.ToDouble(Console.ReadLine());

                    if (gd < minGd)
                    {
                        FalscheEingabe();
                    }

                }
                while (gd < minGd);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihre gewünschte GEWINDELÄNGE in mm ein (min. 5mm).");
                    laenge = Convert.ToDouble(Console.ReadLine());

                    if (laenge < minGl)
                    {
                        FalscheEingabe();
                    }
                }
                while (laenge < minGl);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte wählen Sie ihr MATERIAL aus: 1=Stahl (verz.) 2=Edelstahl 3=Titan 4=Messing");
                    material = Convert.ToInt32(Console.ReadLine());

                    if (material != 1 & material != 2 & material != 3 & material != 4)
                    {
                        FalscheEingabe();
                    }

                }
                while (material != 1 & material != 2 & material != 3 & material != 4);
                

                // neues Material anlegen
                Material SelectedMaterial = new Material(material);

               dichte = SelectedMaterial.Dichteauswahl();
               preisfaktor = SelectedMaterial.Preisfaktorauswahl();


                //neue Schraube anlegen
                Schraube SelectedPart = new Schraube(kopfart, kopfhoehe, kd, gd, laenge, dichte, preisfaktor);


                // Schraubendaten berechnen
                if (kopfart == 1)   
                {
                    SelectedPart.BerechnungSK();
                }
                else    // Kopfart == 2                                           
                {
                    SelectedPart.BerechnungZK();
                }
                        

                //Schraubendaten ausgeben
                SelectedPart.Ausgabe();


                //Einkaufsschleife
                Console.WriteLine("Für eine weitere Berechnung drücken Sie die 1, mit der 2 schließen sie das Programm."); 
                Einkauf = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                               
                //Wiederholung Einkaufsschleife
                if (Einkauf == 1)
                {

                }


                //Ende Einkaufsschleife
                if (Einkauf == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Vielen Dank für ihren Besuch. Auf Wiedersehen!");
                    Thread.Sleep(5000);
                }


                //Kontrolle Einkaufschleife
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                    Thread.Sleep(5000);
                    Console.WriteLine("Für eine weitere Berechnung mit Ihrem Schrauben-Assistenten GJ_V1 drücken Sie die 1, mit der 2 schließen sie das Programm.");
                    Einkauf = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }

            }

           
        }
            
        //Unterprogramm bei falscher Eingabe
        static void FalscheEingabe()
        {
            Console.WriteLine("Falsche Eingabe!");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }

}
    

