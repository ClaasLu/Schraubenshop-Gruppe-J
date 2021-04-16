using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Schraube
    {

        public int Kopfart { get; set; }
        public double Kopfhoehe { get; set; }
        public double Kopfdurchmesser { get; set; }
        public double Gewindedurchmesser { get; set; }
        public double Gewindelaenge { get; set; }
        public double Volumen { get; set; }
        public double Gewicht { get; set; }
        public double Preis { get; set; }

        ~Schraube()
        {

        }


        public Schraube(int kopfart, double kopfhoehe, double kopfdurchmesser, double gewindedurchmesser, double gewindelaenge)
        {
            Kopfart = kopfart;
            Kopfhoehe = kopfhoehe;
            Kopfdurchmesser = kopfdurchmesser;
            Gewindedurchmesser = gewindedurchmesser;
            Gewindelaenge = gewindelaenge;
        }

        public void BerechnungSK()
        {
            this.Volumen = (6 * 0.5 * Kopfhoehe * (Kopfdurchmesser / 2)) + (Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * Gewindelaenge);
            this.Gewicht = 0.00000785*Volumen;
            this.Preis = 2*Gewicht;

        }

        public void BerechnungZK()
        {
            this.Volumen = Math.PI * Kopfhoehe * (Kopfdurchmesser / 2) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
            this.Gewicht = 0.00000785 * Volumen;
            this.Preis = 2 * Gewicht;
        }

        public void Ausgabe()
        {
            Console.WriteLine("Sie haben ausgewählt:");
            if ( Kopfart == 1)
            {
                Console.WriteLine("Sechskantschraube");
            }
            else
            {
                Console.WriteLine("Zylinderkopfschraube");
            }
            Console.WriteLine("Kopfhoehe:" +Kopfhoehe+ "mm;" + "Kopfdurchmesser:" +Kopfdurchmesser+ "mm;");
            Console.WriteLine("M" + Gewindedurchmesser + "x" + Gewindelaenge);
            Console.WriteLine();
            Console.WriteLine("Volumen:"+Volumen+"in mm^3");
            Console.WriteLine("Gewicht:"+Gewicht+"in kg");
            Console.WriteLine("Preis:"+Preis+"in Euro");
            Console.WriteLine("Diese Schraube ist eine Qualitätsschraube!");
            Console.WriteLine();

        }
        


    }
}
