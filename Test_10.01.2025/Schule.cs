namespace SchuleVerwaltung

{
    public class Schule
    {
        public List<Schueler> SchuelerListe { get; set; }
        public List<Klassenraum> KlassenraumListe { get; set; }

        public Schule()
        {
            SchuelerListe = new List<Schueler>();
            KlassenraumListe = new List<Klassenraum>();
        }

        public int AnzahlSchueler()
        {
            return SchuelerListe.Count;
        }

        public int AnzahlMaennlicheSchueler()
        {
            return SchuelerListe.Count(s => s.Geschlecht == "maennlich");
        }

        public int AnzahlWeiblicheSchueler()
        {
            return SchuelerListe.Count(s => s.Geschlecht == "weiblich");
        }

        public int AnzahlKlassenraeume()
        {
            return KlassenraumListe.Count;
        }

        public double Durchschnittsalter()
        {
            double durchschnitt = 0;
            foreach (var schueler in SchuelerListe)
            {
                durchschnitt += (DateTime.Now - schueler.Geburtsdatum).TotalDays / 365;
            }
            return Math.Round(durchschnitt / SchuelerListe.Count, 2);
        }

        public List<Klassenraum> RaeumeMitCynap()
        {
            List<Klassenraum> raeumeMitCynap = new List<Klassenraum>();
            foreach (var raum in KlassenraumListe)
            {
                if (raum.HatCynap)
                {
                    raeumeMitCynap.Add(raum);
                }
            }
            return raeumeMitCynap;
        }

        public int AnzahlKlassen()
        {
            HashSet<string> klassen = new HashSet<string>();
            foreach (var schueler in SchuelerListe)
            {
                klassen.Add(schueler.Schulklasse);
            }
            return klassen.Count;
        }

        public Dictionary<string, int> KlassenMitAnzahlSchueler()
        {
            var result = new Dictionary<string, int>();
            foreach (var schueler in SchuelerListe)
            {
                if (result.ContainsKey(schueler.Schulklasse))
                {
                    result[schueler.Schulklasse]++;
                }
                else
                {
                    result[schueler.Schulklasse] = 1;
                }
            }
            return result;
        }

        public double FrauenanteilInKlasse(string schulklasse)
        {
            int gesamt = 0, frauen = 0;
            foreach (var schueler in SchuelerListe)
            {
                if (schueler.Schulklasse == schulklasse)
                {
                    gesamt++;
                    if (schueler.Geschlecht == "weiblich")
                    {
                        frauen++;
                    }
                }
            }
            if (gesamt == 0) return 0;
            return (frauen / (double)gesamt) * 100;
        }

        public bool KannRaumFuerKlasseUnterrichten(string schulklasse, string raumBezeichnung)
        {
            int schuelerAnzahl = 0;
            foreach (var schueler in SchuelerListe)
            {
                if (schueler.Schulklasse == schulklasse)
                {
                    schuelerAnzahl++;
                }
            }

            var raum = KlassenraumListe.FirstOrDefault(r => r.RaumBezeichnung == raumBezeichnung);
            if (raum == null || schuelerAnzahl > raum.AnzahlPlaetze)
                return false;

            return true;
        }
    }
}
