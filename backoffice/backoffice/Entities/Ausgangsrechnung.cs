using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backoffice
{
    public class Ausgangsrechnung : EntityInterface
    {
        private int _AusgangsrechnungID;
        private int _FK_ProjektID;
        private string _Projekt;
        private string _Kunde;
        private DateTime _Datum;
        private float _Summe;
        private bool _Bezahlt;

        public int AusgangsrechnungID { get { return _AusgangsrechnungID; } set { _AusgangsrechnungID = value; } }
        public int FK_ProjektID { get { return _FK_ProjektID; } set { _FK_ProjektID = value; } }
        public string Projekt { get { return _Projekt; } set { _Projekt = value; } }
        public string Kunde { get { return _Kunde; } set { _Kunde = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public float Summe { get { return _Summe; } set { _Summe = value; } }
        public bool Bezahlt { get { return _Bezahlt; } set { _Bezahlt = value; } }
    }
}
