using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace backoffice
{
    public partial class EditAngebotForm : Form
    {
        private Button Save_Angebot;
        private TextBox Angebot_FK_ProjektID;
        private TextBox Angebot_FK_KundeID;
        private TextBox Angebot_Dauer;
        private TextBox Angebot_Angebotssumme;
        private TextBox Angebot_Angebotsname;
        private TextBox Angebot_AngebotID;
        private TextBox Angebot_UmsetzungsChance;
        private TextBox Angebot_Datum;
        private Button Discard_Angebot;
    
        public EditAngebotForm(Angebot a, bool newAngebot)
        {
            InitializeComponent();

            if (newAngebot)
            {
                Angebot_AngebotID.Text = "none";
                this.Text = "Neues Angebot anlegen";
            }
            else
            {
                Angebot_AngebotID.Text = a.AngebotID.ToString();
                this.Text = "Angebot bearbeiten";

                Angebot_FK_ProjektID.Text = a.FK_ProjektID.ToString();
                Angebot_FK_KundeID.Text = a.FK_KundeID.ToString();
                Angebot_Dauer.Text = a.Dauer.ToString();
                Angebot_Angebotssumme.Text = a.Angebotssumme.ToString();
                Angebot_Angebotsname.Text = a.Angebotsname;
                Angebot_AngebotID.Text = a.AngebotID.ToString();
                Angebot_UmsetzungsChance.Text = a.UmsetzungsChance.ToString();
                Angebot_Datum.Text = a.Datum.ToString();
            }
        }

        private void Discard_Angebot_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Angebot_Click(object sender, EventArgs e)
        {
            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> AngebotListe = new List<EntityInterface>();

            Angebot a = new Angebot();


            a.FK_ProjektID = Convert.ToInt32(Angebot_FK_ProjektID.Text);
            a.FK_KundeID = Convert.ToInt32(Angebot_FK_KundeID.Text);
            a.Angebotsname = Convert.ToString(Angebot_Angebotsname.Text);
            a.Angebotssumme = Convert.ToInt32(Angebot_Angebotssumme.Text);
            a.Dauer = Convert.ToInt32(Angebot_Dauer.Text);
            a.Datum = Convert.ToDateTime(Angebot_Datum.Text);
            a.UmsetzungsChance = Convert.ToInt32(Angebot_UmsetzungsChance.Text);

            if (Angebot_AngebotID.Text == "none")
            {
                AngebotListe.Add(a);
                myProxy.add(AngebotListe, "Angebot");
            }
            else
            {
                a.AngebotID = Convert.ToInt32(Angebot_AngebotID.Text);
                AngebotListe.Add(a);
                myProxy.edit(AngebotListe, "Angebot");
            }

            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void InitializeComponent()
        {
            this.Save_Angebot = new System.Windows.Forms.Button();
            this.Discard_Angebot = new System.Windows.Forms.Button();
            this.Angebot_FK_ProjektID = new System.Windows.Forms.TextBox();
            this.Angebot_FK_KundeID = new System.Windows.Forms.TextBox();
            this.Angebot_Dauer = new System.Windows.Forms.TextBox();
            this.Angebot_Angebotssumme = new System.Windows.Forms.TextBox();
            this.Angebot_Angebotsname = new System.Windows.Forms.TextBox();
            this.Angebot_AngebotID = new System.Windows.Forms.TextBox();
            this.Angebot_UmsetzungsChance = new System.Windows.Forms.TextBox();
            this.Angebot_Datum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Save_Angebot
            // 
            this.Save_Angebot.Location = new System.Drawing.Point(197, 13);
            this.Save_Angebot.Name = "Save_Angebot";
            this.Save_Angebot.Size = new System.Drawing.Size(75, 23);
            this.Save_Angebot.TabIndex = 0;
            this.Save_Angebot.Text = "Speichern";
            this.Save_Angebot.UseVisualStyleBackColor = true;
            this.Save_Angebot.Click += new System.EventHandler(this.Save_Angebot_Click);
            // 
            // Discard_Angebot
            // 
            this.Discard_Angebot.Location = new System.Drawing.Point(196, 43);
            this.Discard_Angebot.Name = "Discard_Angebot";
            this.Discard_Angebot.Size = new System.Drawing.Size(75, 23);
            this.Discard_Angebot.TabIndex = 1;
            this.Discard_Angebot.Text = "Abbrechen";
            this.Discard_Angebot.UseVisualStyleBackColor = true;
            this.Discard_Angebot.Click += new System.EventHandler(this.Discard_Angebot_Click);
            // 
            // Angebot_FK_ProjektID
            // 
            this.Angebot_FK_ProjektID.Location = new System.Drawing.Point(13, 13);
            this.Angebot_FK_ProjektID.Name = "Angebot_FK_ProjektID";
            this.Angebot_FK_ProjektID.Size = new System.Drawing.Size(100, 20);
            this.Angebot_FK_ProjektID.TabIndex = 2;
            // 
            // Angebot_FK_KundeID
            // 
            this.Angebot_FK_KundeID.Location = new System.Drawing.Point(13, 40);
            this.Angebot_FK_KundeID.Name = "Angebot_FK_KundeID";
            this.Angebot_FK_KundeID.Size = new System.Drawing.Size(100, 20);
            this.Angebot_FK_KundeID.TabIndex = 3;
            // 
            // Angebot_Dauer
            // 
            this.Angebot_Dauer.Location = new System.Drawing.Point(11, 145);
            this.Angebot_Dauer.Name = "Angebot_Dauer";
            this.Angebot_Dauer.Size = new System.Drawing.Size(100, 20);
            this.Angebot_Dauer.TabIndex = 7;
            // 
            // Angebot_Angebotssumme
            // 
            this.Angebot_Angebotssumme.Location = new System.Drawing.Point(12, 119);
            this.Angebot_Angebotssumme.Name = "Angebot_Angebotssumme";
            this.Angebot_Angebotssumme.Size = new System.Drawing.Size(100, 20);
            this.Angebot_Angebotssumme.TabIndex = 6;
            // 
            // Angebot_Angebotsname
            // 
            this.Angebot_Angebotsname.Location = new System.Drawing.Point(12, 92);
            this.Angebot_Angebotsname.Name = "Angebot_Angebotsname";
            this.Angebot_Angebotsname.Size = new System.Drawing.Size(100, 20);
            this.Angebot_Angebotsname.TabIndex = 5;
            // 
            // Angebot_AngebotID
            // 
            this.Angebot_AngebotID.Location = new System.Drawing.Point(10, 224);
            this.Angebot_AngebotID.Name = "Angebot_AngebotID";
            this.Angebot_AngebotID.Size = new System.Drawing.Size(100, 20);
            this.Angebot_AngebotID.TabIndex = 10;
            this.Angebot_AngebotID.Visible = false;
            // 
            // Angebot_UmsetzungsChance
            // 
            this.Angebot_UmsetzungsChance.Location = new System.Drawing.Point(11, 198);
            this.Angebot_UmsetzungsChance.Name = "Angebot_UmsetzungsChance";
            this.Angebot_UmsetzungsChance.Size = new System.Drawing.Size(100, 20);
            this.Angebot_UmsetzungsChance.TabIndex = 9;
            // 
            // Angebot_Datum
            // 
            this.Angebot_Datum.Location = new System.Drawing.Point(11, 171);
            this.Angebot_Datum.Name = "Angebot_Datum";
            this.Angebot_Datum.Size = new System.Drawing.Size(100, 20);
            this.Angebot_Datum.TabIndex = 8;
            // 
            // EditAngebotForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Angebot_AngebotID);
            this.Controls.Add(this.Angebot_UmsetzungsChance);
            this.Controls.Add(this.Angebot_Datum);
            this.Controls.Add(this.Angebot_Dauer);
            this.Controls.Add(this.Angebot_Angebotssumme);
            this.Controls.Add(this.Angebot_Angebotsname);
            this.Controls.Add(this.Angebot_FK_KundeID);
            this.Controls.Add(this.Angebot_FK_ProjektID);
            this.Controls.Add(this.Discard_Angebot);
            this.Controls.Add(this.Save_Angebot);
            this.Name = "EditAngebotForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
