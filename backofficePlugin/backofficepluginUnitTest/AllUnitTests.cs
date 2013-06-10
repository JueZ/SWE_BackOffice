using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using backofficePlugin;
using System.Collections.Generic;

namespace backofficepluginUnitTest
{
    [TestClass]
    public class AllUnitTests
    {
        [TestMethod]
        public void BL_Test_1()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Kunde"), typeof(List<EntityInterface>));
        }
        [TestMethod]
        public void BL_Test_2()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Kontakt"), typeof(List<EntityInterface>));
        }
        [TestMethod]
        public void BL_Test_3()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Angebot"), typeof(List<EntityInterface>));
        }
        [TestMethod]
        public void BL_Test_4()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Ausgangsrechnung"), typeof(List<EntityInterface>));
        }
        [TestMethod]
        public void BL_Test_5()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Eingangsrechnung"), typeof(List<EntityInterface>));
        }
        [TestMethod]
        public void BL_Test_6()
        {
            BL bl = new BL();

            Assert.IsInstanceOfType(bl.check("none", "Konto"), typeof(List<EntityInterface>));
        }

        [TestMethod]
        public void Angebot_Test_1()
        {
            Angebot angebot = new Angebot();

            angebot.AngebotID = 10;

            Assert.AreEqual(10, angebot.AngebotID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_2()
        {
            Angebot angebot = new Angebot();

            angebot.Angebotsname = "Testname";

            Assert.AreEqual("Testname", angebot.Angebotsname, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_3()
        {
            Angebot angebot = new Angebot();

            angebot.Angebotssumme = (float)10.5;

            Assert.AreEqual((float)10.5, angebot.Angebotssumme, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_4()
        {
            Angebot angebot = new Angebot();

            DateTime test = DateTime.Now;

            angebot.Datum = test;

            Assert.AreEqual(test, angebot.Datum, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_5()
        {
            Angebot angebot = new Angebot();

            angebot.Dauer = 50;

            Assert.AreEqual(50, angebot.Dauer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_6()
        {
            Angebot angebot = new Angebot();

            angebot.FK_KundeID = 100;

            Assert.AreEqual(100, angebot.FK_KundeID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_7()
        {
            Angebot angebot = new Angebot();

            angebot.FK_ProjektID = 200;

            Assert.AreEqual(200, angebot.FK_ProjektID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_8()
        {
            Angebot angebot = new Angebot();

            angebot.Kunde = "Kunden Name";

            Assert.AreEqual("Kunden Name", angebot.Kunde, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Angebot_Test_9()
        {
            Angebot angebot = new Angebot();

            Assert.IsInstanceOfType(angebot, typeof(EntityInterface));
        }

        [TestMethod]
        public void Ausgangsrechnung_Test_1()
        {
            Angebot angebot = new Angebot();

            Assert.IsInstanceOfType(angebot, typeof(EntityInterface));
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_2()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            ausgangsrechnung.AusgangsrechnungID = 10;

            Assert.AreEqual(10, ausgangsrechnung.AusgangsrechnungID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_3()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            ausgangsrechnung.Bezahlt = "Ja";

            Assert.AreEqual("Ja", ausgangsrechnung.Bezahlt, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_4()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            DateTime date = DateTime.Now;

            ausgangsrechnung.Datum = date;

            Assert.AreEqual(date, ausgangsrechnung.Datum, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_5()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            ausgangsrechnung.Kunde = "Kunden Name";

            Assert.AreEqual("Kunden Name", ausgangsrechnung.Kunde, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_6()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            ausgangsrechnung.Projekt = "Projektname";

            Assert.AreEqual("Projektname", ausgangsrechnung.Projekt, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Ausgangsrechnung_Test_7()
        {
            Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();

            ausgangsrechnung.Summe = (float)10.5;

            Assert.AreEqual((float)10.5, ausgangsrechnung.Summe, "Fehlgeschlagen");
        }


        [TestMethod]
        public void Eingangsrechnung_Test_1()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            Assert.IsInstanceOfType(eingangsrechnung, typeof(EntityInterface));
        }
        [TestMethod]
        public void Eingangsrechnung_Test_2()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.Beschreibung = "Beschreibung";

            Assert.AreEqual("Beschreibung", eingangsrechnung.Beschreibung, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_3()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.Bezahlt = "Ja";

            Assert.AreEqual("Ja", eingangsrechnung.Bezahlt, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_4()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            DateTime date = DateTime.Now;

            eingangsrechnung.Datum = date;

            Assert.AreEqual(date, eingangsrechnung.Datum, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_5()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.EingangsrechnungID = 1;

            Assert.AreEqual(1, eingangsrechnung.EingangsrechnungID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_6()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.Firma = "Firmenname";

            Assert.AreEqual("Firmenname", eingangsrechnung.Firma, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_7()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.FK_KontaktID = 1;

            Assert.AreEqual(1, eingangsrechnung.FK_KontaktID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Eingangsrechnung_Test_8()
        {
            Eingangsrechnung eingangsrechnung = new Eingangsrechnung();

            eingangsrechnung.Summe = (float)10.5;

            Assert.AreEqual((float)10.5, eingangsrechnung.Summe, "Fehlgeschlagen");
        }

        [TestMethod]
        public void Kontakt_Test_1()
        {
            Kontakt kontakt = new Kontakt();

            Assert.IsInstanceOfType(kontakt, typeof(EntityInterface));
        }
        [TestMethod]
        public void Kontakt_Test_2()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Anrede = "Herr";

            Assert.AreEqual("Herr", kontakt.Anrede, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_3()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.BIC = "ASDF";

            Assert.AreEqual("ASDF", kontakt.BIC, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_4()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.BLZ = "1234ASDF";

            Assert.AreEqual("1234ASDF", kontakt.BLZ, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_5()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Firma = "Firmenname";

            Assert.AreEqual("Firmenname", kontakt.Firma, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_6()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Firmenbuchnummer = "ASDF1234";

            Assert.AreEqual("ASDF1234", kontakt.Firmenbuchnummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_7()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.HNr = "10\\12";

            Assert.AreEqual("10\\12", kontakt.HNr, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_8()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.IBAN = "123456";

            Assert.AreEqual("123456", kontakt.IBAN, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_9()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.KontaktID = 1;

            Assert.AreEqual(1, kontakt.KontaktID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_10()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Kontonummer = "1234";

            Assert.AreEqual("1234", kontakt.Kontonummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_11()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Land = "AT";

            Assert.AreEqual("AT", kontakt.Land, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_12()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Nachname = "Maier";

            Assert.AreEqual("Maier", kontakt.Nachname, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_13()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.PLZ = "1234";

            Assert.AreEqual("1234", kontakt.PLZ, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_14()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Strasse = "Ringstrasse";

            Assert.AreEqual("Ringstrasse", kontakt.Strasse, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_15()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Telefonnummer = "011234";

            Assert.AreEqual("011234", kontakt.Telefonnummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_16()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.UID = "ASDF";

            Assert.AreEqual("ASDF", kontakt.UID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kontakt_Test_17()
        {
            Kontakt kontakt = new Kontakt();

            kontakt.Vorname = "Hans";

            Assert.AreEqual("Hans", kontakt.Vorname, "Fehlgeschlagen");
        }

        [TestMethod]
        public void Konto_Test_1()
        {
            Konto konto = new Konto();

            Assert.IsInstanceOfType(konto, typeof(EntityInterface));
        }
        [TestMethod]
        public void Konto_Test_2()
        {
            Konto konto = new Konto();

            konto.Beschreibung = "Test Test";

            Assert.AreEqual("Test Test", konto.Beschreibung, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Konto_Test_3()
        {
            Konto konto = new Konto();

            konto.BuchungszeileID = 1;

            Assert.AreEqual(1, konto.BuchungszeileID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Konto_Test_4()
        {
            Konto konto = new Konto();

            DateTime date = DateTime.Now;

            konto.Datum = date;

            Assert.AreEqual(date, konto.Datum, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Konto_Test_8()
        {
            Konto konto = new Konto();

            konto.Summe = 10000;
            Assert.AreEqual(10000, konto.Summe, "Fehlgeschlagen");
        }

        [TestMethod]
        public void Kunde_Test_1()
        {
            Kunde kunde = new Kunde();

            Assert.IsInstanceOfType(kunde, typeof(EntityInterface));
        }
        [TestMethod]
        public void Kunde_Test_2()
        {
            Kunde kunde = new Kunde();

            kunde.Anrede = "Herr";

            Assert.AreEqual("Herr", kunde.Anrede, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_3()
        {
            Kunde kunde = new Kunde();

            kunde.BIC = "ASDF";

            Assert.AreEqual("ASDF", kunde.BIC, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_4()
        {
            Kunde kunde = new Kunde();

            kunde.BLZ = "ASDF";

            Assert.AreEqual("ASDF", kunde.BLZ, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_5()
        {
            Kunde kunde = new Kunde();

            kunde.Firma = "Firmenname";

            Assert.AreEqual("Firmenname", kunde.Firma, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_6()
        {
            Kunde kunde = new Kunde();

            kunde.Firmenbuchnummer = "ASDF";

            Assert.AreEqual("ASDF", kunde.Firmenbuchnummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_7()
        {
            Kunde kunde = new Kunde();

            kunde.HNr = "10\\10";

            Assert.AreEqual("10\\10", kunde.HNr, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_8()
        {
            Kunde kunde = new Kunde();

            kunde.IBAN = "ASDF1234";

            Assert.AreEqual("ASDF1234", kunde.IBAN, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_9()
        {
            Kunde kunde = new Kunde();

            kunde.Kontonummer = "1234";

            Assert.AreEqual("1234", kunde.Kontonummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_10()
        {
            Kunde kunde = new Kunde();

            kunde.KundeID = 10;

            Assert.AreEqual(10, kunde.KundeID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_11()
        {
            Kunde kunde = new Kunde();

            kunde.Land = "AT";

            Assert.AreEqual("AT", kunde.Land, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_12()
        {
            Kunde kunde = new Kunde();

            kunde.Nachname = "Maier";

            Assert.AreEqual("Maier", kunde.Nachname, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_13()
        {
            Kunde kunde = new Kunde();

            kunde.PLZ = "1212";

            Assert.AreEqual("1212", kunde.PLZ, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_14()
        {
            Kunde kunde = new Kunde();

            kunde.Strasse = "Ringstrasse";

            Assert.AreEqual("Ringstrasse", kunde.Strasse, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_15()
        {
            Kunde kunde = new Kunde();

            kunde.Telefonnummer = "011234";

            Assert.AreEqual("011234", kunde.Telefonnummer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_16()
        {
            Kunde kunde = new Kunde();

            kunde.UID = "1234";

            Assert.AreEqual("1234", kunde.UID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Kunde_Test_17()
        {
            Kunde kunde = new Kunde();

            kunde.Vorname = "Hans";

            Assert.AreEqual("Hans", kunde.Vorname, "Fehlgeschlagen");
        }

        [TestMethod]
        public void Projekt_Test_1()
        {
            Projekt projekt = new Projekt();

            Assert.IsInstanceOfType(projekt, typeof(EntityInterface));
        }
        [TestMethod]
        public void Projekt_Test_2()
        {
            Projekt projekt = new Projekt();

            DateTime date = DateTime.Now;

            projekt.Datum = date;

            Assert.AreEqual(date, projekt.Datum, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Projekt_Test_3()
        {
            Projekt projekt = new Projekt();

            projekt.Dauer = (float)10.5;

            Assert.AreEqual((float)10.5, projekt.Dauer, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Projekt_Test_4()
        {
            Projekt projekt = new Projekt();

            projekt.Name = "Huber";

            Assert.AreEqual("Huber", projekt.Name, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Projekt_Test_5()
        {
            Projekt projekt = new Projekt();

            projekt.ProjektID = 10;

            Assert.AreEqual(10, projekt.ProjektID, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Projekt_Test_6()
        {
            Projekt projekt = new Projekt();

            projekt.Wert = (float)10.5;

            Assert.AreEqual((float)10.5, projekt.Wert, "Fehlgeschlagen");
        }
        [TestMethod]
        public void Projekt_Test_7()
        {
            Projekt projekt = new Projekt();

            projekt.Kunde = "Kundenname";

            Assert.AreEqual("Kundenname", projekt.Kunde, "Fehlgeschlagen");
        }
    }
}
