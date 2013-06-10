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
    public partial class EditZeiterfassungForm : Form
    {
        public EditZeiterfassungForm(Zeiterfassung a, bool newZeiterfassung)
        {
            InitializeComponent();

            if (newZeiterfassung)
            {
                Zeiterfassung_ZeiterfassungID.Text = "none";
                this.Text = "Neue Zeiterfassung anlegen";
            }
            else
            {
                Zeiterfassung_ZeiterfassungID.Text = a.ZeiterfassungID.ToString();
                this.Text = "Zeiterfassung bearbeiten";
            }
        }

        private void Discard_Zeiterfassung_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Zeiterfassung_Click(object sender, EventArgs e)
        {
            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> ZeiterfassungListe = new List<EntityInterface>();

            Zeiterfassung a = new Zeiterfassung();


            a.ProjektID = Convert.ToInt32(Zeiterfassung_ProjektID.Text);
            a.Vorname = Convert.ToString(Zeiterfassung_Vorname.Text);
            a.Nachname = Convert.ToString(Zeiterfassung_Nachname.Text);
            a.Datum = Convert.ToDateTime(Zeiterfassung_Datum.Text);
            a.Stunden = Convert.ToInt32(Zeiterfassung_Stunden.Text);

            if (Zeiterfassung_ZeiterfassungID.Text == "none")
            {
                ZeiterfassungListe.Add(a);
                myProxy.add(ZeiterfassungListe, "Zeiterfassung");
            }
            else
            {
                a.ZeiterfassungID = Convert.ToInt32(Zeiterfassung_ZeiterfassungID.Text);
                ZeiterfassungListe.Add(a);
                myProxy.edit(ZeiterfassungListe, "Zeiterfassung");
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
