using SchuleVerwaltung;


namespace Unitest01
{
    [TestFixture]
    public class SchuleTests
    {
        private SchuleVerwaltung.Schule schule;

        [SetUp]
        public void Setup()
        {
            schule = new Schule();
            schule.SchuelerListe.Add(new Schueler("maennlich", new DateTime(2008, 1, 23), "3aWI"));
            schule.SchuelerListe.Add(new Schueler("weiblich", new DateTime(2007, 11, 11), "3aWI"));
            schule.KlassenraumListe.Add(new Klassenraum("247", 30, false));
            schule.KlassenraumListe.Add(new Klassenraum("185", 25, true));
        }

        [Test]
        public void TestAnzahlSchueler()
        {
            var anzahl = schule.AnzahlSchueler();
            Assert.That(anzahl, Is.EqualTo(2));
        }

        [Test]
        public void TestAnzahlMaennlicheSchueler()
        {
            var anzahl = schule.AnzahlMaennlicheSchueler();
            Assert.That(anzahl, Is.EqualTo(1));
        }

        [Test]
        public void TestDurchschnittsalter()
        {
            var durchschnittsalter = schule.Durchschnittsalter();
            Assert.That(durchschnittsalter, Is.EqualTo(17.08).Within(0.1));
        }

        [Test]
        public void TestRaeumeMitCynap()
        {
            var raeumeMitCynap = schule.RaeumeMitCynap();
            Assert.That(raeumeMitCynap.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestFrauenanteilInKlasse()
        {
            var frauenanteil = schule.FrauenanteilInKlasse("3aWI");
            Assert.That(frauenanteil, Is.EqualTo(50));
        }

        [Test]
        public void TestKannRaumFuerKlasseUnterrichten()
        {
            var kannUnterrichtetWerden = schule.KannRaumFuerKlasseUnterrichten("3aWI", "185");
            Assert.That(kannUnterrichtetWerden, Is.True);
        }
    }
}
