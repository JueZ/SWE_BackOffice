using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace backoffice
{
    [XmlInclude(typeof(Kunde))]
    [XmlInclude(typeof(Kontakt))]
    [XmlInclude(typeof(Angebot))]
    [XmlInclude(typeof(Projekt))]
    [XmlInclude(typeof(Konto))]
    [XmlInclude(typeof(Ausgangsrechnung))]
    [XmlInclude(typeof(Eingangsrechnung))]
    public abstract class EntityInterface
    {



    }
}
