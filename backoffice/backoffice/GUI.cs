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
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace backoffice
{
    public partial class GUI : Form
    {
        ProxyLayer myRequest;
        private confirmBox confirmBox;

        public GUI()
        {
            myRequest = new ProxyLayer();
            InitializeComponent();
        }

        
        //------------------------------------------------------------------------SELECT request on enter START-----------------------------------------//
        private void checkEnter(object sender, KeyEventArgs e)
        {   //When enter is pressed query is executed
            if (e.KeyCode == Keys.Enter){

                TextBox b = (TextBox)sender;
                //MessageBox.Show(b.Name);
                switch (b.Name)
                {
                    case "textBoxKunde":
                        Kunde.PerformClick();
                        break;
                    case "textBoxKontakt":
                        Kontakt.PerformClick();
                        break;
                    case "textBoxAngebot":
                        Angebot.PerformClick();
                        break;
                    case "textBoxProjekt":
                        Projekt.PerformClick();
                        break;
                    case "textBoxAusgangsrechnung":
                        Ausgangsrechnung.PerformClick();
                        break;
                    case "textBoxEingangsrechnung":
                        Eingangsrechnung.PerformClick();
                        break;
                    case "textBoxKonto":
                        Konto.PerformClick();
                        break;
 
                }
            }
        }

        //------------------------------------------------------------------------SELECT request on enter END-----------------------------------------//
        //------------------------------------------------------------------------EditFormClosedEventHandler for GUI refresh START----------------------------------------------------//
        void reloadOnFormClose(object sender, FormClosedEventArgs e)
        {
            //Updates the query on save
            if (sender.ToString().Contains("Kunde"))
            {
                Kunde.PerformClick();
            }
            else if (sender.ToString().Contains("Kontakt"))
            {
                Kontakt.PerformClick();
            }
            else if (sender.ToString().Contains("Angebot"))
            {
                Angebot.PerformClick();
            }
            else if (sender.ToString().Contains("Projekt"))
            {
                Projekt.PerformClick();
            }
            else if (sender.ToString().Contains("Ausgangsrechnung"))
            {
                Ausgangsrechnung.PerformClick();
            }
            else if (sender.ToString().Contains("Eingangsrechnung"))
            {
                Eingangsrechnung.PerformClick();
            }
            else if (sender.ToString().Contains("Konto"))
            {
                Konto.PerformClick();
            }

            
           
        }



        private void AusgangsrechnungenPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPath = System.IO.Directory.GetCurrentDirectory() + "\\Ausgangsrechnungen.pdf";
                SaveFileDialog sDialog = new SaveFileDialog();
                DialogResult result = sDialog.ShowDialog();
                if (result == DialogResult.OK) 
                {
                    pdfPath = sDialog.FileName;
                }
                


                Document pdfDoc = new Document();
                PdfPTable table = new PdfPTable(6);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new System.IO.FileStream(pdfPath,
                   System.IO.FileMode.Create));

                pdfDoc.Open();
                PdfPCell tcell = new PdfPCell(new Phrase("Ausgangsrechnungen"));
                tcell.Colspan = 6;
                tcell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(tcell);
                table.AddCell("AusgangsrechnungID");
                table.AddCell("Beschreibung");
                table.AddCell("Kunde");
                table.AddCell("Zeit");
                table.AddCell("Summe");
                table.AddCell("bereits bezahlt");

                foreach (DataGridViewRow row in dataGridViewAusgangsrechnung.SelectedRows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        table.AddCell(cell.Value.ToString());
                    }
                }

                pdfDoc.Add(table);


                PdfContentByte cb = writer.DirectContent;
                cb.MoveTo(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height);
                cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
                cb.Stroke();

                pdfDoc.Close();
                MessageBox.Show("Die markierten Ausgangsrechnungen wurden erfolgreich exportiert!");
            }
            catch
            {
                MessageBox.Show("Beim exportieren der Ausgangsrechnungen ist ein Fehler aufgetreten!");
            }
        }

        private void EingangsrechnungenPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPath = System.IO.Directory.GetCurrentDirectory() + "\\Eingangsrechnungen.pdf";
                SaveFileDialog sDialog = new SaveFileDialog();
                DialogResult result = sDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdfPath = sDialog.FileName;
                }



                Document pdfDoc = new Document();
                PdfPTable table = new PdfPTable(7);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new System.IO.FileStream(pdfPath,
                   System.IO.FileMode.Create));

                pdfDoc.Open();
                PdfPCell tcell = new PdfPCell(new Phrase("Eingangsrechnungen"));
                tcell.Colspan = 7;
                tcell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(tcell);
                table.AddCell("EingangsrechnungID");
                table.AddCell("KontaktID");
                table.AddCell("Kontakt");
                table.AddCell("Beschreibung");
                table.AddCell("Zeit");
                table.AddCell("Summe");
                table.AddCell("bereits bezahlt");

                foreach (DataGridViewRow row in dataGridViewEingangsrechnung.SelectedRows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        table.AddCell(cell.Value.ToString());
                    }
                }

                pdfDoc.Add(table);


                PdfContentByte cb = writer.DirectContent;
                cb.MoveTo(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height);
                cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
                cb.Stroke();

                pdfDoc.Close();
                MessageBox.Show("Die markierten Eingangsrechnungen wurden erfolgreich exportiert!");
            }
            catch
            {
                MessageBox.Show("Beim exportieren der Eingangsrechnungen ist ein Fehler aufgetreten!");
            }
        }

        private void ZeitenImportieren_Click(object sender, EventArgs e)
        {
            try
            {
                
                string[] lines;
                List<EntityInterface> liste = new List<EntityInterface>();
                liste = myRequest.request("none", "Projekt");
                
                List<EntityInterface> projektListeFile = new List<EntityInterface>();


                OpenFileDialog fDialog = new OpenFileDialog();
                DialogResult result = fDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    lines = System.IO.File.ReadAllLines(@fDialog.FileName);

                    foreach (string line in lines)
                    {

                        if (!string.IsNullOrEmpty(line))
                        {
                            Projekt p = new Projekt();
                            p.ProjektID = Convert.ToInt32(line.Split(';')[0]);
                            p.Dauer = float.Parse(line.Split(';')[1]);
                            projektListeFile.Add(p);
                        }

                    }
                }
                foreach (Projekt db in liste)
                {
                    foreach (Projekt file in projektListeFile)
                    {
                        if (db.ProjektID == file.ProjektID)
                        {
                            db.Dauer = file.Dauer;
                        }
                    }
                }
                
                myRequest.edit(liste, "Projekt");
                MessageBox.Show("Das Importieren der Projektzeiten war erfolgreich!");
            }
            catch
            {
                MessageBox.Show("Das Importieren der Projektzeiten ist felgeschlagen!");
            }
            
        }

        private void KontoExportieren_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPath = System.IO.Directory.GetCurrentDirectory() + "\\Kontodaten.pdf";
                SaveFileDialog sDialog = new SaveFileDialog();
                DialogResult result = sDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdfPath = sDialog.FileName;
                }



                Document pdfDoc = new Document();
                PdfPTable table = new PdfPTable(4);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new System.IO.FileStream(pdfPath,
                   System.IO.FileMode.Create));

                pdfDoc.Open();
                PdfPCell tcell = new PdfPCell(new Phrase("Kontodaten"));
                tcell.Colspan = 4;
                tcell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(tcell);
                table.AddCell("BuchungsID");
                table.AddCell("Beschreibung");
                table.AddCell("Datum");
                table.AddCell("Summe");
       

                foreach (DataGridViewRow row in dataGridViewKonto.SelectedRows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        table.AddCell(cell.Value.ToString());
                    }
                }

                pdfDoc.Add(table);


                PdfContentByte cb = writer.DirectContent;
                cb.MoveTo(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height);
                cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
                cb.Stroke();

                pdfDoc.Close();
                MessageBox.Show("Die markierten Kontodaten wurden erfolgreich exportiert!");
            }
            catch
            {
                MessageBox.Show("Beim exportieren der Kontodaten ist ein Fehler aufgetreten!");
            }
        }


    }
}
