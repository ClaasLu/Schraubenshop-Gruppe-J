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
        static void Main()
        {

             int Einkauf = 1; //für die Einkaufsschleife

            //Begrüßung
            Console.WriteLine("Herzlich Willkommen zum Schrauben-Assistenten GJ_V1");    
            Thread.Sleep(3000);
            Console.Clear();

            while (Einkauf ==1)
            {

                // Daten einlesen

                int kopfart;
                double kopfhoehe;
                double kd;
                double gd;
                double laenge;


                do
                {
                    Console.WriteLine("Bitte selektieren Sie die KOPFART durch Angabe der Ziffer: 1=Sechskant 2=Zylinderkopf"); 
                    Console.WriteLine("Bitte selektieren Sie die KOPFART durch Angabe der Ziffer: 1=Sechskant 2=Zylinderkopf");        
                    kopfart = Convert.ToInt32(Console.ReadLine());

                    if (kopfart != 1 & kopfart != 2)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }

                }
                while (kopfart != 1 & kopfart != 2);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihre gewünschte KOPFHÖHE in mm an (min. 3mm).");
                    kopfhoehe = Convert.ToDouble(Console.ReadLine());

                    if (kopfhoehe < 3) 
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                while (kopfhoehe < 3);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihren gewünschten KOPFDURCHMESSER in mm an (min. 5mm).");
                    kd = Convert.ToDouble(Console.ReadLine());

                    if (kd < 5)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                while (kd < 5);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihren gewünschten GEWINDEDURCHMESSER für das metrische Standardgewinde ein (min. 1mm).");
                    gd = Convert.ToDouble(Console.ReadLine());

                    if (gd < 1)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }

                }
                while (gd < 1);

                do
                {
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie ihre gewünschte GEWINDELÄNGE in mm ein (min. 5mm).");
                    laenge = Convert.ToDouble(Console.ReadLine());

                    if (laenge < 5)
                    {
                        Console.WriteLine("Falsche Eingabe!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                while (laenge < 5);


            //Material
            //Zugfestigkeit

            //neue Schraube anlegen
            Schraube SelectedPart = new Schraube(kopfart, kopfhoehe, kd, gd, laenge);

                // Schraubendaten berechnen
                if (kopfart == 1)   
                {
                    SelectedPart.BerechnungSK();
                }
                else    //also Kopfart = 2                                           
                {
                    SelectedPart.BerechnungZK();
                }
                        

                //Schraubendaten ausgeben
                SelectedPart.Ausgabe();

                //Einkaufsschleife
                Console.WriteLine("Für eine weitere Berechnung mit Ihrem Schrauben-Assistenten GJ_V1 drücken Sie die 1, mit der 2 schließen sie das Programm."); 
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
                    Thread.Sleep(3000);
                }
                //Kontrolle Einkaufschleife
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                    Thread.Sleep(3000);
                    Console.WriteLine("Für eine weitere Berechnung mit Ihrem Schrauben-Assistenten GJ_V1 drücken Sie die 1, mit der 2 schließen sie das Programm.");
                    Einkauf = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }

            }

           
        }
            
        
    }

}
    

