namespace backoffice
{
    partial class EditAusgangsrechnungenForm
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
            this.Save_Ausgangsrechnung = new System.Windows.Forms.Button();
            this.Discard_Ausgangsrechnung = new System.Windows.Forms.Button();
            this.Ausgangsrechnung_Projekt = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_Kunde = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_AusgangsrechnungID = new System.Windows.Forms.TextBox();
            this.AusgangsrechnungDatum = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_Summe = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_Bezahlt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Save_Ausgangsrechnung
            // 
            this.Save_Ausgangsrechnung.Location = new System.Drawing.Point(197, 13);
            this.Save_Ausgangsrechnung.Name = "Save_Ausgangsrechnung";
            this.Save_Ausgangsrechnung.Size = new System.Drawing.Size(75, 23);
            this.Save_Ausgangsrechnung.TabIndex = 0;
            this.Save_Ausgangsrechnung.Text = "Speichern";
            this.Save_Ausgangsrechnung.UseVisualStyleBackColor = true;
            this.Save_Ausgangsrechnung.Click += new System.EventHandler(this.Save_Ausgangsrechnung_Click);
            // 
            // Discard_Ausgangsrechnung
            // 
            this.Discard_Ausgangsrechnung.Location = new System.Drawing.Point(196, 43);
            this.Discard_Ausgangsrechnung.Name = "Discard_Ausgangsrechnung";
            this.Discard_Ausgangsrechnung.Size = new System.Drawing.Size(75, 23);
            this.Discard_Ausgangsrechnung.TabIndex = 1;
            this.Discard_Ausgangsrechnung.Text = "Verwerfen";
            this.Discard_Ausgangsrechnung.UseVisualStyleBackColor = true;
            this.Discard_Ausgangsrechnung.Click += new System.EventHandler(this.Discard_Ausgangsrechnung_Click);
            // 
            // Ausgangsrechnung_Projekt
            // 
            this.Ausgangsrechnung_Projekt.Enabled = false;
            this.Ausgangsrechnung_Projekt.Location = new System.Drawing.Point(13, 13);
            this.Ausgangsrechnung_Projekt.Name = "Ausgangsrechnung_Projekt";
            this.Ausgangsrechnung_Projekt.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_Projekt.TabIndex = 2;
            // 
            // Ausgangsrechnung_Kunde
            // 
            this.Ausgangsrechnung_Kunde.Enabled = false;
            this.Ausgangsrechnung_Kunde.Location = new System.Drawing.Point(13, 40);
            this.Ausgangsrechnung_Kunde.Name = "Ausgangsrechnung_Kunde";
            this.Ausgangsrechnung_Kunde.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_Kunde.TabIndex = 3;
            // 
            // Ausgangsrechnung_AusgangsrechnungID
            // 
            this.Ausgangsrechnung_AusgangsrechnungID.Location = new System.Drawing.Point(13, 141);
            this.Ausgangsrechnung_AusgangsrechnungID.Name = "Ausgangsrechnung_AusgangsrechnungID";
            this.Ausgangsrechnung_AusgangsrechnungID.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_AusgangsrechnungID.TabIndex = 4;
            this.Ausgangsrechnung_AusgangsrechnungID.Visible = false;
            // 
            // AusgangsrechnungDatum
            // 
            this.AusgangsrechnungDatum.Enabled = false;
            this.AusgangsrechnungDatum.Location = new System.Drawing.Point(13, 66);
            this.AusgangsrechnungDatum.Name = "AusgangsrechnungDatum";
            this.AusgangsrechnungDatum.Size = new System.Drawing.Size(100, 20);
            this.AusgangsrechnungDatum.TabIndex = 5;
            // 
            // Ausgangsrechnung_Summe
            // 
            this.Ausgangsrechnung_Summe.Enabled = false;
            this.Ausgangsrechnung_Summe.Location = new System.Drawing.Point(13, 92);
            this.Ausgangsrechnung_Summe.Name = "Ausgangsrechnung_Summe";
            this.Ausgangsrechnung_Summe.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_Summe.TabIndex = 6;
            // 
            // Ausgangsrechnung_Bezahlt
            // 
            this.Ausgangsrechnung_Bezahlt.AutoSize = true;
            this.Ausgangsrechnung_Bezahlt.Location = new System.Drawing.Point(52, 118);
            this.Ausgangsrechnung_Bezahlt.Name = "Ausgangsrechnung_Bezahlt";
            this.Ausgangsrechnung_Bezahlt.Size = new System.Drawing.Size(61, 17);
            this.Ausgangsrechnung_Bezahlt.TabIndex = 7;
            this.Ausgangsrechnung_Bezahlt.Text = "Bezahlt";
            this.Ausgangsrechnung_Bezahlt.UseVisualStyleBackColor = true;
            // 
            // EditAusgangsrechnungenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Ausgangsrechnung_Bezahlt);
            this.Controls.Add(this.Ausgangsrechnung_Summe);
            this.Controls.Add(this.AusgangsrechnungDatum);
            this.Controls.Add(this.Ausgangsrechnung_AusgangsrechnungID);
            this.Controls.Add(this.Ausgangsrechnung_Kunde);
            this.Controls.Add(this.Ausgangsrechnung_Projekt);
            this.Controls.Add(this.Discard_Ausgangsrechnung);
            this.Controls.Add(this.Save_Ausgangsrechnung);
            this.Name = "EditAusgangsrechnungenForm";
            this.Text = "EditAusgangsrechnungenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_Ausgangsrechnung;
        private System.Windows.Forms.Button Discard_Ausgangsrechnung;
        private System.Windows.Forms.TextBox Ausgangsrechnung_Projekt;
        private System.Windows.Forms.TextBox Ausgangsrechnung_Kunde;
        private System.Windows.Forms.TextBox Ausgangsrechnung_AusgangsrechnungID;
        private System.Windows.Forms.TextBox AusgangsrechnungDatum;
        private System.Windows.Forms.TextBox Ausgangsrechnung_Summe;
        private System.Windows.Forms.CheckBox Ausgangsrechnung_Bezahlt;
    }
}