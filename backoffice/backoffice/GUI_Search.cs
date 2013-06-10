using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backoffice
{
    partial class GUI : Form
    {
        private void Search_Click(object sender, EventArgs e)
        {
            string para = null;
            Button b = (Button)sender;
            string textBox = null;
            switch (b.Name)
            {
                case "Kunde":
                    textBox = textBoxKunde.Text;
                    break;
                case "Kontakt":
                    textBox = textBoxKontakt.Text;
                    break;
                case "Angebot":
                    textBox = textBoxAngebot.Text;
                    break;
                case "Projekt":
                    textBox = textBoxProjekt.Text;
                    break;
                case "Ausgangsrechnung":
                    textBox = textBoxAusgangsrechnung.Text;
                    break;
                case "Eingangsrechnung":
                    textBox = textBoxEingangsrechnung.Text;
                    break;
                case "Konto":
                    textBox = textBoxKonto.Text;
                    break;
                case "Zeiterfassung":
                    textBox = textBoxZeiterfassung.Text;
                    break;
            }
            if (textBox.Trim() == String.Empty)
            {
                para = "none";
            }
            else
            {
                para = textBox;
            }


            string from = b.Name;
            List<EntityInterface> liste = new List<EntityInterface>();
            liste = myRequest.request(para, from);

            switch (b.Name)
            {
                case "Kunde":
                    List<Kunde> kundenliste = liste.Cast<Kunde>().ToList();
                    dataGridViewKunde.DataSource = kundenliste;
                    Result_Kunde.Text = dataGridViewKunde.Rows.Count == 1 ? "Ein Kunde gefunden" : dataGridViewKunde.Rows.Count + " Kunden gefunden";
                    dataGridViewKunde.Columns[dataGridViewKunde.Columns["KundeID"].Index].Visible = false;
                    dataGridViewKunde.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Kontakt":
                    List<Kontakt> kontaktliste = liste.Cast<Kontakt>().ToList();
                    dataGridViewKontakt.DataSource = kontaktliste;
                    Result_Kontakt.Text = dataGridViewKunde.Rows.Count == 1 ? "Ein Kontakt gefunden" : dataGridViewKontakt.Rows.Count + " Kontakte gefunden";
                    dataGridViewKontakt.Columns[dataGridViewKontakt.Columns["KontaktID"].Index].Visible = false;
                    dataGridViewKontakt.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Angebot":
                    List<Angebot> angebotliste = liste.Cast<Angebot>().ToList();
                    dataGridViewAngebot.DataSource = angebotliste;
                    Result_Angebot.Text = dataGridViewAngebot.Rows.Count == 1 ? "Ein Angebot gefunden" : dataGridViewAngebot.Rows.Count + " Angebote gefunden";
                    //dataGridViewAngebot.Columns[dataGridViewAngebot.Columns["AngebotID"].Index].Visible = false;
                    dataGridViewAngebot.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Projekt":
                    List<Projekt> projektliste = liste.Cast<Projekt>().ToList();
                    dataGridViewProjekt.DataSource = projektliste;
                    Result_Projekt.Text = dataGridViewProjekt.Rows.Count == 1 ? "Ein Projekt gefunden" : dataGridViewProjekt.Rows.Count + " Projekte gefunden";
                    dataGridViewProjekt.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridViewProjekt.Columns[dataGridViewProjekt.Columns["ProjektID"].Index].Visible = false;
                    break;
                case "Ausgangsrechnung":
                    List<Ausgangsrechnung> ausgangsrechnungliste = liste.Cast<Ausgangsrechnung>().ToList();
                    dataGridViewAusgangsrechnung.DataSource = ausgangsrechnungliste;
                    Result_Ausgangsrechnung.Text = dataGridViewAusgangsrechnung.Rows.Count == 1 ? "Ein Ausgangsrechungen gefunden" : dataGridViewAusgangsrechnung.Rows.Count + " Ausgangsrechungen gefunden";
                    dataGridViewAusgangsrechnung.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Eingangsrechnung":
                    List<Eingangsrechnung> eingangsrechnungliste = liste.Cast<Eingangsrechnung>().ToList();
                    dataGridViewEingangsrechnung.DataSource = eingangsrechnungliste;
                    Result_Eingangsrechnung.Text = dataGridViewEingangsrechnung.Rows.Count == 1 ? "Ein Eingangsrechungen gefunden" : dataGridViewEingangsrechnung.Rows.Count + " Eingangsrechungen gefunden";
                    dataGridViewEingangsrechnung.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Konto":
                    List<Konto> kontoliste = liste.Cast<Konto>().ToList();
                    dataGridViewKonto.DataSource = kontoliste;
                    dataGridViewKonto.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "Zeiterfassung":
                    List<Zeiterfassung> zeitliste = liste.Cast<Zeiterfassung>().ToList();
                    dataGridViewZeiterfassung.DataSource = zeitliste;
                    dataGridViewZeiterfassung.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }
        }
    }
}
