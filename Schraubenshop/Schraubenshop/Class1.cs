using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Material
    {
        const double dichteStahl = 0.00000785;
        const double dichtetitan = 0.0000045;
        const double dichtemessing = 0.00000896;

        public int Materialschraube { get; set; }
        public double Dichte { get; set; }
        public double Preisfaktor { get; set; }

        // Material wird gelöscht
        ~Material()
        {

        }

        //Konstruktor
        public Material(int materialschraube)
        {
            Materialschraube = materialschraube;
        }

        //Dichte auswählen
        public double Dichteauswahl ()
        {
            if (Materialschraube == 1 | Materialschraube == 2)
            {
                this.Dichte = dichteStahl;               
            }
            else if (Materialschraube == 3)
            {
                this.Dichte = dichtetitan;
            }
            else
            {
                this.Dichte = dichtemessing;
            }
            return (Dichte);
        }

        //Preisfaktor auswählen
        public double Preisfaktorauswahl()
        {
            if (Materialschraube == 1)
            {
                this.Preisfaktor = 1;
            }
            else if (Materialschraube == 2)
            {
                this.Preisfaktor = 2;
            }
            else if (Materialschraube == 3)
            {
                this.Preisfaktor = 4;
            }
            else
            {
                this.Preisfaktor = 1.5;
            }
            return (Preisfaktor);
        }
      
}
}
