using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backoffice
{
    public class Projekt : EntityInterface
    {
        private int _ProjektID;
        private string _Name;
        private string _Kunde;
        private DateTime _Datum;
        private float _Dauer;
        private float _Wert;

        public int ProjektID { get { return _ProjektID; } set { _ProjektID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Kunde { get { return _Kunde; } set { _Kunde = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public float Dauer { get { return _Dauer; } set { _Dauer = value; } }
        public float Wert { get { return _Wert; } set { _Wert = value; } }
    }
}
