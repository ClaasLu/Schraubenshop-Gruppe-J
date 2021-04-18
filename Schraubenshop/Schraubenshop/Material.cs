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

        //Konstruktor
        public Material(int materialschraube)
        {
            Materialschraube = materialschraube;
        }

        //Dichte auswählen
        public double Dichteauswahl()
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


        //Nochmal angucken!!
        //Preisfaktor auswählen
        public double Preisfaktorauswahl()
        {
            if (Materialschraube > 4)
            {
                this.Preisfaktor = 1.5;
            }
            else
            {
                this.Preisfaktor = Materialschraube;
            }
            return (Preisfaktor);
        }
    }
}
