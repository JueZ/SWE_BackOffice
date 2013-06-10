using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backoffice
{
    public class Eingangsrechnung : EntityInterface
    {
        private int _EingangsrechnungID;
        private int _FK_KontaktID;
        private string _Firma;
        private string _Beschreibung;
        private DateTime _Datum;
        private float _Summe;
        private string  _Bezahlt;


        public int EingangsrechnungID { get { return _EingangsrechnungID; } set { _EingangsrechnungID = value; } }
        public int FK_KontaktID { get { return _FK_KontaktID; } set { _FK_KontaktID = value; } }
        public string Firma { get { return _Firma; } set { _Firma = value; } }
        public string Beschreibung { get { return _Beschreibung; } set { _Beschreibung = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public float Summe { get { return _Summe; } set { _Summe = value; } }
        public string Bezahlt { get { return _Bezahlt; } set { _Bezahlt = value; } }
    }
}
