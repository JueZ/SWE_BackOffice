namespace backoffice
{
    partial class confirmBox
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
            this.confirmText = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmText
            // 
            this.confirmText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.confirmText.BackColor = System.Drawing.SystemColors.Control;
            this.confirmText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.confirmText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.confirmText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmText.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.confirmText.Location = new System.Drawing.Point(12, 12);
            this.confirmText.Name = "confirmText";
            this.confirmText.ReadOnly = true;
            this.confirmText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.confirmText.Size = new System.Drawing.Size(329, 134);
            this.confirmText.TabIndex = 0;
            this.confirmText.Text = "";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Location = new System.Drawing.Point(91, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "YES";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button2.Location = new System.Drawing.Point(190, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "NO";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // confirmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(353, 187);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "confirmBox";
            this.Text = "Löschen bestätigen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox confirmText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}