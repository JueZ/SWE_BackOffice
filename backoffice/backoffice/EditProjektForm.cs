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
    public partial class EditProjektForm : Form
    {
        private Button Save_Projekt;
        private TextBox Projekt_ProjektID;
        private Label label2;
        private TextBox Projekt_Datum;
        private TextBox Projekt_Name;
        private Label label1;
        private Button Discard_Projekt;


        public EditProjektForm(Projekt a, bool newProjekt)
        {
            InitializeComponent();

            if (newProjekt)
            {
                Projekt_ProjektID.Text = "none";
                this.Text = "Neues Projekt anlegen";
            }
            else
            {
                this.Text = "Projekt bearbeiten";

                Projekt_Name.Text = a.Name;
                Projekt_ProjektID.Text = a.ProjektID.ToString();
                Projekt_Datum.Text = a.Datum.ToString();
            }
        }


        private void Discard_Projekt_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Projekt_Click(object sender, EventArgs e)
        {

            ProxyLayer myProxy = new ProxyLayer();

            List<EntityInterface> projektListe = new List<EntityInterface>();
            
            Projekt a = new Projekt();

           
            a.Name = Convert.ToString(Projekt_Name.Text);
            a.Datum = Convert.ToDateTime(Projekt_Datum.Text);

            if (Projekt_ProjektID.Text == "none")
            {
                projektListe.Add(a);
                myProxy.add(projektListe, "Projekt");
            }
            else
            {
                a.ProjektID = Convert.ToInt32(Projekt_ProjektID.Text);
                projektListe.Add(a);
                myProxy.edit(projektListe, "Projekt");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProjektForm));
            this.Save_Projekt = new System.Windows.Forms.Button();
            this.Discard_Projekt = new System.Windows.Forms.Button();
            this.Projekt_ProjektID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Projekt_Datum = new System.Windows.Forms.TextBox();
            this.Projekt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save_Projekt
            // 
            this.Save_Projekt.Location = new System.Drawing.Point(416, 12);
            this.Save_Projekt.Name = "Save_Projekt";
            this.Save_Projekt.Size = new System.Drawing.Size(110, 35);
            this.Save_Projekt.TabIndex = 1;
            this.Save_Projekt.Text = "Speichern";
            this.Save_Projekt.UseVisualStyleBackColor = true;
            this.Save_Projekt.Click += new System.EventHandler(this.Save_Projekt_Click);
            // 
            // Discard_Projekt
            // 
            this.Discard_Projekt.Location = new System.Drawing.Point(416, 53);
            this.Discard_Projekt.Name = "Discard_Projekt";
            this.Discard_Projekt.Size = new System.Drawing.Size(110, 35);
            this.Discard_Projekt.TabIndex = 2;
            this.Discard_Projekt.Text = "Verwerfen";
            this.Discard_Projekt.UseVisualStyleBackColor = true;
            this.Discard_Projekt.Click += new System.EventHandler(this.Discard_Projekt_Click);
            // 
            // Projekt_ProjektID
            // 
            this.Projekt_ProjektID.Location = new System.Drawing.Point(105, 65);
            this.Projekt_ProjektID.Name = "Projekt_ProjektID";
            this.Projekt_ProjektID.Size = new System.Drawing.Size(296, 20);
            this.Projekt_ProjektID.TabIndex = 19;
            this.Projekt_ProjektID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Datum";
            // 
            // Projekt_Datum
            // 
            this.Projekt_Datum.Location = new System.Drawing.Point(105, 39);
            this.Projekt_Datum.Name = "Projekt_Datum";
            this.Projekt_Datum.Size = new System.Drawing.Size(296, 20);
            this.Projekt_Datum.TabIndex = 24;
            // 
            // Projekt_Name
            // 
            this.Projekt_Name.Location = new System.Drawing.Point(105, 12);
            this.Projekt_Name.Name = "Projekt_Name";
            this.Projekt_Name.Size = new System.Drawing.Size(296, 20);
            this.Projekt_Name.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Projektname";
            // 
            // EditProjektForm
            // 
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(598, 256);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Projekt_Datum);
            this.Controls.Add(this.Projekt_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Projekt_ProjektID);
            this.Controls.Add(this.Discard_Projekt);
            this.Controls.Add(this.Save_Projekt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EditProjektForm";
            this.Text = "Edit Projekt Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       


      
    }
}
