using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backoffice
{
    public class Angebot : EntityInterface
    {

        private int _AngebotID;
        private int _FK_ProjektID;
        private int _FK_KundeID;
        private string _Angebotsname;
        private float _Angebotssumme;
        private string _Kunde;
        private int _Dauer;
        private DateTime _Datum;
        private int _UmsetzungsChance;


        public int AngebotID { get { return _AngebotID; } set { _AngebotID = value; } }
        public int FK_ProjektID { get { return _FK_ProjektID; } set { _FK_ProjektID = value; } }
        public int FK_KundeID { get { return _FK_KundeID; } set { _FK_KundeID = value; } }
        public string Angebotsname { get { return _Angebotsname; } set { _Angebotsname = value; } }
        public float Angebotssumme { get { return _Angebotssumme; } set { _Angebotssumme = value; } }
        public string Kunde { get { return _Kunde; } set { _Kunde = value; } }
        public int Dauer { get { return _Dauer; } set { _Dauer = value; } }
        public DateTime Datum { get { return _Datum; } set { _Datum = value; } }
        public int UmsetzungsChance { get { return _UmsetzungsChance; } set { _UmsetzungsChance = value; } }
    }
}
