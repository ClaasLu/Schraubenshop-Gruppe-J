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
                Console.WriteLine("Kopfart");
                int kopfart = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kopfhoehe");
                double kopfhoehe = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Kopfdurchmesser");
                double kd = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Gewindedurchmesser");
                double gd = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Gewindelaenge");
                double laenge = Convert.ToDouble(Console.ReadLine());

                // neue Schraube anlegen
               Schraube s = new Schraube(kopfart, kopfhoehe, kd, gd, laenge);

                // Schraubendaten berechnen
                s.Berechnung();


                //Schraubendaten ausgeben
                s.Ausgabe();

                Console.ReadKey();
                Console.Clear();
                
            }
        }
            
        
    }

}
    

