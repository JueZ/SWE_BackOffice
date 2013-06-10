namespace backoffice
{
    partial class EditKontoForm
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
            this.Konto_Kontonummer = new System.Windows.Forms.TextBox();
            this.Konto_Bankleitzahl = new System.Windows.Forms.TextBox();
            this.Konto_Name = new System.Windows.Forms.TextBox();
            this.Konto_Kontostand = new System.Windows.Forms.TextBox();
            this.Konto_KontoID = new System.Windows.Forms.TextBox();
            this.Save_Konto = new System.Windows.Forms.Button();
            this.Discard_Konto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Konto_Kontonummer
            // 
            this.Konto_Kontonummer.Location = new System.Drawing.Point(13, 13);
            this.Konto_Kontonummer.Name = "Konto_Kontonummer";
            this.Konto_Kontonummer.Size = new System.Drawing.Size(100, 20);
            this.Konto_Kontonummer.TabIndex = 0;
            // 
            // Konto_Bankleitzahl
            // 
            this.Konto_Bankleitzahl.Location = new System.Drawing.Point(13, 40);
            this.Konto_Bankleitzahl.Name = "Konto_Bankleitzahl";
            this.Konto_Bankleitzahl.Size = new System.Drawing.Size(100, 20);
            this.Konto_Bankleitzahl.TabIndex = 1;
            // 
            // Konto_Name
            // 
            this.Konto_Name.Location = new System.Drawing.Point(13, 67);
            this.Konto_Name.Name = "Konto_Name";
            this.Konto_Name.Size = new System.Drawing.Size(100, 20);
            this.Konto_Name.TabIndex = 2;
            // 
            // Konto_Kontostand
            // 
            this.Konto_Kontostand.Location = new System.Drawing.Point(13, 94);
            this.Konto_Kontostand.Name = "Konto_Kontostand";
            this.Konto_Kontostand.Size = new System.Drawing.Size(100, 20);
            this.Konto_Kontostand.TabIndex = 3;
            // 
            // Konto_KontoID
            // 
            this.Konto_KontoID.Location = new System.Drawing.Point(13, 121);
            this.Konto_KontoID.Name = "Konto_KontoID";
            this.Konto_KontoID.Size = new System.Drawing.Size(100, 20);
            this.Konto_KontoID.TabIndex = 4;
            this.Konto_KontoID.Visible = false;
            // 
            // Save_Konto
            // 
            this.Save_Konto.Location = new System.Drawing.Point(197, 13);
            this.Save_Konto.Name = "Save_Konto";
            this.Save_Konto.Size = new System.Drawing.Size(75, 23);
            this.Save_Konto.TabIndex = 5;
            this.Save_Konto.Text = "Speichern";
            this.Save_Konto.UseVisualStyleBackColor = true;
            this.Save_Konto.Click += new System.EventHandler(this.Save_Konto_Click);
            // 
            // Discard_Konto
            // 
            this.Discard_Konto.Location = new System.Drawing.Point(197, 42);
            this.Discard_Konto.Name = "Discard_Konto";
            this.Discard_Konto.Size = new System.Drawing.Size(75, 23);
            this.Discard_Konto.TabIndex = 6;
            this.Discard_Konto.Text = "Abbrechen";
            this.Discard_Konto.UseVisualStyleBackColor = true;
            this.Discard_Konto.Click += new System.EventHandler(this.Discard_Konto_Click);
            // 
            // EditKontoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Discard_Konto);
            this.Controls.Add(this.Save_Konto);
            this.Controls.Add(this.Konto_KontoID);
            this.Controls.Add(this.Konto_Kontostand);
            this.Controls.Add(this.Konto_Name);
            this.Controls.Add(this.Konto_Bankleitzahl);
            this.Controls.Add(this.Konto_Kontonummer);
            this.Name = "EditKontoForm";
            this.Text = "EditKontoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Konto_Kontonummer;
        private System.Windows.Forms.TextBox Konto_Bankleitzahl;
        private System.Windows.Forms.TextBox Konto_Name;
        private System.Windows.Forms.TextBox Konto_Kontostand;
        private System.Windows.Forms.TextBox Konto_KontoID;
        private System.Windows.Forms.Button Save_Konto;
        private System.Windows.Forms.Button Discard_Konto;
    }
}