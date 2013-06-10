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
    public partial class EditKontaktForm : Form
    {
        private Button Save_Kontakt;
        private GroupBox groupBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox Kontakt_BIC;
        private TextBox Kontakt_IBAN;
        private TextBox Kontakt_BLZ;
        private TextBox Kontakt_Kontonummer;
        private TextBox Kontakt_HNr;
        private TextBox Kontakt_Strasse;
        private TextBox Kontakt_PLZ;
        private TextBox Kontakt_Land;
        private TextBox Kontakt_Telefonnummer;
        private TextBox Kontakt_UID;
        private TextBox Kontakt_Firmenbuchnummer;
        private TextBox Kontakt_Nachname;
        private TextBox Kontakt_Vorname;
        private TextBox Kontakt_Anrede;
        private TextBox Kontakt_Firma;
        private TextBox Kontakt_ID;
        private Button Discard_Kontakt;
        

        public EditKontaktForm(Kontakt k , bool newKontakt)
        {
            InitializeComponent();
            if (newKontakt)
            {
                Kontakt_ID.Text = "none";
                this.Text = "Neuen Kontakt anlegen";
            }
            else
            {
                Kontakt_ID.Text = k.KontaktID.ToString();
                this.Text = "Kontakt bearbeiten";

                Kontakt_Firma.Text = k.Firma;
                Kontakt_Anrede.Text = k.Anrede;
                Kontakt_Vorname.Text = k.Vorname;
                Kontakt_Nachname.Text = k.Nachname;
                Kontakt_Firmenbuchnummer.Text = k.Firmenbuchnummer;
                Kontakt_UID.Text = k.UID;
                Kontakt_Telefonnummer.Text = k.Telefonnummer;
                Kontakt_Land.Text = k.Land;
                Kontakt_PLZ.Text = k.PLZ;
                Kontakt_Strasse.Text = k.Strasse;
                Kontakt_HNr.Text = k.HNr;
                Kontakt_Kontonummer.Text = k.Kontonummer;
                Kontakt_BLZ.Text = k.BLZ;
                Kontakt_IBAN.Text = k.IBAN;
                Kontakt_BIC.Text = k.BIC;
            }
        }


        private void Discard_Kontakt_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Kontakt_Click(object sender, EventArgs e)
        {

            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> KontaktListe = new List<EntityInterface>();
            
            Kontakt k = new Kontakt();
            
            k.Firma = Kontakt_Firma.Text.ToString();
            k.Anrede = Kontakt_Anrede.Text.ToString();
            k.Vorname = Kontakt_Vorname.Text.ToString();
            k.Nachname = Kontakt_Nachname.Text.ToString();
            k.Firmenbuchnummer = Kontakt_Firmenbuchnummer.Text.ToString();
            k.UID = Kontakt_UID.Text.ToString();
            k.Telefonnummer = Kontakt_Telefonnummer.Text.ToString();
            k.Land = Kontakt_Land.Text.ToString();
            k.PLZ = Kontakt_PLZ.Text.ToString();
            k.Strasse = Kontakt_Strasse.Text.ToString();
            k.HNr = Kontakt_HNr.Text.ToString();
            k.Kontonummer = Kontakt_Kontonummer.Text.ToString();
            k.BLZ = Kontakt_BLZ.Text.ToString();
            k.IBAN = Kontakt_IBAN.Text.ToString();
            k.BIC = Kontakt_BIC.Text.ToString();

            

            if (Kontakt_ID.Text == "none")
            {
                KontaktListe.Add(k);
                myProxy.add(KontaktListe, "Kontakt");
            }
            else
            {
                k.KontaktID = Convert.ToInt32(Kontakt_ID.Text);
                KontaktListe.Add(k);
                myProxy.edit(KontaktListe, "Kontakt");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditKontaktForm));
            this.Save_Kontakt = new System.Windows.Forms.Button();
            this.Discard_Kontakt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Kontakt_ID = new System.Windows.Forms.TextBox();
            this.Kontakt_BIC = new System.Windows.Forms.TextBox();
            this.Kontakt_IBAN = new System.Windows.Forms.TextBox();
            this.Kontakt_BLZ = new System.Windows.Forms.TextBox();
            this.Kontakt_Kontonummer = new System.Windows.Forms.TextBox();
            this.Kontakt_HNr = new System.Windows.Forms.TextBox();
            this.Kontakt_Strasse = new System.Windows.Forms.TextBox();
            this.Kontakt_PLZ = new System.Windows.Forms.TextBox();
            this.Kontakt_Land = new System.Windows.Forms.TextBox();
            this.Kontakt_Telefonnummer = new System.Windows.Forms.TextBox();
            this.Kontakt_UID = new System.Windows.Forms.TextBox();
            this.Kontakt_Firmenbuchnummer = new System.Windows.Forms.TextBox();
            this.Kontakt_Nachname = new System.Windows.Forms.TextBox();
            this.Kontakt_Vorname = new System.Windows.Forms.TextBox();
            this.Kontakt_Anrede = new System.Windows.Forms.TextBox();
            this.Kontakt_Firma = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save_Kontakt
            // 
            this.Save_Kontakt.Location = new System.Drawing.Point(476, 12);
            this.Save_Kontakt.Name = "Save_Kontakt";
            this.Save_Kontakt.Size = new System.Drawing.Size(110, 35);
            this.Save_Kontakt.TabIndex = 1;
            this.Save_Kontakt.Text = "Save and close";
            this.Save_Kontakt.UseVisualStyleBackColor = true;
            this.Save_Kontakt.Click += new System.EventHandler(this.Save_Kontakt_Click);
            // 
            // Discard_Kontakt
            // 
            this.Discard_Kontakt.Location = new System.Drawing.Point(476, 53);
            this.Discard_Kontakt.Name = "Discard_Kontakt";
            this.Discard_Kontakt.Size = new System.Drawing.Size(110, 35);
            this.Discard_Kontakt.TabIndex = 2;
            this.Discard_Kontakt.Text = "Discard Changes and Close (Esc)";
            this.Discard_Kontakt.UseVisualStyleBackColor = true;
            this.Discard_Kontakt.Click += new System.EventHandler(this.Discard_Kontakt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Kontakt_ID);
            this.groupBox1.Controls.Add(this.Kontakt_BIC);
            this.groupBox1.Controls.Add(this.Kontakt_IBAN);
            this.groupBox1.Controls.Add(this.Kontakt_BLZ);
            this.groupBox1.Controls.Add(this.Kontakt_Kontonummer);
            this.groupBox1.Controls.Add(this.Kontakt_HNr);
            this.groupBox1.Controls.Add(this.Kontakt_Strasse);
            this.groupBox1.Controls.Add(this.Kontakt_PLZ);
            this.groupBox1.Controls.Add(this.Kontakt_Land);
            this.groupBox1.Controls.Add(this.Kontakt_Telefonnummer);
            this.groupBox1.Controls.Add(this.Kontakt_UID);
            this.groupBox1.Controls.Add(this.Kontakt_Firmenbuchnummer);
            this.groupBox1.Controls.Add(this.Kontakt_Nachname);
            this.groupBox1.Controls.Add(this.Kontakt_Vorname);
            this.groupBox1.Controls.Add(this.Kontakt_Anrede);
            this.groupBox1.Controls.Add(this.Kontakt_Firma);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 493);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontakt bearbeiten";
            // 
            // Kontakt_ID
            // 
            this.Kontakt_ID.Location = new System.Drawing.Point(148, 473);
            this.Kontakt_ID.Name = "Kontakt_ID";
            this.Kontakt_ID.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_ID.TabIndex = 30;
            this.Kontakt_ID.Visible = false;
            // 
            // Kontakt_BIC
            // 
            this.Kontakt_BIC.Location = new System.Drawing.Point(148, 443);
            this.Kontakt_BIC.Name = "Kontakt_BIC";
            this.Kontakt_BIC.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_BIC.TabIndex = 29;
            // 
            // Kontakt_IBAN
            // 
            this.Kontakt_IBAN.Location = new System.Drawing.Point(148, 413);
            this.Kontakt_IBAN.Name = "Kontakt_IBAN";
            this.Kontakt_IBAN.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_IBAN.TabIndex = 28;
            // 
            // Kontakt_BLZ
            // 
            this.Kontakt_BLZ.Location = new System.Drawing.Point(148, 383);
            this.Kontakt_BLZ.Name = "Kontakt_BLZ";
            this.Kontakt_BLZ.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_BLZ.TabIndex = 27;
            // 
            // Kontakt_Kontonummer
            // 
            this.Kontakt_Kontonummer.Location = new System.Drawing.Point(148, 353);
            this.Kontakt_Kontonummer.Name = "Kontakt_Kontonummer";
            this.Kontakt_Kontonummer.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Kontonummer.TabIndex = 26;
            // 
            // Kontakt_HNr
            // 
            this.Kontakt_HNr.Location = new System.Drawing.Point(148, 322);
            this.Kontakt_HNr.Name = "Kontakt_HNr";
            this.Kontakt_HNr.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_HNr.TabIndex = 25;
            // 
            // Kontakt_Strasse
            // 
            this.Kontakt_Strasse.Location = new System.Drawing.Point(148, 292);
            this.Kontakt_Strasse.Name = "Kontakt_Strasse";
            this.Kontakt_Strasse.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Strasse.TabIndex = 24;
            // 
            // Kontakt_PLZ
            // 
            this.Kontakt_PLZ.Location = new System.Drawing.Point(148, 262);
            this.Kontakt_PLZ.Name = "Kontakt_PLZ";
            this.Kontakt_PLZ.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_PLZ.TabIndex = 23;
            // 
            // Kontakt_Land
            // 
            this.Kontakt_Land.Location = new System.Drawing.Point(148, 233);
            this.Kontakt_Land.Name = "Kontakt_Land";
            this.Kontakt_Land.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Land.TabIndex = 22;
            // 
            // Kontakt_Telefonnummer
            // 
            this.Kontakt_Telefonnummer.Location = new System.Drawing.Point(148, 202);
            this.Kontakt_Telefonnummer.Name = "Kontakt_Telefonnummer";
            this.Kontakt_Telefonnummer.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Telefonnummer.TabIndex = 21;
            // 
            // Kontakt_UID
            // 
            this.Kontakt_UID.Location = new System.Drawing.Point(148, 172);
            this.Kontakt_UID.Name = "Kontakt_UID";
            this.Kontakt_UID.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_UID.TabIndex = 20;
            // 
            // Kontakt_Firmenbuchnummer
            // 
            this.Kontakt_Firmenbuchnummer.Location = new System.Drawing.Point(148, 142);
            this.Kontakt_Firmenbuchnummer.Name = "Kontakt_Firmenbuchnummer";
            this.Kontakt_Firmenbuchnummer.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Firmenbuchnummer.TabIndex = 19;
            // 
            // Kontakt_Nachname
            // 
            this.Kontakt_Nachname.Location = new System.Drawing.Point(148, 113);
            this.Kontakt_Nachname.Name = "Kontakt_Nachname";
            this.Kontakt_Nachname.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Nachname.TabIndex = 18;
            // 
            // Kontakt_Vorname
            // 
            this.Kontakt_Vorname.Location = new System.Drawing.Point(148, 82);
            this.Kontakt_Vorname.Name = "Kontakt_Vorname";
            this.Kontakt_Vorname.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Vorname.TabIndex = 17;
            // 
            // Kontakt_Anrede
            // 
            this.Kontakt_Anrede.Location = new System.Drawing.Point(148, 52);
            this.Kontakt_Anrede.Name = "Kontakt_Anrede";
            this.Kontakt_Anrede.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Anrede.TabIndex = 16;
            // 
            // Kontakt_Firma
            // 
            this.Kontakt_Firma.Location = new System.Drawing.Point(148, 22);
            this.Kontakt_Firma.Name = "Kontakt_Firma";
            this.Kontakt_Firma.Size = new System.Drawing.Size(296, 20);
            this.Kontakt_Firma.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 450);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "BIC";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "IBAN";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 390);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "BLZ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 356);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Kontonummer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "HNr";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Straße";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "PLZ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Land";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Telefonnummer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "UID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Firmenbuchnummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nachname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vorname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Anrede";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firma";
            // 
            // EditForm
            // 
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(598, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Discard_Kontakt);
            this.Controls.Add(this.Save_Kontakt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EditForm";
            this.Text = "Edit Kontakt Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

       


      
    }
}
