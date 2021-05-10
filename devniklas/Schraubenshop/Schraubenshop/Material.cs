namespace Schraubenshop
{
    class Material
    {
        // Konstanten für Dichte und Faktor
        const double dichteStahl = 0.00000785;
        const double dichtetitan = 0.0000045;
        const double dichtemessing = 0.00000896;
        const double faktorStahl = 1;
        const double faktorEdelstahl = 2;
        const double faktorTitan = 4;
        const double faktorMessing = 1.5;
        

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
   
        //Preisfaktor auswählen
        public double Preisfaktorauswahl()
        {
            switch (Materialschraube)
            {
                case 1:
                    this.Preisfaktor = faktorStahl;
                    return Preisfaktor;                   
                case 2:
                    this.Preisfaktor = faktorEdelstahl;
                    return Preisfaktor;                    
                case 3:
                    this.Preisfaktor = faktorTitan;
                    return Preisfaktor;                    
                default:
                    this.Preisfaktor = faktorMessing;
                    return Preisfaktor;                    
            }
        }
    }
}
