using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backofficePlugin
{
    public class Kunde : EntityInterface
    {
        private int _KundeID;
        private string _Firma;
        private string _Anrede;
        private string _Vorname;
        private string _Nachname;
        private string _Firmenbuchnummer;
        private string _UID;
        private string _Telefonnummer;
        private string _Land;
        private string _PLZ;
        private string _Strasse;
        private string _HNr;
        private string _Kontonummer;
        private string _BLZ;
        private string _IBAN;
        private string _BIC;

        public int KundeID { get { return _KundeID; } set { _KundeID = value; } }
        public string Firma { get { return _Firma; } set { _Firma = value; } }
        public string Anrede { get { return _Anrede; } set { _Anrede = value; } }
        public string Vorname { get { return _Vorname; } set { _Vorname = value; } }
        public string Nachname { get { return _Nachname; } set { _Nachname = value; } }
        public string Firmenbuchnummer { get { return _Firmenbuchnummer; } set { _Firmenbuchnummer = value; } }
        public string UID { get { return _UID; } set { _UID = value; } }
        public string Telefonnummer { get { return _Telefonnummer; } set { _Telefonnummer = value; } }
        public string Land { get { return _Land; } set { _Land = value; } }
        public string PLZ { get { return _PLZ; } set { _PLZ = value; } }
        public string Strasse { get { return _Strasse; } set { _Strasse = value; } }
        public string HNr { get { return _HNr; } set { _HNr = value; } }
        public string Kontonummer { get { return _Kontonummer; } set { _Kontonummer = value; } }
        public string BLZ { get { return _BLZ; } set { _BLZ = value; } }
        public string IBAN { get { return _IBAN; } set { _IBAN = value; } }
        public string BIC { get { return _BIC; } set { _BIC = value; } }
    }
}
