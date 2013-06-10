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
    public partial class EditKontoForm : Form
    {
        public EditKontoForm(Konto a, bool newKonto)
        {
            InitializeComponent();

            if (newKonto)
            {
                Konto_KontoID.Text = "none";
                this.Text = "Neue Konto anlegen";
            }
            else
            {
                Konto_KontoID.Text = a.KontoID.ToString();
                this.Text = "Konto bearbeiten";
            }
        }

        private void Discard_Konto_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Konto_Click(object sender, EventArgs e)
        {
            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> KontoListe = new List<EntityInterface>();

            Konto a = new Konto();


            a.Kontonummer = Convert.ToInt32(Konto_Kontonummer.Text);
            a.Bankleitzahl = Convert.ToInt32(Konto_Bankleitzahl.Text);
            a.Name = Convert.ToString(Konto_Name.Text);
            a.Kontostand = Convert.ToInt32(Konto_Kontostand.Text);

            if (Konto_KontoID.Text == "none")
            {
                KontoListe.Add(a);
                myProxy.add(KontoListe, "Konto");
            }
            else
            {
                a.KontoID = Convert.ToInt32(Konto_KontoID.Text);
                KontoListe.Add(a);
                myProxy.edit(KontoListe, "Konto");
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
