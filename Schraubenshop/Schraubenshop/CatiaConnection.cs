using System;
using System.Windows;
using HybridShapeTypeLib;
using INFITF;
using MECMOD;
using PARTITF;

namespace Schraubenshop
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPartDoc;
        MECMOD.Sketch hsp_catiaSkizze;

        ShapeFactory SF;
        HybridShapeFactory HSF;
        Pad mySchaft;
        Body myBody;
        Part myPart;
        Sketches mySketches;

        #region MinimalCatia
        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPartDoc = catDocuments1.Add("Part") as MECMOD.PartDocument;

            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            SF = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;
            HybridBodies catHybridBodies1 = hsp_catiaPartDoc.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            mySketches = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaSkizze = mySketches.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaSkizze.SetAbsoluteAxisData(arr);
        }

       

        
        #endregion

        #region Schraube
        internal void ErzeugeZylinder(Schraube myScrew)
        {
            myPart = hsp_catiaPartDoc.Part;
            Bodies bodies = myPart.Bodies;
            myBody = myPart.MainBody;
            // myBody = bodies.Add();

            // Hauptkoerper in Bearbeitung definieren
            myPart.InWorkObject = myPart.MainBody;

            // Skizze umbenennen
            hsp_catiaSkizze.set_Name("Kreis");

            // Skizze...
            // ... oeffnen für die Bearbeitung
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();

            // ... Kreis erstellen
            double H0 = 0;
            double V0 = 0;
            Point2D Ursprung = catFactory2D1.CreatePoint(H0, V0);
            Circle2D Kreis = catFactory2D1.CreateCircle(H0, V0, myScrew.Gewindedurchmesser/2, 0, 0);
            Kreis.CenterPoint = Ursprung;

            // ... schliessen
            hsp_catiaSkizze.CloseEdition();

            // Schraubenschaft durch ein Pad erstellen
            Reference RefMySchaft = myPart.CreateReferenceFromObject(hsp_catiaSkizze);
            mySchaft = SF.AddNewPadFromRef(RefMySchaft, myScrew.Gewindelaenge);
            myPart.Update();

        }

        // Zylinder mit Schaft für alle Schraubentypen außer Gewindestift
        internal void ErzeugeZylinder2(Schraube myScrew)
        {
            myPart = hsp_catiaPartDoc.Part;
            Bodies bodies = myPart.Bodies;
            myBody = myPart.MainBody;
            // myBody = bodies.Add();

            // Hauptkoerper in Bearbeitung definieren
            myPart.InWorkObject = myPart.MainBody;

            // Skizze umbenennen
            hsp_catiaSkizze.set_Name("Kreis");

            // Skizze...
            // ... oeffnen für die Bearbeitung
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();

            // ... Kreis erstellen
            double H0 = 0;
            double V0 = 0;
            Point2D Ursprung = catFactory2D1.CreatePoint(H0, V0);
            Circle2D Kreis = catFactory2D1.CreateCircle(H0, V0, myScrew.Gewindedurchmesser / 2, 0, 0);
            Kreis.CenterPoint = Ursprung;

            // ... schliessen
            hsp_catiaSkizze.CloseEdition();

            // Schraubenschaft durch ein Pad erstellen
            Reference RefMySchaft = myPart.CreateReferenceFromObject(hsp_catiaSkizze);
            mySchaft = SF.AddNewPadFromRef(RefMySchaft, myScrew.Gesamtlaenge);
            myPart.Update();

        }

        // Erzeugt ein Gewindefeature auf dem vorher erzeugten Schaft.
        internal void ErzeugeGewindeFeature()
        {
            // Gewinde...
            // ... Referenzen lateral und limit erzeugen
            Reference RefMantelflaeche = myPart.CreateReferenceFromBRepName(
                "RSur:(Face:(Brp:(Pad.1;0:(Brp:(Sketch.1;1)));None:();Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", mySchaft);
            Reference RefFrontflaeche = myPart.CreateReferenceFromBRepName(
                "RSur:(Face:(Brp:(Pad.1;2);None:();Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", mySchaft);

            // ... Gewinde erzeugen, Parameter setzen
            PARTITF.Thread thread1 = SF.AddNewThreadWithOutRef();
            thread1.Side = CatThreadSide.catRightSide;
            thread1.Diameter = 8.000000;
            thread1.Depth = 50.000000;
            thread1.LateralFaceElement = RefMantelflaeche; // Referenz lateral
            thread1.LimitFaceElement = RefFrontflaeche; // Referenz limit

            // ... Standardgewinde gesteuert über eine Konstruktionstabelle
            thread1.CreateUserStandardDesignTable("Metric_Thick_Pitch", @"C:\Program Files\Dassault Systemes\B28\win_b64\resources\standard\thread\Metric_Thick_Pitch.xml");
            thread1.Diameter = 8.000000;
            thread1.Pitch = 1.250000;

            // Part update und fertig
            myPart.Update();
        }

        // Erzeugt eine Helix 
        internal void ErzeugeGewindeHelix(Schraube myScrew)
        {
            Double P = 1.25;
            Double Ri = myScrew.Gewindedurchmesser / 2;
            HSF = (HybridShapeFactory)myPart.HybridShapeFactory;

            Sketch myGewinde = makeGewindeSkizze(myScrew);

            HybridShapeDirection HelixDir = HSF.AddNewDirectionByCoord(1, 0, 0);
            Reference RefHelixDir = myPart.CreateReferenceFromObject(HelixDir);

            HybridShapePointCoord HelixStartpunkt = HSF.AddNewPointCoord(0, 0, Ri);
            Reference RefHelixStartpunkt = myPart.CreateReferenceFromObject(HelixStartpunkt);

            HybridShapeHelix Helix = HSF.AddNewHelix(RefHelixDir, false, RefHelixStartpunkt, P, myScrew.Gewindelaenge, false, 0, 0, false);

            Reference RefHelix = myPart.CreateReferenceFromObject(Helix);
            Reference RefmyGewinde = myPart.CreateReferenceFromObject(myGewinde);

            myPart.Update();

            myPart.InWorkObject = myBody;

            OriginElements catOriginElements = this.hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneZX = (Reference)catOriginElements.PlaneZX;

            Sketch ChamferSkizze = mySketches.Add(RefmyPlaneZX);
            myPart.InWorkObject = ChamferSkizze;
            ChamferSkizze.set_Name("Fase");

            double H_links = Ri;
            double V_links = 0.65 * P;

            double H_rechts = Ri;
            double V_rechts = 0;

            double H_unten = Ri - 0.65 * P;
            double V_unten = 0;

            Factory2D catFactory2D3 = ChamferSkizze.OpenEdition();

            Point2D links = catFactory2D3.CreatePoint(H_links, V_links);
            Point2D rechts = catFactory2D3.CreatePoint(H_rechts, V_rechts);
            Point2D unten = catFactory2D3.CreatePoint(H_unten, V_unten);

            Line2D Oben = catFactory2D3.CreateLine(H_links, V_links, H_rechts, V_rechts);
            Oben.StartPoint = links;
            Oben.EndPoint = rechts;

            Line2D hypo = catFactory2D3.CreateLine(H_links, V_links, H_unten, V_unten);
            hypo.StartPoint = links;
            hypo.EndPoint = unten;

            Line2D seite = catFactory2D3.CreateLine(H_unten, V_unten, H_rechts, V_rechts);
            seite.StartPoint = unten;
            seite.EndPoint = rechts;

            ChamferSkizze.CloseEdition();

            myPart.InWorkObject = myBody;
            myPart.Update();

            Groove myChamfer = SF.AddNewGroove(ChamferSkizze);
            myChamfer.RevoluteAxis = RefHelixDir;

            myPart.Update();

            Slot GewindeRille = SF.AddNewSlotFromRef(RefmyGewinde, RefHelix);

            Reference RefmyPad = myPart.CreateReferenceFromObject(mySchaft);
            HybridShapeSurfaceExplicit GewindestangenSurface = HSF.AddNewSurfaceDatum(RefmyPad);
            Reference RefGewindestangenSurface = myPart.CreateReferenceFromObject(GewindestangenSurface);

            GewindeRille.ReferenceSurfaceElement = RefGewindestangenSurface;

            Reference RefGewindeRille = myPart.CreateReferenceFromObject(GewindeRille);

            myPart.Update();
        }

        // Separate Skizzenerzeugung für die Helix
        private Sketch makeGewindeSkizze(Schraube myScrew)
        {
            Double P = 1.25;
            Double Ri = myScrew.Gewindedurchmesser/2;

            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneZX = (Reference)catOriginElements.PlaneZX;

            Sketch myGewinde = mySketches.Add(RefmyPlaneZX);
            myPart.InWorkObject = myGewinde;
            myGewinde.set_Name("Gewinde");

            double V_oben_links = -(((((Math.Sqrt(3) / 2) * P) / 6) + 0.6134 * P) * Math.Tan((30 * Math.PI) / 180));
            double H_oben_links = Ri;

            double V_oben_rechts = (((((Math.Sqrt(3) / 2) * P) / 6) + 0.6134 * P) * Math.Tan((30 * Math.PI) / 180));
            double H_oben_rechts = Ri;

            double V_unten_links = -((0.1443 * P) * Math.Sin((60 * Math.PI) / 180));
            double H_unten_links = Ri - (0.6134 * P - 0.1443 * P) - Math.Sqrt(Math.Pow((0.1443 * P), 2) - Math.Pow((0.1443 * P) * Math.Sin((60 * Math.PI) / 180), 2));

            double V_unten_rechts = (0.1443 * P) * Math.Sin((60 * Math.PI) / 180);
            double H_unten_rechts = Ri - (0.6134 * P - 0.1443 * P) - Math.Sqrt(Math.Pow((0.1443 * P), 2) - Math.Pow((0.1443 * P) * Math.Sin((60 * Math.PI) / 180), 2));

            double V_Mittelpunkt = 0;
            double H_Mittelpunkt = Ri - ((0.6134 * P) - 0.1443 * P);

            Factory2D catFactory2D2 = myGewinde.OpenEdition();

            Point2D Oben_links = catFactory2D2.CreatePoint(H_oben_links, V_oben_links);
            Point2D Oben_rechts = catFactory2D2.CreatePoint(H_oben_rechts, V_oben_rechts);
            Point2D Unten_links = catFactory2D2.CreatePoint(H_unten_links, V_unten_links);
            Point2D Unten_rechts = catFactory2D2.CreatePoint(H_unten_rechts, V_unten_rechts);
            Point2D Mittelpunkt = catFactory2D2.CreatePoint(H_Mittelpunkt, V_Mittelpunkt);

            Line2D Oben = catFactory2D2.CreateLine(H_oben_links, V_oben_links, H_oben_rechts, V_oben_rechts);
            Oben.StartPoint = Oben_links;
            Oben.EndPoint = Oben_rechts;

            Line2D Rechts = catFactory2D2.CreateLine(H_oben_rechts, V_oben_rechts, H_unten_rechts, V_unten_rechts);
            Rechts.StartPoint = Oben_rechts;
            Rechts.EndPoint = Unten_rechts;

            Circle2D Verrundung = catFactory2D2.CreateCircle(H_Mittelpunkt, V_Mittelpunkt, 0.1443 * P, 0, 0);
            Verrundung.CenterPoint = Mittelpunkt;
            Verrundung.StartPoint = Unten_rechts;
            Verrundung.EndPoint = Unten_links;

            Line2D Links = catFactory2D2.CreateLine(H_oben_links, V_oben_links, H_unten_links, V_unten_links);
            Links.StartPoint = Unten_links;
            Links.EndPoint = Oben_links;

            myGewinde.CloseEdition();
            myPart.Update();

            return myGewinde;
        }

        #endregion

        public void OffsetEbene(Schraube myScrew)
        {
                      
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneYZ = (Reference)catOriginElements.PlaneYZ;
            myPart.InWorkObject = myPart;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)myPart.HybridShapeFactory;
            HybridShapePlaneOffset OffsetEbene = hybridShapeFactory1.AddNewPlaneOffset(RefmyPlaneYZ, -myScrew.Gesamtlaenge, true);
            OffsetEbene.set_Name("OffsetEbene");
            Reference RefOffsetEbene = myPart.CreateReferenceFromObject(OffsetEbene);
            HybridBodies hybridBodies1 = myPart.HybridBodies;
            HybridBody hybridBody1 = hybridBodies1.Item("Profile");
            hybridBody1.AppendHybridShape(OffsetEbene);


            myPart.Update();            
            Sketches catSketches2 = hybridBody1.HybridSketches;
            Sketch SkizzeaufOffset = catSketches2.Add(RefOffsetEbene);
            myPart.InWorkObject = SkizzeaufOffset;
            SkizzeaufOffset.set_Name("OffsetSkizze");
            SkizzeaufOffset = mySketches.Add(RefOffsetEbene);
            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();
            // Skizzierer verlassen
            SkizzeaufOffset.CloseEdition();


            // Part aktualisieren
            myPart.Update();
            myPart = hsp_catiaPartDoc.Part;
            Bodies bodies = myPart.Bodies;
            myBody = myPart.MainBody;
            // myBody = bodies.Add();

            // Hauptkoerper in Bearbeitung definieren
            myPart.InWorkObject = myPart.MainBody;

            // Skizze umbenennen
            SkizzeaufOffset.set_Name("Kreis2");

            // Skizze...
            // ... oeffnen für die Bearbeitung
            Factory2D catFactory2D2 = SkizzeaufOffset.OpenEdition();

            // ... Kreis erstellen
            double H0 = 0;
            double V0 = 0;
            Point2D Ursprung = catFactory2D2.CreatePoint(H0, V0);
            Circle2D Kreis = catFactory2D2.CreateCircle(H0, V0, myScrew.Kopfdurchmesser / 2, 0, 0);
            Kreis.CenterPoint = Ursprung;

            // ... schliessen
            SkizzeaufOffset.CloseEdition();

            // Schraubenschaft durch ein Pad erstellen
            Reference RefMySchaft = myPart.CreateReferenceFromObject(SkizzeaufOffset);
            mySchaft = SF.AddNewPadFromRef(RefMySchaft, myScrew.Kopfhoehe);
            myPart.Update();

        }

        public void OffsetEbeneSk(Schraube myScrew)
        {

            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneYZ = (Reference)catOriginElements.PlaneYZ;
            myPart.InWorkObject = myPart;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)myPart.HybridShapeFactory;
            HybridShapePlaneOffset OffsetEbene = hybridShapeFactory1.AddNewPlaneOffset(RefmyPlaneYZ, -myScrew.Gesamtlaenge, true);
            OffsetEbene.set_Name("OffsetEbene");
            Reference RefOffsetEbene = myPart.CreateReferenceFromObject(OffsetEbene);
            HybridBodies hybridBodies1 = myPart.HybridBodies;
            HybridBody hybridBody1 = hybridBodies1.Item("Profile");
            hybridBody1.AppendHybridShape(OffsetEbene);


            myPart.Update();
            Sketches catSketches2 = hybridBody1.HybridSketches;
            Sketch SkizzeaufOffset = catSketches2.Add(RefOffsetEbene);
            myPart.InWorkObject = SkizzeaufOffset;
            SkizzeaufOffset.set_Name("OffsetSkizze");
            SkizzeaufOffset = mySketches.Add(RefOffsetEbene);
            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();
            // Skizzierer verlassen
            SkizzeaufOffset.CloseEdition();


            // Part aktualisieren
            myPart.Update();
            myPart = hsp_catiaPartDoc.Part;
            Bodies bodies = myPart.Bodies;
            myBody = myPart.MainBody;
            // myBody = bodies.Add();

            // Hauptkoerper in Bearbeitung definieren
            myPart.InWorkObject = myPart.MainBody;

            // Skizze umbenennen
            SkizzeaufOffset.set_Name("Kreis2");

            // Skizze...
            // ... oeffnen für die Bearbeitung
            Factory2D catFactory2D2 = SkizzeaufOffset.OpenEdition();

            // Sechskant Punkte erstellen
            Point2D point2D1 = catFactory2D2.CreatePoint(-Math.Sqrt(3)/6 * myScrew.Kopfdurchmesser, -0.5* myScrew.Kopfdurchmesser);
            Point2D point2D2 = catFactory2D2.CreatePoint(Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, -0.5 * myScrew.Kopfdurchmesser);
            Point2D point2D3 = catFactory2D2.CreatePoint(Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0);
            Point2D point2D4 = catFactory2D2.CreatePoint(Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser);
            Point2D point2D5 = catFactory2D2.CreatePoint(-Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser);
            Point2D point2D6 = catFactory2D2.CreatePoint(-Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0);


            // Linien
            Line2D line2D1 = catFactory2D2.CreateLine(-Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, -0.5 * myScrew.Kopfdurchmesser, Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, -0.5 * myScrew.Kopfdurchmesser);
            line2D1.StartPoint = point2D1;
            line2D1.EndPoint = point2D2;

            Line2D line2D2 = catFactory2D2.CreateLine(Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, -0.5 * myScrew.Kopfdurchmesser, Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0);
            line2D2.StartPoint = point2D2;
            line2D2.EndPoint = point2D3;

            Line2D line2D3 = catFactory2D2.CreateLine(Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0, Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser);
            line2D3.StartPoint = point2D3;
            line2D3.EndPoint = point2D4;

            Line2D line2D4 = catFactory2D2.CreateLine( Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser, -Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser);
            line2D4.StartPoint = point2D4;
            line2D4.EndPoint = point2D5;

            Line2D line2D5 = catFactory2D2.CreateLine( -Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, 0.5 * myScrew.Kopfdurchmesser, -Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0);
            line2D5.StartPoint = point2D5;
            line2D5.EndPoint = point2D6;

            Line2D line2D6 = catFactory2D2.CreateLine( -Math.Sqrt(3) / 3 * myScrew.Kopfdurchmesser, 0, -Math.Sqrt(3) / 6 * myScrew.Kopfdurchmesser, -0.5 * myScrew.Kopfdurchmesser);
            line2D6.StartPoint = point2D6;
            line2D6.EndPoint = point2D1;

            // ... schliessen
            SkizzeaufOffset.CloseEdition();

            // Schraubenschaft durch ein Pad erstellen
            Reference RefMySchaft = myPart.CreateReferenceFromObject(SkizzeaufOffset);
            mySchaft = SF.AddNewPadFromRef(RefMySchaft, myScrew.Kopfhoehe);
            myPart.Update();

        }

    }
}
