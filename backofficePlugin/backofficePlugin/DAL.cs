using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;



namespace backofficePlugin
{
    public class DAL
    {
        private SqlConnection sqlCon = new SqlConnection(@"Server=server.xios.at;Database=EPU;User Id=jakob; Password=h1EQSDg3idYd;");
        public List<EntityInterface> sql(string _sqlSELECT, string from)
        {

            List<EntityInterface> liste = new List<EntityInterface>();

            try
            {

                string sqlQuery = "";
                if (_sqlSELECT == "none")
                    switch (from)
                    {
                        case "Kunde":
                            sqlQuery = "SELECT * FROM dbo." + from;
                            break;
                        case "Kontakt":
                            sqlQuery = "SELECT * FROM dbo." + from;
                            break;
                        case "Angebot":
                            sqlQuery = "SELECT AngebotID, FK_ProjektID, FK_KundeID, Angebotsname, Angebotssumme, Nachname, Dauer, Datum, UmsetzungsChance FROM " + from + " JOIN dbo.Kunde ON FK_KundeID = KundeID";
                            break;
                        case "Projekt":
                            sqlQuery = "SELECT ProjektID, Name, Nachname AS Kunde, Projekt.Datum, Projekt.Dauer, SUM(Angebotssumme) AS Wert FROM dbo." + from + " JOIN Angebot ON ProjektID = FK_ProjektID JOIN Kunde ON FK_KundeID = KundeID GROUP BY ProjektID, Name, Nachname, Projekt.Datum, Projekt.Dauer";
                            break;
                        case "Ausgangsrechnung":
                            sqlQuery = "SELECT AusgangsrechnungID, Name AS Projekt, Nachname AS Kunde, Projekt.Datum, SUM(Angebotssumme) AS Summe, Bezahlt FROM " + from + " JOIN Projekt ON AusgangsrechnungID = ProjektID JOIN dbo.Angebot ON ProjektID = FK_ProjektID JOIN Kunde ON FK_KundeID = KundeID GROUP BY AusgangsrechnungID, Name, Nachname, Projekt.Datum, Bezahlt";
                            break;
                        case "Eingangsrechnung":
                            sqlQuery = "SELECT EingangsrechnungID, FK_KontaktID, Firma, Beschreibung, Datum, Summe, Bezahlt FROM " + from + " JOIN Kontakt ON FK_KontaktID = KontaktID GROUP BY EingangsrechnungID, FK_KontaktID, Firma, Beschreibung, Datum, Summe, Bezahlt";
                            break;
                        case "Konto":
                            sqlQuery = "SELECT BuchungszeileID, Name AS Beschreibung, Projekt.Datum, SUM(Angebotssumme) AS Summe FROM " + from + " JOIN Ausgangsrechnung ON Konto.FK_AusgangsrechnungID = AusgangsrechnungID JOIN Projekt ON Konto.FK_AusgangsrechnungID = ProjektID JOIN Angebot ON Konto.FK_AusgangsrechnungID = Angebot.FK_ProjektID GROUP BY BuchungszeileID, Name, Projekt.Datum UNION SELECT BuchungszeileID, Beschreibung, Eingangsrechnung.Datum, Summe*-1 AS Summe FROM " + from + " JOIN Eingangsrechnung ON FK_EingangsrechnungID = EingangsrechnungID GROUP BY BuchungszeileID, Beschreibung, Eingangsrechnung.Datum, Summe";
                            break;
                    }
                else
                {
                    switch (from)
                    {
                        case "Kunde":
                            sqlQuery = "SELECT * from dbo." + from + " WHERE Firma like @param or Vorname like @param or Nachname like @param or Land like @param or Strasse like @param";
                            break;
                        case "Kontakt":
                            sqlQuery = "SELECT * from dbo." + from + " WHERE Firma like @param or Vorname like @param or Nachname like @param or Land like @param or Strasse like @param";
                            break;
                        case "Angebot":
                            sqlQuery = "SELECT AngebotID, FK_ProjektID, FK_KundeID, Angebotsname, Angebotssumme, Nachname, Dauer, Datum, UmsetzungsChance FROM " + from + " JOIN dbo.Kunde ON FK_KundeID = KundeID WHERE Angebotsname LIKE @param OR Nachname LIKE @param";
                            break;
                        case "Projekt":
                            sqlQuery = "SELECT ProjektID, Name, Nachname AS Kunde, Projekt.Datum, Projekt.Dauer, SUM(Angebotssumme) AS Wert FROM dbo." + from + " JOIN Angebot ON ProjektID = FK_ProjektID JOIN Kunde ON FK_KundeID = KundeID WHERE Name LIKE @param OR Nachname LIKE @param GROUP BY ProjektID, Name, Nachname, Projekt.Datum, Projekt.Dauer";
                            break;
                        case "Ausgangsrechnung":
                            sqlQuery = "SELECT AusgangsrechnungID, Name AS Projekt, Nachname AS Kunde, Projekt.Datum, SUM(Angebotssumme) AS Summe, Bezahlt FROM " + from + " JOIN Projekt ON AusgangsrechnungID = ProjektID JOIN dbo.Angebot ON ProjektID = FK_ProjektID JOIN Kunde ON FK_KundeID = KundeID WHERE Name LIKE @param OR Nachname LIKE @param GROUP BY AusgangsrechnungID, Name, Nachname, Projekt.Datum, Bezahlt";
                            break;
                        case "Eingangsrechnung":
                            sqlQuery = "SELECT EingangsrechnungID, FK_KontaktID, Firma, Beschreibung, Datum, Summe, Bezahlt FROM " + from + " JOIN Kontakt ON FK_KontaktID = KontaktID WHERE Firma LIKE @param OR Beschreibung LIKE @param GROUP BY EingangsrechnungID, FK_KontaktID, Firma, Beschreibung, Datum, Summe, Bezahlt";
                            break;
                        case "Konto":
                            sqlQuery = "SELECT BuchungszeileID, Name AS Beschreibung, Projekt.Datum, SUM(Angebotssumme) AS Summe FROM " + from + " JOIN Ausgangsrechnung ON Konto.FK_AusgangsrechnungID = AusgangsrechnungID JOIN Projekt ON Konto.FK_AusgangsrechnungID = ProjektID JOIN Angebot ON Konto.FK_AusgangsrechnungID = Angebot.FK_ProjektID WHERE Name LIKE @param GROUP BY BuchungszeileID, Name, Projekt.Datum UNION SELECT BuchungszeileID, Beschreibung, Eingangsrechnung.Datum, Summe*-1 AS Summe FROM " + from + " JOIN Eingangsrechnung ON FK_EingangsrechnungID = EingangsrechnungID WHERE Beschreibung LIKE @param GROUP BY BuchungszeileID, Beschreibung, Eingangsrechnung.Datum, Summe";
                            break;
                    }
                    
                }

                SqlCommand command = new SqlCommand(sqlQuery, sqlCon);
                command.Parameters.AddWithValue("@param",  _sqlSELECT);
                //command.Parameters.AddWithValue("@from", from);
                Console.WriteLine(_sqlSELECT);

                sqlCon.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);


                switch (from)
                {
                    case "Kunde":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Kunde k = new Kunde();

                            k.KundeID = Convert.ToInt32(reihe["KundeID"]);
                            k.Firma = Convert.ToString(reihe["Firma"]);
                            k.Anrede = Convert.ToString(reihe["Anrede"]);
                            k.Vorname = Convert.ToString(reihe["Vorname"]);
                            k.Nachname = Convert.ToString(reihe["Nachname"]);
                            k.Firmenbuchnummer = Convert.ToString(reihe["Firmenbuchnummer"]);
                            k.UID = Convert.ToString(reihe["UID"]);
                            k.Telefonnummer = Convert.ToString(reihe["Telefonnummer"]);
                            k.Land = Convert.ToString(reihe["Land"]);
                            k.PLZ = Convert.ToString(reihe["PLZ"]);
                            k.Strasse = Convert.ToString(reihe["Strasse"]);
                            k.HNr = Convert.ToString(reihe["HNr"]);
                            k.Kontonummer = Convert.ToString(reihe["Kontonummer"]);
                            k.BLZ = Convert.ToString(reihe["BLZ"]);
                            k.IBAN = Convert.ToString(reihe["IBAN"]);
                            k.BIC = Convert.ToString(reihe["BIC"]);
                            liste.Add(k);
                        }
                        break;
                    case "Kontakt":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Kontakt k = new Kontakt();

                            k.KontaktID = Convert.ToInt32(reihe["KontaktID"]);
                            k.Firma = Convert.ToString(reihe["Firma"]);
                            k.Anrede = Convert.ToString(reihe["Anrede"]);
                            k.Vorname = Convert.ToString(reihe["Vorname"]);
                            k.Nachname = Convert.ToString(reihe["Nachname"]);
                            k.Firmenbuchnummer = Convert.ToString(reihe["Firmenbuchnummer"]);
                            k.UID = Convert.ToString(reihe["UID"]);
                            k.Telefonnummer = Convert.ToString(reihe["Telefonnummer"]);
                            k.Land = Convert.ToString(reihe["Land"]);
                            k.PLZ = Convert.ToString(reihe["PLZ"]);
                            k.Strasse = Convert.ToString(reihe["Strasse"]);
                            k.HNr = Convert.ToString(reihe["HNr"]);
                            k.Kontonummer = Convert.ToString(reihe["Kontonummer"]);
                            k.BLZ = Convert.ToString(reihe["BLZ"]);
                            k.IBAN = Convert.ToString(reihe["IBAN"]);
                            k.BIC = Convert.ToString(reihe["BIC"]);
                            liste.Add(k);
                        }
                        break;
                    case "Angebot":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Angebot k = new Angebot();
                            k.AngebotID = Convert.ToInt32(reihe["AngebotID"]);
                            k.FK_ProjektID = Convert.ToInt32(reihe["FK_ProjektID"]);
                            k.FK_KundeID = Convert.ToInt32(reihe["FK_KundeID"]);
                            k.Angebotsname = Convert.ToString(reihe["Angebotsname"]);
                            k.Angebotssumme = float.Parse(Convert.ToString(reihe["Angebotssumme"]));
                            k.Dauer = Convert.ToInt32(reihe["Dauer"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.UmsetzungsChance = Convert.ToInt32(reihe["UmsetzungsChance"]);
                            
                            liste.Add(k);
                        }
                        break;
                    case "Projekt":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Projekt k = new Projekt();

                            k.ProjektID = Convert.ToInt32(reihe["ProjektID"]);
                            k.Name = Convert.ToString(reihe["Name"]);
                            k.Kunde = Convert.ToString(reihe["Kunde"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Dauer = float.Parse(Convert.ToString(reihe["Dauer"]));
                            k.Wert = float.Parse(Convert.ToString(reihe["Wert"]));
                            liste.Add(k);
                        }
                        break;
                    case "Ausgangsrechnung":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Ausgangsrechnung k = new Ausgangsrechnung();

                            k.AusgangsrechnungID = Convert.ToInt32(reihe["AusgangsrechnungID"]);
                            k.Projekt = Convert.ToString(reihe["Projekt"]);
                            k.Kunde = Convert.ToString(reihe["Kunde"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Summe = float.Parse(Convert.ToString(reihe["Summe"]));
                            k.Bezahlt = Convert.ToString(reihe["Bezahlt"]);
                            liste.Add(k);
                        }
                        break;
                    case "Eingangsrechnung":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Eingangsrechnung k = new Eingangsrechnung();

                            k.EingangsrechnungID = Convert.ToInt32(reihe["EingangsrechnungID"]);
                            k.FK_KontaktID = Convert.ToInt32(reihe["FK_KontaktID"]);
                            k.Firma = Convert.ToString(reihe["Firma"]);
                            k.Beschreibung = Convert.ToString(reihe["Beschreibung"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Summe = float.Parse(Convert.ToString(reihe["Summe"]));
                            k.Bezahlt = Convert.ToString(reihe["Bezahlt"]);
                            liste.Add(k);
                        }
                        break;
                    case "Konto":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Konto k = new Konto();

                            k.BuchungszeileID = Convert.ToInt32(reihe["BuchungszeileID"]);
                            k.Beschreibung = Convert.ToString(reihe["Beschreibung"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Summe = float.Parse(Convert.ToString(reihe["Summe"]));
                            liste.Add(k);
                        }
                        break;
  
                }


                return liste;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception();
            }
        }

        public string update(List<EntityInterface> liste, string from)
        {
            
            string sqlQuery = string.Empty;
            int x = 0;
        
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                switch(from){
                    case "Kunde":
                        foreach (Kunde k in liste)
                        {
                            sqlQuery = "UPDATE dbo.Kunde SET ";
                            sqlQuery += "Firma = '" + k.Firma.ToString() + "',";
                            sqlQuery += "Anrede = '" + k.Anrede.ToString() + "',";
                            sqlQuery += "Vorname = '" + k.Vorname.ToString() + "',";
                            sqlQuery += "Nachname = '" + k.Nachname.ToString() + "',";
                            sqlQuery += "Firmenbuchnummer = '" + k.Firmenbuchnummer.ToString() + "',";
                            sqlQuery += "UID = '" + k.UID.ToString() + "',";
                            sqlQuery += "Telefonnummer = '" + k.Telefonnummer.ToString() + "',";
                            sqlQuery += "Land = '" + k.Land.ToString() + "',";
                            sqlQuery += "PLZ = '" + k.PLZ.ToString() + "',";
                            sqlQuery += "Strasse = '" + k.Strasse.ToString() + "',";
                            sqlQuery += "HNr = '" + k.HNr.ToString() + "',";
                            sqlQuery += "Kontonummer = '" + k.Kontonummer.ToString() + "',";
                            sqlQuery += "BLZ = '" + k.BLZ.ToString() + "',";
                            sqlQuery += "IBAN = '" + k.IBAN.ToString() + "',";
                            sqlQuery += "BIC = '" + k.BIC.ToString() + "'";
                            sqlQuery += "WHERE KundeID = '" + k.KundeID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();
                        }
                        
                        break;
                    case "Kontakt":
                        foreach (Kontakt k in liste)
                        {
                            sqlQuery = "UPDATE dbo.Kontakt SET ";
                            sqlQuery += "Firma = '" + k.Firma.ToString() + "',";
                            sqlQuery += "Anrede = '" + k.Anrede.ToString() + "',";
                            sqlQuery += "Vorname = '" + k.Vorname.ToString() + "',";
                            sqlQuery += "Nachname = '" + k.Nachname.ToString() + "',";
                            sqlQuery += "Firmenbuchnummer = '" + k.Firmenbuchnummer.ToString() + "',";
                            sqlQuery += "UID = '" + k.UID.ToString() + "',";
                            sqlQuery += "Telefonnummer = '" + k.Telefonnummer.ToString() + "',";
                            sqlQuery += "Land = '" + k.Land.ToString() + "',";
                            sqlQuery += "PLZ = '" + k.PLZ.ToString() + "',";
                            sqlQuery += "Strasse = '" + k.Strasse.ToString() + "',";
                            sqlQuery += "HNr = '" + k.HNr.ToString() + "',";
                            sqlQuery += "Kontonummer = '" + k.Kontonummer.ToString() + "',";
                            sqlQuery += "BLZ = '" + k.BLZ.ToString() + "',";
                            sqlQuery += "IBAN = '" + k.IBAN.ToString() + "',";
                            sqlQuery += "BIC = '" + k.BIC.ToString() + "'";
                            sqlQuery += "WHERE KontaktID = '" + k.KontaktID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();
                        }
                        
                        break;
                    case "Angebot":
                        foreach (Angebot a in liste)
                        {
                            sqlQuery = "UPDATE dbo.Angebot SET ";
                            sqlQuery += "FK_ProjektID = '" + a.FK_ProjektID.ToString() + "',";
                            sqlQuery += "FK_KundeID = '" + a.FK_KundeID.ToString() + "',";
                            sqlQuery += "Angebotsname = '" + a.Angebotsname.ToString() + "',";
                            sqlQuery += "Angebotssumme = '" + a.Angebotssumme.ToString() + "',";
                            sqlQuery += "Dauer = '" + a.Dauer.ToString() + "',";
                            sqlQuery += "Datum = '" + a.Datum.ToString() + "',";
                            sqlQuery += "UmsetzungsChance = '" + a.UmsetzungsChance.ToString() + "'";
                            sqlQuery += "WHERE AngebotID = '" + a.AngebotID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();
                        }
                        
                        break;
                    case "Projekt":
                        foreach (Projekt a in liste)
                        {
                            sqlQuery = "UPDATE dbo.Projekt SET ";
                            sqlQuery += "Name = '" + a.Name.ToString() + "',";
                            sqlQuery += "Dauer = '" + a.Dauer.ToString() + "',";
                            sqlQuery += "Datum = '" + a.Datum.ToString() + "'";
                            sqlQuery += "WHERE ProjektID = '" + a.ProjektID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();
                        }

                        break;
                    case "Ausgangsrechnung":
                        foreach (Ausgangsrechnung a in liste)
                        {
                            sqlQuery = "UPDATE dbo.Ausgangsrechnung SET ";
                            sqlQuery += "Bezahlt = '" + a.Bezahlt.ToString() + "'";
                            sqlQuery += "WHERE AusgangsrechnungID = '" + a.AusgangsrechnungID.ToString() + "';";
                            
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();

                            if (a.Bezahlt.ToString() == "ja")
                            {
                                sqlQuery = "SELECT FK_AusgangsrechnungID FROM Konto WHERE FK_AusgangsrechnungID = '" + a.AusgangsrechnungID.ToString() + "'";

                                SqlCommand command = new SqlCommand(sqlQuery, sqlCon);

                                SqlDataReader reader = command.ExecuteReader();
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                int FK_AusgangsrechnungID = 0;

                                foreach (DataRow reihe in dataTable.Rows)
                                {
                                    FK_AusgangsrechnungID = Convert.ToInt32(reihe["FK_AusgangsrechnungID"]);
                                }

                                if (FK_AusgangsrechnungID != a.AusgangsrechnungID)
                                {
                                    sqlQuery = "INSERT INTO dbo.Konto ";
                                    sqlQuery += "([FK_AusgangsrechnungID]) VALUES ('" + a.AusgangsrechnungID.ToString() + "')";

                                    sqlCmd.CommandText = sqlQuery;
                                    x += sqlCmd.ExecuteNonQuery(); 
                                }                           
                            }
                            else
                            {
                                sqlQuery = "DELETE FROM dbo.Konto ";
                                sqlQuery += "WHERE FK_AusgangsrechnungID = '" + a.AusgangsrechnungID.ToString() + "';";

                                sqlCmd.CommandText = sqlQuery;
                                x += sqlCmd.ExecuteNonQuery();
                            }
                        }
                        break;

                    case "Eingangsrechnung":
                        foreach (Eingangsrechnung a in liste)
                        {
                            sqlQuery = "UPDATE dbo.Eingangsrechnung SET ";
                            sqlQuery += "FK_KontaktID = '" + a.FK_KontaktID.ToString() + "',";
                            sqlQuery += "Beschreibung = '" + a.Beschreibung.ToString() + "',";
                            sqlQuery += "Datum = '" + a.Datum.ToString() + "',";
                            sqlQuery += "Summe = '" + a.Summe.ToString() + "',";
                            sqlQuery += "Bezahlt = '" + a.Bezahlt.ToString() + "'";
                            sqlQuery += "WHERE EingangsrechnungID = '" + a.EingangsrechnungID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            x += sqlCmd.ExecuteNonQuery();

                            if (a.Bezahlt.ToString() == "ja")
                            {
                                sqlQuery = "SELECT FK_EingangsrechnungID FROM Konto WHERE FK_EingangsrechnungID = '" + a.EingangsrechnungID.ToString() + "'";

                                SqlCommand command = new SqlCommand(sqlQuery, sqlCon);

                                SqlDataReader reader = command.ExecuteReader();
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                int FK_EingangsrechnungID = 0;

                                foreach (DataRow reihe in dataTable.Rows)
                                {
                                    FK_EingangsrechnungID = Convert.ToInt32(reihe["FK_EingangsrechnungID"]);
                                }

                                if (FK_EingangsrechnungID != a.EingangsrechnungID)
                                {
                                    sqlQuery = "INSERT INTO dbo.Konto ";
                                    sqlQuery += "([FK_EingangsrechnungID]) VALUES ('" + a.EingangsrechnungID.ToString() + "')";

                                    sqlCmd.CommandText = sqlQuery;
                                    x += sqlCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                sqlQuery = "DELETE FROM dbo.Konto ";
                                sqlQuery += "WHERE FK_EingangsrechnungID = '" + a.EingangsrechnungID.ToString() + "';";

                                sqlCmd.CommandText = sqlQuery;
                                x += sqlCmd.ExecuteNonQuery();
                            }
                        }

                        break;



            }
                sqlCon.Close();

                if (x == 0)
                    return "Update fehlgeschlagen";

                else
                    return "Update erfolgreich";
                  

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception();
            }
            
        }


        public string add(List<EntityInterface> liste, string from)
        {

            string sqlQuery = string.Empty;
            int a = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                Console.WriteLine(from);
                switch(from)
                {
                    case "Kunde":
                                foreach (Kunde k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Kunde ";
                                    sqlQuery += "([Firma] ,[Anrede] ,[Vorname] ,[Nachname] ,[Firmenbuchnummer] ,[UID] ,[Telefonnummer] ,[Land] ,[PLZ] ,[Strasse] ,[HNr] ,[Kontonummer] ,[BLZ] ,[IBAN] ,[BIC]) VALUES (";
                                    sqlQuery += "'" + k.Firma.ToString() + "',";
                                    sqlQuery += "'" + k.Anrede.ToString() + "',";
                                    sqlQuery += "'" + k.Vorname.ToString() + "',";
                                    sqlQuery += "'" + k.Nachname.ToString() + "',";
                                    sqlQuery += "'" + k.Firmenbuchnummer.ToString() + "',";
                                    sqlQuery += "'" + k.UID.ToString() + "',";
                                    sqlQuery += "'" + k.Telefonnummer.ToString() + "',";
                                    sqlQuery += "'" + k.Land.ToString() + "',";
                                    sqlQuery += "'" + k.PLZ.ToString() + "',";
                                    sqlQuery += "'" + k.Strasse.ToString() + "',";
                                    sqlQuery += "'" + k.HNr.ToString() + "',";
                                    sqlQuery += "'" + k.Kontonummer.ToString() + "',";
                                    sqlQuery += "'" + k.BLZ.ToString() + "',";
                                    sqlQuery += "'" + k.IBAN.ToString() + "',";
                                    sqlQuery += "'" + k.BIC.ToString() + "')";
                    

                                    sqlCmd.CommandText = sqlQuery;
                                    a+= sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Kontakt":
                                foreach (Kontakt k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Kontakt ";
                                    sqlQuery += "([Firma] ,[Anrede] ,[Vorname] ,[Nachname] ,[Firmenbuchnummer] ,[UID] ,[Telefonnummer] ,[Land] ,[PLZ] ,[Strasse] ,[HNr] ,[Kontonummer] ,[BLZ] ,[IBAN] ,[BIC]) VALUES (";
                                    sqlQuery += "'" + k.Firma.ToString() + "',";
                                    sqlQuery += "'" + k.Anrede.ToString() + "',";
                                    sqlQuery += "'" + k.Vorname.ToString() + "',";
                                    sqlQuery += "'" + k.Nachname.ToString() + "',";
                                    sqlQuery += "'" + k.Firmenbuchnummer.ToString() + "',";
                                    sqlQuery += "'" + k.UID.ToString() + "',";
                                    sqlQuery += "'" + k.Telefonnummer.ToString() + "',";
                                    sqlQuery += "'" + k.Land.ToString() + "',";
                                    sqlQuery += "'" + k.PLZ.ToString() + "',";
                                    sqlQuery += "'" + k.Strasse.ToString() + "',";
                                    sqlQuery += "'" + k.HNr.ToString() + "',";
                                    sqlQuery += "'" + k.Kontonummer.ToString() + "',";
                                    sqlQuery += "'" + k.BLZ.ToString() + "',";
                                    sqlQuery += "'" + k.IBAN.ToString() + "',";
                                    sqlQuery += "'" + k.BIC.ToString() + "')";
                    

                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Angebot":
                                foreach (Angebot k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Angebot ";
                                    sqlQuery += "([FK_ProjektID] ,[FK_KundeID], [Angebotsname], [Angebotssumme], [Dauer], [Datum], [UmsetzungsChance]) VALUES (";
                                    sqlQuery += "'" + k.FK_ProjektID.ToString() + "', ";
                                    sqlQuery += "'" + k.FK_KundeID.ToString() + "', ";
                                    sqlQuery += "'" + k.Angebotsname.ToString() + "',";
                                    sqlQuery += "'" + k.Angebotssumme.ToString() + "',";
                                    sqlQuery += "'" + k.Dauer.ToString() + "',";
                                    sqlQuery += "'" + k.Datum.ToString() + "',";
                                    sqlQuery += "'" + k.UmsetzungsChance.ToString() + "')";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Projekt":
                                foreach (Projekt k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Projekt ";
                                    sqlQuery += "([Name], [Datum]) VALUES (";
                                    sqlQuery += "'" + k.Name.ToString() + "', ";
                                    sqlQuery += "'" + k.Datum.ToString() + "')";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();

                                    sqlQuery = "INSERT INTO dbo.Ausgangsrechnung ([AusgangsrechnungID]) VALUES ((SELECT TOP 1 ProjektID FROM dbo.Projekt ORDER BY ProjektID DESC))";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();

                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Eingangsrechnung":
                                foreach (Eingangsrechnung k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Eingangsrechnung ";
                                    sqlQuery += "([FK_KontaktID], [Summe], [Datum], [Beschreibung], [Bezahlt]) VALUES (";
                                    sqlQuery += "'" + k.FK_KontaktID.ToString() + "',";
                                    sqlQuery += "'" + k.Summe.ToString() + "',";
                                    sqlQuery += "'" + k.Datum.ToString() + "',";
                                    sqlQuery += "'" + k.Beschreibung.ToString() + "',";
                                    sqlQuery += "'" + k.Bezahlt.ToString() + "')";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();

                                    if (k.Bezahlt.ToString() == "ja")
                                    {
                                        sqlQuery = "INSERT INTO dbo.Konto ";
                                        sqlQuery += "([FK_EingangsrechnungID]) VALUES ((SELECT TOP 1 EingangsrechnungID FROM dbo.Eingangsrechnung ORDER BY EingangsrechnungID DESC))";
                                    }

                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;

            }
                sqlCon.Close();

                if (a == 0)
                    return "ERROR";                
                else
                    return from + " erfolgreich hinzugefügt.";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception();
            }

        }

        public string delete(List<EntityInterface> liste, string from)
        {

            string sqlQuery = string.Empty;
            int a = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                switch (from)
                {
                    case "Kunde":
                        foreach (Kunde k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Kunde ";
                            sqlQuery += "WHERE KundeID = '" + k.KundeID.ToString() + "';";


                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;
                    case "Kontakt":
                        foreach (Kontakt k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Kontakt ";
                            sqlQuery += "WHERE KontaktID = '" + k.KontaktID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;
                    case "Angebot":
                        foreach (Angebot k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Angebot ";
                            sqlQuery += "WHERE AngebotID = '" + k.AngebotID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;                    
                    case "Projekt":
                        foreach (Projekt k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Projekt ";
                            sqlQuery += "WHERE ProjektID = '" + k.ProjektID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                         }
                        break;
                }
                sqlCon.Close();

                if (a == 0)
                    return "Die Operation ist fehlgeschlagen";
                else
                    return "Datensätze erfolgreich gelöscht";
                    


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception();
            }


        }

    }
}
