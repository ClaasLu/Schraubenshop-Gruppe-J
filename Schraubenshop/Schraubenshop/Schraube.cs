using System;


namespace Schraubenshop
{
    public class Schraube
    {
        public int Schraubenart { get; set; }
        public double Kopfhoehe { get; set; }
        public double Kopfdurchmesser { get; set; }
        public double Gewindedurchmesser { get; set; }
        public double Gewindelaenge { get; set; }
        public double Schaftlaenge { get; set; }
        public double Volumen { get; set; }
        public double Gewicht { get; set; }
        public double Preis { get; set; }
        public double Dichte { get; set; }
        public double Preisfaktor { get; set; }
        public double Gesamtlaenge { get; set; }
        public string Gewinderichtung { get; set; }


        //Konstruktor
        public Schraube()
        {
            
        }

        // Berechnung Sechskant
        public void BerechnungSK()
        {
            this.Volumen = (3 / 2 * Math.Sqrt(3) * Kopfhoehe * (Kopfdurchmesser / 2) * (Kopfdurchmesser / 2)) + (Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * (Gewindelaenge + Schaftlaenge));
            this.Gewicht = Dichte * Volumen * 1000;
            this.Gewicht = Math.Round(this.Gewicht, 2);
            this.Preis = 2 + Preisfaktor * Gewicht;
            this.Preis = Math.Round(this.Preis, 2);            
            this.Gesamtlaenge = Gewindelaenge + Schaftlaenge;
        }

        //Berechnung Zylinderkopf
        public void BerechnungZK()
       {
            this.Volumen = Math.PI * Kopfhoehe * (Kopfdurchmesser / 2) * (Kopfdurchmesser / 2) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * (Gewindelaenge + Schaftlaenge);
            this.Gewicht = Dichte * Volumen * 1000;
            this.Gewicht = Math.Round(this.Gewicht, 2);
            this.Preis = 2 + Preisfaktor * Gewicht;
            this.Preis = Math.Round(this.Preis, 2);
            this.Gesamtlaenge = Gewindelaenge + Schaftlaenge;
        }


        // Berechnung Gewindestift
        public void BerechnungGS()
        {
            this.Volumen = Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * Gewindelaenge;
            this.Gewicht = Dichte * Volumen * 1000;
            this.Gewicht = Math.Round(this.Gewicht, 2);
            this.Preis = 2 + Preisfaktor * Gewicht;
            this.Preis = Math.Round(this.Preis, 2);

        }


        // Berechnung Senkschraube
        // Kopfhöhe ersetzt durch ((Kopfdurchmesser - Gewindedurchmesser)/2)
        public void BerechnungSenk()
        {
            this.Volumen = 1/3 * Math.PI * ((Kopfdurchmesser - Gewindedurchmesser)/2) * ((Kopfdurchmesser/2)* (Kopfdurchmesser / 2) + (Gewindedurchmesser/2)*(Gewindedurchmesser / 2) + (Kopfdurchmesser/2)*(Gewindedurchmesser/2)) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * (Gewindelaenge + Schaftlaenge);
            this.Gewicht = Dichte * Volumen * 1000;
            this.Gewicht = Math.Round(this.Gewicht, 2);
            this.Preis = 2 + Preisfaktor * Gewicht;
            this.Preis = Math.Round(this.Preis, 2);
            this.Gesamtlaenge = Gewindelaenge + Schaftlaenge;
        }       
    }
}
