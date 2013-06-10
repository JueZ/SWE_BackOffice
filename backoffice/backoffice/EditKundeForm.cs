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

namespace backoffice
{
    public partial class EditKundeForm : Form
    {
        private Button Save_Kunde;
        private TextBox Kunde_KundeID;
        private TextBox Kunde_BIC;
        private TextBox Kunde_IBAN;
        private TextBox Kunde_BLZ;
        private TextBox Kunde_Kontonummer;
        private TextBox Kunde_HNr;
        private TextBox Kunde_Strasse;
        private TextBox Kunde_PLZ;
        private TextBox Kunde_Land;
        private TextBox Kunde_Telefonnummer;
        private TextBox Kunde_UID;
        private TextBox Kunde_Firmenbuchnummer;
        private TextBox Kunde_Nachname;
        private TextBox Kunde_Vorname;
        private TextBox Kunde_Anrede;
        private TextBox Kunde_Firma;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button Discard_Kunde;
        

        public EditKundeForm(Kunde k , bool newKunde)
        {
            InitializeComponent();
            if (newKunde)
            {
                Kunde_KundeID.Text = "none";
                this.Text = "Neuen Kunden anlegen";
            }
            else
            {
                Kunde_KundeID.Text = k.KundeID.ToString();
                this.Text = "Kunde bearbeiten";

                Kunde_Firma.Text = k.Firma;
                Kunde_Anrede.Text = k.Anrede;
                Kunde_Vorname.Text = k.Vorname;
                Kunde_Nachname.Text = k.Nachname;
                Kunde_Firmenbuchnummer.Text = k.Firmenbuchnummer;
                Kunde_UID.Text = k.UID;
                Kunde_Telefonnummer.Text = k.Telefonnummer;
                Kunde_Land.Text = k.Land;
                Kunde_PLZ.Text = k.PLZ;
                Kunde_Strasse.Text = k.Strasse;
                Kunde_HNr.Text = k.HNr;
                Kunde_Kontonummer.Text = k.Kontonummer;
                Kunde_BLZ.Text = k.BLZ;
                Kunde_IBAN.Text = k.IBAN;
                Kunde_BIC.Text = k.BIC;
            }
        }


