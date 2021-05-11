﻿using System;

namespace Schraubenshop
{
    public class Schraube
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
       

       


        //Konstruktor
        public Schraube()
        {
            
        }

        // Berechnung Sechskant
         public void BerechnungSK()
         {
             this.Volumen = (6 * 0.5 * Kopfhoehe * (Kopfdurchmesser / 2)) + (Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2) * Gewindelaenge);
            this.Gewicht = Dichte * Volumen;
          this.Preis = 2 + Preisfaktor * Gewicht;
       }

        //Berechnung Zylinderkopf
        public void BerechnungZK()
       {
            this.Volumen = Math.PI * Kopfhoehe * (Kopfdurchmesser / 2) + Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
            this.Gewicht = Dichte * Volumen;
            this.Preis = 2 + Preisfaktor * Gewicht;
        }
        

        // Berechnung Gewindestift
        public void BerechnungGS()
        {
            this.Volumen = Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
            this.Gewicht = Dichte * Volumen;
            this.Preis = 2 + Preisfaktor * Gewicht;
        }


        // Berechnung Senkschraube
        public void BerechnungSenk()
        {
            this.Volumen = 1/3 * Math.PI * Kopfhoehe * ((Kopfdurchmesser/2)*(Kopfdurchmesser/ 2) + (Gewindedurchmesser/2)*(Kopfdurchmesser/2) + (Gewindedurchmesser / 2) *(Gewindedurchmesser / 2))+ Math.PI * (Gewindedurchmesser / 2) * (Gewindedurchmesser / 2);
            this.Gewicht = Dichte * Volumen;
            this.Preis = 2 + Preisfaktor * Gewicht;
        }       
    }
}
