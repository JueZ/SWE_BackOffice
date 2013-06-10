using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backofficePlugin
{
    public class Zeiterfassung : EntityInterface
    {
        private int _ZeiterfassungID;
        private int _ProjektID;
        private string _Vorname;
        private string _Nachname;
        private DateTime _Datum;
        private int _Stunden;

        public int ZeiterfassungID { get { return _ZeiterfassungID; } set { _ZeiterfassungID = value; } }
        public int ProjektID { get { return _ProjektID; } set { _ProjektID = value; } }
        public string Vorname { get { return _Vorname; } set { _Vorname = value; } }
        public string Nachname { get { return _Nachname; } set { _Nachname = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public int Stunden { get { return _Stunden; } set { _Stunden = value; } }
    }
}
