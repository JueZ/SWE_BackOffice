using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backofficePlugin
{
    public class Konto : EntityInterface
    {
        private int _BuchungzeileID;
        private string _Beschreibung;
        private DateTime _Datum;
        private float _Summe;


        public int BuchungszeileID { get { return _BuchungzeileID; } set { _BuchungzeileID = value; } }
        public string Beschreibung { get { return _Beschreibung; } set { _Beschreibung = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public float Summe { get { return _Summe; } set { _Summe = value; } }
        
    }
}