        private void Discard_Kunde_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Kunde_Click(object sender, EventArgs e)
        {

            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> kundenListe = new List<EntityInterface>();
            
            Kunde k = new Kunde();
            
            k.Firma = Kunde_Firma.Text.ToString();
            k.Anrede = Kunde_Anrede.Text.ToString();
            k.Vorname = Kunde_Vorname.Text.ToString();
            k.Nachname = Kunde_Nachname.Text.ToString();
            k.Firmenbuchnummer = Kunde_Firmenbuchnummer.Text.ToString();
            k.UID = Kunde_UID.Text.ToString();
            k.Telefonnummer = Kunde_Telefonnummer.Text.ToString();
            k.Land = Kunde_Land.Text.ToString();
            k.PLZ = Kunde_PLZ.Text.ToString();
            k.Strasse = Kunde_Strasse.Text.ToString();
            k.HNr = Kunde_HNr.Text.ToString();
            k.Kontonummer = Kunde_Kontonummer.Text.ToString();
            k.BLZ = Kunde_BLZ.Text.ToString();
            k.IBAN = Kunde_IBAN.Text.ToString();
            k.BIC = Kunde_BIC.Text.ToString();

            

            if (Kunde_KundeID.Text == "none")
            {
                kundenListe.Add(k);
                myProxy.add(kundenListe, "Kunde");
            }
            else
            {
                k.KundeID = Convert.ToInt32(Kunde_KundeID.Text);
                kundenListe.Add(k);
                myProxy.edit(kundenListe, "Kunde");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditKundeForm));
            this.Save_Kunde = new System.Windows.Forms.Button();
            this.Discard_Kunde = new System.Windows.Forms.Button();
            this.Kunde_KundeID = new System.Windows.Forms.TextBox();
            this.Kunde_BIC = new System.Windows.Forms.TextBox();
            this.Kunde_IBAN = new System.Windows.Forms.TextBox();
            this.Kunde_BLZ = new System.Windows.Forms.TextBox();
            this.Kunde_Kontonummer = new System.Windows.Forms.TextBox();
            this.Kunde_HNr = new System.Windows.Forms.TextBox();
            this.Kunde_Strasse = new System.Windows.Forms.TextBox();
            this.Kunde_PLZ = new System.Windows.Forms.TextBox();
            this.Kunde_Land = new System.Windows.Forms.TextBox();
            this.Kunde_Telefonnummer = new System.Windows.Forms.TextBox();
            this.Kunde_UID = new System.Windows.Forms.TextBox();
            this.Kunde_Firmenbuchnummer = new System.Windows.Forms.TextBox();
            this.Kunde_Nachname = new System.Windows.Forms.TextBox();
            this.Kunde_Vorname = new System.Windows.Forms.TextBox();
            this.Kunde_Anrede = new System.Windows.Forms.TextBox();
            this.Kunde_Firma = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save_Kunde
            // 
            this.Save_Kunde.Location = new System.Drawing.Point(476, 12);
            this.Save_Kunde.Name = "Save_Kunde";
            this.Save_Kunde.Size = new System.Drawing.Size(110, 35);
            this.Save_Kunde.TabIndex = 1;
            this.Save_Kunde.Text = "Speichern";
            this.Save_Kunde.UseVisualStyleBackColor = true;
            this.Save_Kunde.Click += new System.EventHandler(this.Save_Kunde_Click);
            // 
            // Discard_Kunde
            // 
            this.Discard_Kunde.Location = new System.Drawing.Point(476, 53);
            this.Discard_Kunde.Name = "Discard_Kunde";
            this.Discard_Kunde.Size = new System.Drawing.Size(110, 35);
            this.Discard_Kunde.TabIndex = 2;
            this.Discard_Kunde.Text = "Verwerfen";
            this.Discard_Kunde.UseVisualStyleBackColor = true;
            this.Discard_Kunde.Click += new System.EventHandler(this.Discard_Kunde_Click);
            // 
            // Kunde_KundeID
            // 
            this.Kunde_KundeID.Location = new System.Drawing.Point(154, 460);
            this.Kunde_KundeID.Name = "Kunde_KundeID";
            this.Kunde_KundeID.Size = new System.Drawing.Size(296, 20);
            this.Kunde_KundeID.TabIndex = 61;
            this.Kunde_KundeID.Visible = false;
            // 
            // Kunde_BIC
            // 
            this.Kunde_BIC.Location = new System.Drawing.Point(154, 430);
            this.Kunde_BIC.Name = "Kunde_BIC";
            this.Kunde_BIC.Size = new System.Drawing.Size(296, 20);
            this.Kunde_BIC.TabIndex = 60;
            // 
            // Kunde_IBAN
            // 
            this.Kunde_IBAN.Location = new System.Drawing.Point(154, 400);
            this.Kunde_IBAN.Name = "Kunde_IBAN";
            this.Kunde_IBAN.Size = new System.Drawing.Size(296, 20);
            this.Kunde_IBAN.TabIndex = 59;
            // 
            // Kunde_BLZ
            // 
            this.Kunde_BLZ.Location = new System.Drawing.Point(154, 370);
            this.Kunde_BLZ.Name = "Kunde_BLZ";
            this.Kunde_BLZ.Size = new System.Drawing.Size(296, 20);
            this.Kunde_BLZ.TabIndex = 58;
            // 
            // Kunde_Kontonummer
            // 
            this.Kunde_Kontonummer.Location = new System.Drawing.Point(154, 340);
            this.Kunde_Kontonummer.Name = "Kunde_Kontonummer";
            this.Kunde_Kontonummer.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Kontonummer.TabIndex = 57;
            // 
            // Kunde_HNr
            // 
            this.Kunde_HNr.Location = new System.Drawing.Point(154, 309);
            this.Kunde_HNr.Name = "Kunde_HNr";
            this.Kunde_HNr.Size = new System.Drawing.Size(296, 20);
            this.Kunde_HNr.TabIndex = 56;
            // 
            // Kunde_Strasse
            // 
            this.Kunde_Strasse.Location = new System.Drawing.Point(154, 279);
            this.Kunde_Strasse.Name = "Kunde_Strasse";
            this.Kunde_Strasse.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Strasse.TabIndex = 55;
            // 
            // Kunde_PLZ
            // 
            this.Kunde_PLZ.Location = new System.Drawing.Point(154, 249);
            this.Kunde_PLZ.Name = "Kunde_PLZ";
            this.Kunde_PLZ.Size = new System.Drawing.Size(296, 20);
            this.Kunde_PLZ.TabIndex = 54;
            // 
            // Kunde_Land
            // 
            this.Kunde_Land.Location = new System.Drawing.Point(154, 220);
            this.Kunde_Land.Name = "Kunde_Land";
            this.Kunde_Land.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Land.TabIndex = 53;
            // 
            // Kunde_Telefonnummer
            // 
            this.Kunde_Telefonnummer.Location = new System.Drawing.Point(154, 189);
            this.Kunde_Telefonnummer.Name = "Kunde_Telefonnummer";
            this.Kunde_Telefonnummer.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Telefonnummer.TabIndex = 52;
            // 
            // Kunde_UID
            // 
            this.Kunde_UID.Location = new System.Drawing.Point(154, 159);
            this.Kunde_UID.Name = "Kunde_UID";
            this.Kunde_UID.Size = new System.Drawing.Size(296, 20);
            this.Kunde_UID.TabIndex = 51;
            // 
            // Kunde_Firmenbuchnummer
            // 
            this.Kunde_Firmenbuchnummer.Location = new System.Drawing.Point(154, 129);
            this.Kunde_Firmenbuchnummer.Name = "Kunde_Firmenbuchnummer";
            this.Kunde_Firmenbuchnummer.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Firmenbuchnummer.TabIndex = 50;
            // 
            // Kunde_Nachname
            // 
            this.Kunde_Nachname.Location = new System.Drawing.Point(154, 100);
            this.Kunde_Nachname.Name = "Kunde_Nachname";
            this.Kunde_Nachname.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Nachname.TabIndex = 49;
            // 
            // Kunde_Vorname
            // 
            this.Kunde_Vorname.Location = new System.Drawing.Point(154, 69);
            this.Kunde_Vorname.Name = "Kunde_Vorname";
            this.Kunde_Vorname.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Vorname.TabIndex = 48;
            // 
            // Kunde_Anrede
            // 
            this.Kunde_Anrede.Location = new System.Drawing.Point(154, 39);
            this.Kunde_Anrede.Name = "Kunde_Anrede";
            this.Kunde_Anrede.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Anrede.TabIndex = 47;
            // 
            // Kunde_Firma
            // 
            this.Kunde_Firma.Location = new System.Drawing.Point(154, 9);
            this.Kunde_Firma.Name = "Kunde_Firma";
            this.Kunde_Firma.Size = new System.Drawing.Size(296, 20);
            this.Kunde_Firma.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 437);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "BIC";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "IBAN";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 377);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "BLZ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Kontonummer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "HNr";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Straße";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "PLZ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Land";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Telefonnummer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "UID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Firmenbuchnummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nachname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Vorname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Anrede";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Firma";
            // 
            // EditKundeForm
            // 
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(598, 517);
            this.Controls.Add(this.Kunde_KundeID);
            this.Controls.Add(this.Kunde_BIC);
            this.Controls.Add(this.Kunde_IBAN);
            this.Controls.Add(this.Kunde_BLZ);
            this.Controls.Add(this.Kunde_Kontonummer);
            this.Controls.Add(this.Kunde_HNr);
            this.Controls.Add(this.Kunde_Strasse);
            this.Controls.Add(this.Kunde_PLZ);
            this.Controls.Add(this.Kunde_Land);
            this.Controls.Add(this.Kunde_Telefonnummer);
            this.Controls.Add(this.Kunde_UID);
            this.Controls.Add(this.Kunde_Firmenbuchnummer);
            this.Controls.Add(this.Kunde_Nachname);
            this.Controls.Add(this.Kunde_Vorname);
            this.Controls.Add(this.Kunde_Anrede);
            this.Controls.Add(this.Kunde_Firma);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Discard_Kunde);
            this.Controls.Add(this.Save_Kunde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EditKundeForm";
            this.Text = "Edit Kunde Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       


      
    }
}
