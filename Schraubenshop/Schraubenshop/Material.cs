namespace Schraubenshop
{
    class Material
    {
        // Konstanten für Dichte und Faktor
        const double dichteStahl = 0.00000785;
        const double dichtetitan = 0.0000045;
        const double dichtemessing = 0.00000896;
        const double faktorStahl = 0.03;
        const double faktorEdelstahl = 0.05;
        const double faktorTitan = 0.08;
        const double faktorMessing = 0.04;
        

        public int Materialschraube { get; set; }
        public double Dichte { get; set; }
        public double Preisfaktor { get; set; }

        public string Materialausgabe { get; set; }

        //Konstruktor
        public Material()
        {
            
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
            else if (Materialschraube == 4)
            {
                this.Dichte = dichtemessing;
            }
            else
            {
                this.Dichte = 0;
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

        public string MaterialAg()
        {
            switch (Materialschraube)
            {
                case 1:
                    this.Materialausgabe = "Stahl verz.";
                    return Materialausgabe;
                case 2:
                    this.Materialausgabe = "Edelstahl";
                    return Materialausgabe;
                case 3:
                    this.Materialausgabe = "Titan";
                    return Materialausgabe;
                default:
                    this.Materialausgabe = "Messing";
                    return Materialausgabe;
            }
        }
    }
}
