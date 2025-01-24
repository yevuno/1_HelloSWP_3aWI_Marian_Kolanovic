namespace SchuleVerwaltung

{
    public class Klassenraum
    {
        public string RaumBezeichnung { get; set; }
        public int AnzahlPlaetze { get; set; }
        public bool HatCynap { get; set; }

        public Klassenraum(string raumBezeichnung, int anzahlPlaetze, bool hatCynap)
        {
            RaumBezeichnung = raumBezeichnung;
            AnzahlPlaetze = anzahlPlaetze;
            HatCynap = hatCynap;
        }
    }
}
