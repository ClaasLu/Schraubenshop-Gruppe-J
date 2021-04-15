using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Program
    {
        static void Main()
        { 
            while (true)
            { 
                // Daten einlesen
                Console.WriteLine("Bitte geben Sie die gewünschte KOPFART: 1=Sechskant 2=Zylinderkopf");        //Kontrollstruktur, was ist bei einer ungültigen Eingabe? UNTERPROGRAMME
                int kopfart = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Bitte geben Sie ihre gewünschte KOPFHÖHE in mm an.");
                double kopfhoehe = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben Sie ihren gewünschten KOPFDURCHMESSER in mm an.");
                double kd = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben Sie ihren gewünschten GEWINDEDURCHMESSER für das metrische Standardgewinde ein.");
                double gd = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Bitte geben Sie ihre gewünschte GEWINDELÄNGE in mm ein.");
                double laenge = Convert.ToDouble(Console.ReadLine());

                // neue Schraube anlegen
               Schraube s = new Schraube(kopfart, kopfhoehe, kd, gd, laenge);

                // Schraubendaten berechnen
                if (kopfart == 1)
                {
                    s.BerechnungSK();
                }
                else
                {
                    s.BerechnungZK();
                }
                
                
                

                //Schraubendaten ausgeben
                s.Ausgabe();

                Console.ReadKey();
                Console.Clear();
                
            }
        }
            
        
    }

}
    

