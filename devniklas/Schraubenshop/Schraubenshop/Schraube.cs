using System;

namespace Schraubenshop
{
    public class Schraube
    {

        public int Kopfart { get; set; }
        public Int32 Kopfhoehe { get; set; }
        public double Kopfdurchmesser { get; set; }
        public string Gewindedurchmesser { get; set; }
        public Int32 Gewindelaenge { get; set; }
        public double Volumen { get; set; }
        public double Gewicht { get; set; }
        public double Preis { get; set; }
        public double Dichte { get; set; }
        public double Preisfaktor { get; set; }
        public string Material { get; set; } //zum auslesen der Combo-Box

        public bool Gewinderichtung { get; set; }


        //Konstruktor
        public Schraube()
        {
            
        }

        // Berechnung Sechskant
        // public void BerechnungSK()
        // {
        //      this.Volumen = (6 * 0.5 * Kopfhoehe * (Kopfdurchmesser / 2)) + (Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * Gewindelaenge);
        //     this.Gewicht = Dichte * Volumen;
       //   this.Preis = 2 + Preisfaktor * Gewicht;
       //}

        // Berechnung Zylinderkopf
       // public void BerechnungZK()
      //  {
        //    this.Volumen = Math.PI * Kopfhoehe * (Kopfdurchmesser / 2) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
          //  this.Gewicht = Dichte * Volumen;
            //this.Preis = 2 + Preisfaktor * Gewicht;
        //}

        // Ausgabe der Schraubendaten
        public void Ausgabe()
        {
            Console.Clear();
            Console.WriteLine("Sie haben ausgewählt:");
            if (Kopfart == 1)
            {
                Console.WriteLine("Sechskantschraube");
            }
            else
            {
                Console.WriteLine("Zylinderkopfschraube");
            }

            
            switch (Preisfaktor)
            {
                case 1:
                    Console.WriteLine("Material: Stahl (verz.)");
                    break;
                case 2:
                    Console.WriteLine("Material: Edelstahl");
                    break;
                case 4:
                    Console.WriteLine("Material: Titan");
                    break;
                default:
                    Console.WriteLine("Material: Messing");
                    break;
            }

            Console.WriteLine("Kopf: h=" + Kopfhoehe + "mm;" + "d=" + Kopfdurchmesser + "mm;");
            Console.WriteLine("M" + Gewindedurchmesser + "x" + Gewindelaenge);
            Console.WriteLine();
            Console.WriteLine("Volumen:" + Volumen + " mm^3");
            Console.WriteLine("Gewicht:" + Gewicht + " kg");
            Console.WriteLine("Preis:" + Preis + " Euro");
            Console.WriteLine();
        }
    }
}
