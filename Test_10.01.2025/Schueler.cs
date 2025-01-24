namespace SchuleVerwaltung

{
    public class Schueler : Person
    {
        public string Schulklasse { get; set; }

        public Schueler(string geschlecht, DateTime geburtsdatum, string schulklasse)
            : base(geschlecht, geburtsdatum)
        {
            Schulklasse = schulklasse;
        }
    }
}
