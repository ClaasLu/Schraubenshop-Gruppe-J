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

        public void Berechnung()
        {
            this.Volumen = 5;
            this.Gewicht = 4;
            this.Preis = 3;

        }

        public void Ausgabe()
        {
            Console.WriteLine(Volumen);
            Console.WriteLine(Gewicht);
            Console.WriteLine(Preis);


        }


    }
}
