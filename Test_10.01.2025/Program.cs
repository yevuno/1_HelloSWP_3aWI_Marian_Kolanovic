using System;
using System.Linq;

namespace SchuleVerwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            var schule = new Schule();
            schule.SchuelerListe.Add(new Schueler("maennlich", new DateTime(2008, 1, 23), "3aWI"));
            schule.SchuelerListe.Add(new Schueler("weiblich", new DateTime(2007, 11, 11), "3aWI"));
            schule.KlassenraumListe.Add(new Klassenraum("247", 30, false));
            schule.KlassenraumListe.Add(new Klassenraum("185", 25, true));

            // Ausgabe für Tests
            Console.WriteLine($"Anzahl der Schüler: {schule.AnzahlSchueler()}");
            Console.WriteLine($"Anzahl der männlichen Schüler: {schule.AnzahlMaennlicheSchueler()}");
            Console.WriteLine($"Durchschnittsalter der Schüler: {schule.Durchschnittsalter()} Jahre");
            var raeumeMitCynap = schule.RaeumeMitCynap();
            Console.WriteLine($"Anzahl der Räume mit Cynap: {raeumeMitCynap.Count}");
            foreach (var raum in raeumeMitCynap)
            {
                Console.WriteLine($"Raum {raum.RaumBezeichnung}");
            }
            Console.WriteLine($"Anzahl der Klassen: {schule.AnzahlKlassen()}");
            var klassenMitAnzahlSchueler = schule.KlassenMitAnzahlSchueler();
            foreach (var klasse in klassenMitAnzahlSchueler)
            {
                Console.WriteLine($"Klasse {klasse.Key}: {klasse.Value} Schüler");
            }
            Console.WriteLine($"Frauenanteil in der Klasse 3aWI: {schule.FrauenanteilInKlasse("3aWI")}%");
            Console.WriteLine($"Kann die Klasse 3aWI im Raum 185 unterrichtet werden? {schule.KannRaumFuerKlasseUnterrichten("3aWI", "185")}");

            // Konsolenanwendung offen halten
            Console.WriteLine("Beliebige Taste zum beenden drücken.");
            Console.ReadKey();
        }
    }
}
