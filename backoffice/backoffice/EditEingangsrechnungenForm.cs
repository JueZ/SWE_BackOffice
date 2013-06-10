using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backoffice
{
    public partial class EditEingangsrechnungenForm : Form
    {
        //private TextBox Eingangsrechnung_FK_KontaktID;
        //private TextBox Eingangsrechnung_Summe;
        //private TextBox Eingangsrechnung_Datum;
        //private TextBox Eingangsrechnung_Beschreibung;
        //private CheckBox Eingangsrechnung_Bezahlt;

        public EditEingangsrechnungenForm(Eingangsrechnung a, bool newEingangsrechnung)
        {
            InitializeComponent();

            

            if (newEingangsrechnung)
            {
                Eingangsrechnung_EingangsrechnungID.Text = "none";
                this.Text = "Neue Eingangsrechnung anlegen";
            }
            else
            {
                Eingangsrechnung_EingangsrechnungID.Text = a.EingangsrechnungID.ToString();
                this.Text = "Eingangsrechnung bearbeiten";

                Eingangsrechnung_FK_KontaktID.Text = a.FK_KontaktID.ToString();
                Eingangsrechnung_Beschreibung.Text = a.Beschreibung;
                Eingangsrechnung_Datum.Text = a.Datum.ToString();
                Eingangsrechnung_Summe.Text = a.Summe.ToString();
                if (a.Bezahlt == "ja")
                    Eingangsrechnung_Bezahlt.Checked = true;
                else
                    Eingangsrechnung_Bezahlt.Checked = false;
            }

        }

        private void Discard_Eingangsrechnung_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Eingangsrechnung_Click(object sender, EventArgs e)
        {
            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> EingangsrechnungListe = new List<EntityInterface>();

            Eingangsrechnung a = new Eingangsrechnung();


            a.FK_KontaktID = Convert.ToInt32(Eingangsrechnung_FK_KontaktID.Text);
            a.Summe = Convert.ToInt32(Eingangsrechnung_FK_KontaktID.Text);
            a.Datum = Convert.ToDateTime(Eingangsrechnung_Datum.Text);
            a.Beschreibung = Convert.ToString(Eingangsrechnung_Beschreibung.Text);
            if (Eingangsrechnung_Bezahlt.Checked)
            {
                a.Bezahlt = "ja";
            }
            else
            {
                a.Bezahlt = "nein";
            }


            if (Eingangsrechnung_EingangsrechnungID.Text == "none")
            {
                EingangsrechnungListe.Add(a);
                myProxy.add(EingangsrechnungListe, "Eingangsrechnung");
            }
            else
            {
                a.EingangsrechnungID = Convert.ToInt32(Eingangsrechnung_EingangsrechnungID.Text);
                EingangsrechnungListe.Add(a);
                myProxy.edit(EingangsrechnungListe, "Eingangsrechnung");
            }

            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
    }
}
