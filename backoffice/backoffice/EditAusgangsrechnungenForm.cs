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
    public partial class EditAusgangsrechnungenForm : Form
    {
        public EditAusgangsrechnungenForm(Ausgangsrechnung a, bool newAusgangsrechnung)
        {
            InitializeComponent();

            if (newAusgangsrechnung)
            {
                Ausgangsrechnung_AusgangsrechnungID.Text = "none";
                this.Text = "Neue Ausgangsrechnung anlegen";
            }
            else
            {
                Ausgangsrechnung_AusgangsrechnungID.Text = a.AusgangsrechnungID.ToString();
                this.Text = "Ausgangsrechnung bearbeiten";
            }
        }

        private void Discard_Ausgangsrechnung_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Ausgangsrechnung_Click(object sender, EventArgs e)
        {
            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> ausgangsrechnungListe = new List<EntityInterface>();

            Ausgangsrechnung a = new Ausgangsrechnung();


            a.FK_ProjektID = Convert.ToInt32(Ausgangsrechnung_FK_ProjektID.Text);
            a.FK_KundeID = Convert.ToInt32(Ausgangsrechnung_FK_KundeID.Text);

            if (Ausgangsrechnung_AusgangsrechnungID.Text == "none")
            {
                ausgangsrechnungListe.Add(a);
                myProxy.add(ausgangsrechnungListe, "Ausgangsrechnung");
            }
            else
            {
                a.AusgangsrechnungID = Convert.ToInt32(Ausgangsrechnung_AusgangsrechnungID.Text);
                ausgangsrechnungListe.Add(a);
                myProxy.edit(ausgangsrechnungListe, "Ausgangsrechnung");
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
