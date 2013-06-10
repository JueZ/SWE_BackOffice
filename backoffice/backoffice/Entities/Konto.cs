using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backoffice
{
    public class Konto : EntityInterface
    
        private int _BuchungzeileID;
        private int _FK_AusgangsrechnungID;
        private int _FK_EingangsrechnungID;
        private string _Projekt;
        private string _Beschreibung;
        private DateTime _Datum;
        private float _Summe;


        public int BuchungszeileID { get { return _BuchungzeileID; } set { _BuchungzeileID = value; } }
        public int FK_AusgangsrechnungID { get { return _FK_AusgangsrechnungID; } set { _FK_AusgangsrechnungID = value; } }
        public int FK_EingangsrechnungID { get { return _FK_EingangsrechnungID; } set { _FK_EingangsrechnungID = value; } }
        public string Projekt { get { return _Projekt; } set { _Projekt = value; } }
        public string Beschreibung { get { return _Beschreibung; } set { _Beschreibung = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public float Summe { get { return _Summe; } set { _Summe = value; } }
        
    }
}
