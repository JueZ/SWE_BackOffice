namespace backoffice
{
    partial class EditEingangsrechnungenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Eingangsrechnung_FK_KontaktID = new System.Windows.Forms.TextBox();
            this.Eingangsrechnung_EingangsrechnungID = new System.Windows.Forms.TextBox();
            this.Save_Eingangsrechnung = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Eingangsrechnung_Summe = new System.Windows.Forms.TextBox();
            this.Eingangsrechnung_Beschreibung = new System.Windows.Forms.TextBox();
            this.Eingangsrechnung_Datum = new System.Windows.Forms.TextBox();
            this.Eingangsrechnung_Bezahlt = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Eingangsrechnung_FK_KontaktID
            // 
            this.Eingangsrechnung_FK_KontaktID.Location = new System.Drawing.Point(91, 13);
            this.Eingangsrechnung_FK_KontaktID.Name = "Eingangsrechnung_FK_KontaktID";
            this.Eingangsrechnung_FK_KontaktID.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_FK_KontaktID.TabIndex = 0;
            // 
            // Eingangsrechnung_EingangsrechnungID
            // 
            this.Eingangsrechnung_EingangsrechnungID.Location = new System.Drawing.Point(91, 140);
            this.Eingangsrechnung_EingangsrechnungID.Name = "Eingangsrechnung_EingangsrechnungID";
            this.Eingangsrechnung_EingangsrechnungID.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_EingangsrechnungID.TabIndex = 1;
            this.Eingangsrechnung_EingangsrechnungID.Visible = false;
            // 
            // Save_Eingangsrechnung
            // 
            this.Save_Eingangsrechnung.Location = new System.Drawing.Point(197, 13);
            this.Save_Eingangsrechnung.Name = "Save_Eingangsrechnung";
            this.Save_Eingangsrechnung.Size = new System.Drawing.Size(75, 23);
            this.Save_Eingangsrechnung.TabIndex = 2;
            this.Save_Eingangsrechnung.Text = "Speichern";
            this.Save_Eingangsrechnung.UseVisualStyleBackColor = true;
            this.Save_Eingangsrechnung.Click += new System.EventHandler(this.Save_Eingangsrechnung_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Discard_Eingangsrechnung_Click);
            // 
            // Eingangsrechnung_Summe
            // 
            this.Eingangsrechnung_Summe.Location = new System.Drawing.Point(91, 39);
            this.Eingangsrechnung_Summe.Name = "Eingangsrechnung_Summe";
            this.Eingangsrechnung_Summe.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_Summe.TabIndex = 4;
            // 
            // Eingangsrechnung_Beschreibung
            // 
            this.Eingangsrechnung_Beschreibung.Location = new System.Drawing.Point(91, 91);
            this.Eingangsrechnung_Beschreibung.Name = "Eingangsrechnung_Beschreibung";
            this.Eingangsrechnung_Beschreibung.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_Beschreibung.TabIndex = 5;
            // 
            // Eingangsrechnung_Datum
            // 
            this.Eingangsrechnung_Datum.Location = new System.Drawing.Point(91, 65);
            this.Eingangsrechnung_Datum.Name = "Eingangsrechnung_Datum";
            this.Eingangsrechnung_Datum.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_Datum.TabIndex = 7;
            // 
            // Eingangsrechnung_Bezahlt
            // 
            this.Eingangsrechnung_Bezahlt.AutoSize = true;
            this.Eingangsrechnung_Bezahlt.Location = new System.Drawing.Point(130, 117);
            this.Eingangsrechnung_Bezahlt.Name = "Eingangsrechnung_Bezahlt";
            this.Eingangsrechnung_Bezahlt.Size = new System.Drawing.Size(61, 17);
            this.Eingangsrechnung_Bezahlt.TabIndex = 8;
            this.Eingangsrechnung_Bezahlt.Text = "Bezahlt";
            this.Eingangsrechnung_Bezahlt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "FK_KontaktID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Summe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Beschreibung";
            // 
            // EditEingangsrechnungenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Eingangsrechnung_Bezahlt);
            this.Controls.Add(this.Eingangsrechnung_Datum);
            this.Controls.Add(this.Eingangsrechnung_Beschreibung);
            this.Controls.Add(this.Eingangsrechnung_Summe);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Save_Eingangsrechnung);
            this.Controls.Add(this.Eingangsrechnung_EingangsrechnungID);
            this.Controls.Add(this.Eingangsrechnung_FK_KontaktID);
            this.Name = "EditEingangsrechnungenForm";
            this.Text = "EditEingangsrechnungenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Eingangsrechnung_FK_KontaktID;
        private System.Windows.Forms.TextBox Eingangsrechnung_EingangsrechnungID;
        private System.Windows.Forms.Button Save_Eingangsrechnung;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Eingangsrechnung_Summe;
        private System.Windows.Forms.TextBox Eingangsrechnung_Beschreibung;
        private System.Windows.Forms.TextBox Eingangsrechnung_Datum;
        private System.Windows.Forms.CheckBox Eingangsrechnung_Bezahlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}