namespace backoffice
{
    partial class EditZeiterfassungForm
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
            this.Save_Zeiterfassung = new System.Windows.Forms.Button();
            this.Discard = new System.Windows.Forms.Button();
            this.Zeiterfassung_ProjektID = new System.Windows.Forms.TextBox();
            this.Zeiterfassung_Vorname = new System.Windows.Forms.TextBox();
            this.Zeiterfassung_Nachname = new System.Windows.Forms.TextBox();
            this.Zeiterfassung_Datum = new System.Windows.Forms.TextBox();
            this.Zeiterfassung_Stunden = new System.Windows.Forms.TextBox();
            this.Zeiterfassung_ZeiterfassungID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Save_Zeiterfassung
            // 
            this.Save_Zeiterfassung.Location = new System.Drawing.Point(197, 13);
            this.Save_Zeiterfassung.Name = "Save_Zeiterfassung";
            this.Save_Zeiterfassung.Size = new System.Drawing.Size(75, 23);
            this.Save_Zeiterfassung.TabIndex = 0;
            this.Save_Zeiterfassung.Text = "Speichern";
            this.Save_Zeiterfassung.UseVisualStyleBackColor = true;
            this.Save_Zeiterfassung.Click += new System.EventHandler(this.Save_Zeiterfassung_Click);
            // 
            // Discard
            // 
            this.Discard.Location = new System.Drawing.Point(197, 42);
            this.Discard.Name = "Discard";
            this.Discard.Size = new System.Drawing.Size(75, 23);
            this.Discard.TabIndex = 1;
            this.Discard.Text = "Abbrechen";
            this.Discard.UseVisualStyleBackColor = true;
            this.Discard.Click += new System.EventHandler(this.Discard_Zeiterfassung_Click);
            // 
            // Zeiterfassung_ProjektID
            // 
            this.Zeiterfassung_ProjektID.Location = new System.Drawing.Point(13, 13);
            this.Zeiterfassung_ProjektID.Name = "Zeiterfassung_ProjektID";
            this.Zeiterfassung_ProjektID.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_ProjektID.TabIndex = 2;
            // 
            // Zeiterfassung_Vorname
            // 
            this.Zeiterfassung_Vorname.Location = new System.Drawing.Point(13, 40);
            this.Zeiterfassung_Vorname.Name = "Zeiterfassung_Vorname";
            this.Zeiterfassung_Vorname.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_Vorname.TabIndex = 3;
            // 
            // Zeiterfassung_Nachname
            // 
            this.Zeiterfassung_Nachname.Location = new System.Drawing.Point(13, 67);
            this.Zeiterfassung_Nachname.Name = "Zeiterfassung_Nachname";
            this.Zeiterfassung_Nachname.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_Nachname.TabIndex = 4;
            // 
            // Zeiterfassung_Datum
            // 
            this.Zeiterfassung_Datum.Location = new System.Drawing.Point(13, 94);
            this.Zeiterfassung_Datum.Name = "Zeiterfassung_Datum";
            this.Zeiterfassung_Datum.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_Datum.TabIndex = 5;
            // 
            // Zeiterfassung_Stunden
            // 
            this.Zeiterfassung_Stunden.Location = new System.Drawing.Point(13, 121);
            this.Zeiterfassung_Stunden.Name = "Zeiterfassung_Stunden";
            this.Zeiterfassung_Stunden.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_Stunden.TabIndex = 6;
            // 
            // Zeiterfassung_ZeiterfassungID
            // 
            this.Zeiterfassung_ZeiterfassungID.Location = new System.Drawing.Point(13, 148);
            this.Zeiterfassung_ZeiterfassungID.Name = "Zeiterfassung_ZeiterfassungID";
            this.Zeiterfassung_ZeiterfassungID.Size = new System.Drawing.Size(100, 20);
            this.Zeiterfassung_ZeiterfassungID.TabIndex = 7;
            this.Zeiterfassung_ZeiterfassungID.Visible = false;
            // 
            // EditZeiterfassungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Zeiterfassung_ZeiterfassungID);
            this.Controls.Add(this.Zeiterfassung_Stunden);
            this.Controls.Add(this.Zeiterfassung_Datum);
            this.Controls.Add(this.Zeiterfassung_Nachname);
            this.Controls.Add(this.Zeiterfassung_Vorname);
            this.Controls.Add(this.Zeiterfassung_ProjektID);
            this.Controls.Add(this.Discard);
            this.Controls.Add(this.Save_Zeiterfassung);
            this.Name = "EditZeiterfassungForm";
            this.Text = "EditZeiterfassungForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_Zeiterfassung;
        private System.Windows.Forms.Button Discard;
        private System.Windows.Forms.TextBox Zeiterfassung_ProjektID;
        private System.Windows.Forms.TextBox Zeiterfassung_Vorname;
        private System.Windows.Forms.TextBox Zeiterfassung_Nachname;
        private System.Windows.Forms.TextBox Zeiterfassung_Datum;
        private System.Windows.Forms.TextBox Zeiterfassung_Stunden;
        private System.Windows.Forms.TextBox Zeiterfassung_ZeiterfassungID;
    }
}