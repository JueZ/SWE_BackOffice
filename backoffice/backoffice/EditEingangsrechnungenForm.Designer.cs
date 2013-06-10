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
            this.SuspendLayout();
            // 
            // Eingangsrechnung_FK_KontaktID
            // 
            this.Eingangsrechnung_FK_KontaktID.Location = new System.Drawing.Point(13, 13);
            this.Eingangsrechnung_FK_KontaktID.Name = "Eingangsrechnung_FK_KontaktID";
            this.Eingangsrechnung_FK_KontaktID.Size = new System.Drawing.Size(100, 20);
            this.Eingangsrechnung_FK_KontaktID.TabIndex = 0;
            // 
            // Eingangsrechnung_EingangsrechnungID
            // 
            this.Eingangsrechnung_EingangsrechnungID.Location = new System.Drawing.Point(13, 40);
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
            // EditEingangsrechnungenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}