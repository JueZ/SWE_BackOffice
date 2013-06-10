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
        //------------------------------------------------------------------------delete functions START----------------------------------------------------//
        private void deleteKunde_Click(object sender, EventArgs e)
        {
            delete("Kunde");
        }

        private void deleteKontakt_Click(object sender, EventArgs e)
        {
            delete("Kontakt");
        }

        private void deleteAngebot_Click(object sender, EventArgs e)
        {
            delete("Angebot");
        }

        private void deleteProjekt_Click(object sender, EventArgs e)
        {
            delete("Projekt");
        }

        private void deleteAusgangsrechnung_Click(object sender, EventArgs e)
        {
            delete("Ausgangsrechnung");
        }

        private void deleteEingangsrechnung_Click(object sender, EventArgs e)
        {
            delete("Eingangsrechnung");
        }

        private void deleteKonto_Click(object sender, EventArgs e)
        {
            delete("Konto");
        }

        private void deleteZeiterfassung_Click(object sender, EventArgs e)
        {
            delete("Zeiterfassung");
        }   

        private void delete(string entity)
        {
            List<EntityInterface> liste = new List<EntityInterface>();

            if(entity=="Kunde")
            {
                foreach (DataGridViewRow selRow in dataGridViewKunde.SelectedRows)
                {
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(dataGridViewKunde.Rows[selRow.Index].Cells[dataGridViewKunde.Columns["KundeID"].Index].Value.ToString());
                    liste.Add(kunde);
                }


                if (MessageBox.Show(dataGridViewKunde.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Kunde.PerformClick();
                }
            }
            else if(entity=="Kontakt")
            {
                foreach (DataGridViewRow selRow in dataGridViewKontakt.SelectedRows)
                {
                    Kontakt kontakt = new Kontakt();
                    kontakt.KontaktID = Convert.ToInt32(dataGridViewKontakt.Rows[selRow.Index].Cells[dataGridViewKontakt.Columns["KontaktID"].Index].Value.ToString());
                    liste.Add(kontakt);
                }


                if (MessageBox.Show(dataGridViewKontakt.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Kontakt.PerformClick();
                }
            }
            else if (entity == "Angebot")
            {
                foreach (DataGridViewRow selRow in dataGridViewAngebot.SelectedRows)
                {
                    Angebot angebot = new Angebot();
                    angebot.AngebotID = Convert.ToInt32(dataGridViewAngebot.Rows[selRow.Index].Cells[dataGridViewAngebot.Columns["AngebotID"].Index].Value.ToString());
                    liste.Add(angebot);
                }


                if (MessageBox.Show(dataGridViewAngebot.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Angebot.PerformClick();
                }
            }
            else if (entity == "Projekt")
            {
                foreach (DataGridViewRow selRow in dataGridViewProjekt.SelectedRows)
                {
                    Projekt projekt = new Projekt();
                    projekt.ProjektID = Convert.ToInt32(dataGridViewProjekt.Rows[selRow.Index].Cells[dataGridViewProjekt.Columns["ProjektID"].Index].Value.ToString());
                    liste.Add(projekt);
                }


                if (MessageBox.Show(dataGridViewProjekt.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Projekt.PerformClick();
                }
            }
            else if (entity == "Eingangsrechnung")
            {
                foreach (DataGridViewRow selRow in dataGridViewEingangsrechnung.SelectedRows)
                {
                    Eingangsrechnung eingangsrechnung = new Eingangsrechnung();
                    eingangsrechnung.EingangsrechnungID = Convert.ToInt32(dataGridViewEingangsrechnung.Rows[selRow.Index].Cells[dataGridViewEingangsrechnung.Columns["EingangsrechnungID"].Index].Value.ToString());
                    liste.Add(eingangsrechnung);
                }


                if (MessageBox.Show(dataGridViewEingangsrechnung.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Eingangsrechnung.PerformClick();
                }
            }
            else if (entity == "Ausgangsrechnung")
            {
                foreach (DataGridViewRow selRow in dataGridViewAusgangsrechnung.SelectedRows)
                {
                    Ausgangsrechnung ausgangsrechnung = new Ausgangsrechnung();
                    ausgangsrechnung.AusgangsrechnungID = Convert.ToInt32(dataGridViewAusgangsrechnung.Rows[selRow.Index].Cells[dataGridViewAusgangsrechnung.Columns["AusgangsrechnungID"].Index].Value.ToString());
                    liste.Add(ausgangsrechnung);
                }


                if (MessageBox.Show(dataGridViewAusgangsrechnung.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Ausgangsrechnung.PerformClick();
                }
            }
            else if (entity == "Konto")
            {
                foreach (DataGridViewRow selRow in dataGridViewKonto.SelectedRows)
                {
                    Konto konto = new Konto();
                    konto.KontoID = Convert.ToInt32(dataGridViewKonto.Rows[selRow.Index].Cells[dataGridViewKonto.Columns["KontoID"].Index].Value.ToString());
                    liste.Add(konto);
                }


                if (MessageBox.Show(dataGridViewKonto.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Konto.PerformClick();
                }
            }
            else if (entity == "Zeiterfassung")
            {
                foreach (DataGridViewRow selRow in dataGridViewZeiterfassung.SelectedRows)
                {
                    Zeiterfassung zeiterfassung = new Zeiterfassung();
                    zeiterfassung.ZeiterfassungID = Convert.ToInt32(dataGridViewZeiterfassung.Rows[selRow.Index].Cells[dataGridViewZeiterfassung.Columns["ZeiterfassungID"].Index].Value.ToString());
                    liste.Add(zeiterfassung);
                }


                if (MessageBox.Show(dataGridViewZeiterfassung.SelectedRows.Count + " Datensätze werden unwiderruflich gelöscht!\n", "Datensätze löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    myRequest.delete(liste, entity);
                    Zeiterfassung.PerformClick();
                }
            }
        }

        //------------------------------------------------------------------------delete functions END----------------------------------------------------//
    }
}
