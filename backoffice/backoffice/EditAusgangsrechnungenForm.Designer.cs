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
            this.Ausgangsrechnung_FK_ProjektID = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_FK_KundeID = new System.Windows.Forms.TextBox();
            this.Ausgangsrechnung_AusgangsrechnungID = new System.Windows.Forms.TextBox();
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
            // Ausgangsrechnung_FK_ProjektID
            // 
            this.Ausgangsrechnung_FK_ProjektID.Location = new System.Drawing.Point(13, 13);
            this.Ausgangsrechnung_FK_ProjektID.Name = "Ausgangsrechnung_FK_ProjektID";
            this.Ausgangsrechnung_FK_ProjektID.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_FK_ProjektID.TabIndex = 2;
            // 
            // Ausgangsrechnung_FK_KundeID
            // 
            this.Ausgangsrechnung_FK_KundeID.Location = new System.Drawing.Point(13, 40);
            this.Ausgangsrechnung_FK_KundeID.Name = "Ausgangsrechnung_FK_KundeID";
            this.Ausgangsrechnung_FK_KundeID.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_FK_KundeID.TabIndex = 3;
            // 
            // Ausgangsrechnung_AusgangsrechnungID
            // 
            this.Ausgangsrechnung_AusgangsrechnungID.Location = new System.Drawing.Point(13, 67);
            this.Ausgangsrechnung_AusgangsrechnungID.Name = "Ausgangsrechnung_AusgangsrechnungID";
            this.Ausgangsrechnung_AusgangsrechnungID.Size = new System.Drawing.Size(100, 20);
            this.Ausgangsrechnung_AusgangsrechnungID.TabIndex = 4;
            this.Ausgangsrechnung_AusgangsrechnungID.Visible = false;
            // 
            // EditAusgangsrechnungenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Ausgangsrechnung_AusgangsrechnungID);
            this.Controls.Add(this.Ausgangsrechnung_FK_KundeID);
            this.Controls.Add(this.Ausgangsrechnung_FK_ProjektID);
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
        private System.Windows.Forms.TextBox Ausgangsrechnung_FK_ProjektID;
        private System.Windows.Forms.TextBox Ausgangsrechnung_FK_KundeID;
        private System.Windows.Forms.TextBox Ausgangsrechnung_AusgangsrechnungID;
    }
}