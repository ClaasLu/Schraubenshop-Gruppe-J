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
        public double Dichte { get; set; }
        public double Preisfaktor { get; set; }


        //Schraube wird gelöscht
        ~Schraube()         
        {

        }


        public Schraube(int kopfart, double kopfhoehe, double kopfdurchmesser, double gewindedurchmesser, double gewindelaenge, double dichte, double preisfaktor)
        {
            Kopfart = kopfart;
            Kopfhoehe = kopfhoehe;
            Kopfdurchmesser = kopfdurchmesser;
            Gewindedurchmesser = gewindedurchmesser;
            Gewindelaenge = gewindelaenge;
            Dichte = dichte;
            Preisfaktor = preisfaktor;
            
        }

        public void BerechnungSK()
        {
            this.Volumen = (6 * 0.5 * Kopfhoehe * (Kopfdurchmesser / 2)) + (Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * Gewindelaenge);
            this.Gewicht = Dichte*Volumen;
            this.Preis = Preisfaktor * Gewicht;

        }

        public void BerechnungZK()
        {
            this.Volumen = Math.PI * Kopfhoehe * (Kopfdurchmesser / 2) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
            this.Gewicht = Dichte * Volumen;
            this.Preis = 2 + Preisfaktor * Gewicht;
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
            
            if (Preisfaktor==1)
            {
                Console.WriteLine("Material: Stahl (verz.)");
            }
            else if (Preisfaktor == 2)
            {
                Console.WriteLine("Material: Edelstahl");
            }
            else if (Preisfaktor == 4)
            {
                Console.WriteLine("Material: Titan");
            }
            else 
            {
                Console.WriteLine("Material: Messing");                    
            }

            Console.WriteLine("Kopf: h=" +Kopfhoehe+ "mm;" + "d=" +Kopfdurchmesser+ "mm;");
            Console.WriteLine("M" + Gewindedurchmesser + "x" + Gewindelaenge);
            Console.WriteLine();
            Console.WriteLine("Volumen:"+Volumen+" mm^3");
            Console.WriteLine("Gewicht:"+Gewicht+" kg");
            Console.WriteLine("Preis:"+Preis+" Euro");
            Console.WriteLine("Diese Schraube ist eine Qualitätsschraube!");
            Console.WriteLine();

        }
        


    }
}
