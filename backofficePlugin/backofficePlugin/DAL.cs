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
    class DAL
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
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Kontakt":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Angebot":
                            sqlQuery = "SELECT AngebotID, FK_ProjektID, FK_KundeID, FK_AusgangsrechnungID, Angebotsname, Angebotssumme, Kunde, Dauer, Datum, UmsetzungsChance FROM dbo." + from + "JOIN dbo.Kunde ON (Kunde.FK_KundeID = Kunde.KundeID)";
                            break;
                        case "Projekt":
                            sqlQuery = "SELECT * from dbo." + from + " where Name like @param";
                            break;
                        case "Ausgangsrechnung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Eingangsrechnung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Konto":
                            sqlQuery = "SELECT * from dbo." + from + "where Name @param";
                            break;
                        case "Zeiterfassung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                    }
                else
                {
                    switch (from)
                    {
                        case "Kunde":
                            sqlQuery = "SELECT * from dbo." + from + " where Firma like @param or Vorname like @param or Nachname like @param or Land like @param or Strasse like @param";
                            break;
                        case "Kontakt":
                            sqlQuery = "SELECT * from dbo." + from + " where Firma like @param or Vorname like @param or Nachname like @param or Land like @param or Strasse like @param";
                            break;
                        case "Angebot":
                            sqlQuery = "SELECT * FROM dbo.Angebot JOIN dbo.Projekt ON (Angebot.FK_ProjektID = Projekt.ProjektID) WHERE Angebotsname LIKE @param";
                            break;
                        case "Projekt":
                            sqlQuery = "SELECT * from dbo." + from + " where Name like @param";
                            break;
                        case "Ausgangsrechnung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Eingangsrechnung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                        case "Konto":
                            sqlQuery = "SELECT * from dbo." + from + "where Name @param";
                            break;
                        case "Zeiterfassung":
                            sqlQuery = "SELECT * from dbo." + from;
                            break;
                    }
                    
                }

                SqlCommand command = new SqlCommand(sqlQuery, sqlCon);
                command.Parameters.AddWithValue("@param",  _sqlSELECT);
                //command.Parameters.AddWithValue("@from", from);

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
                            k.FK_AusgangsrechnungID = Convert.ToInt32(reihe["FK_AusgangsrechnungID"]);
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
                            k.FK_ProjektID = Convert.ToInt32(reihe["FK_ProjektID"]);
                            k.Projekt = Convert.ToString(reihe["Projekt"]);
                            k.Kunde = Convert.ToString(reihe["Kunde"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Summe = float.Parse(Convert.ToString(reihe["Summe"]));
                            k.Bezahlt = Convert.ToBoolean(reihe["Bezahlt"]);
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
                            k.Bezahlt = Convert.ToBoolean(reihe["Bezahlt"]);
                            liste.Add(k);
                        }
                        break;
                    case "Konto":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Konto k = new Konto();

                            k.BuchungszeileID = Convert.ToInt32(reihe["BuchungszeileID"]);
                            k.FK_AusgangsrechnungID = Convert.ToInt32(reihe["FK_AusgangsrechnungID"]);
                            k.FK_EingangsrechnungID = Convert.ToInt32(reihe["FK_EingangsrechnungID"]);
                            k.Projekt = Convert.ToString(reihe["Projekt"]);
                            k.Beschreibung = Convert.ToString(reihe["Beschreibung"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Summe = Convert.ToInt32(reihe["Summe"]);
                            liste.Add(k);
                        }
                        break;
                    case "Zeiterfassung":
                        foreach (DataRow reihe in dataTable.Rows)
                        {
                            Zeiterfassung k = new Zeiterfassung();

                            k.ZeiterfassungID = Convert.ToInt32(reihe["ZeiterfassungID"]);
                            k.ProjektID = Convert.ToInt32(reihe["ProjektID"]);
                            k.Vorname = Convert.ToString(reihe["Vorname"]);
                            k.Nachname = Convert.ToString(reihe["Nachname"]);
                            k.Datum = Convert.ToDateTime(reihe["Datum"]);
                            k.Stunden = Convert.ToInt32(reihe["Stunden"]);
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
                            sqlQuery += "Name = '" + a.Name.ToString() + "'";
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
                            Console.WriteLine(sqlQuery);
                            x += sqlCmd.ExecuteNonQuery();
                           
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
                            sqlQuery += "Bezahlt = '" + a.Bezahlt.ToString() + "',";
                            sqlQuery += "WHERE EingangsrechnungID = '" + a.EingangsrechnungID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            Console.WriteLine(sqlQuery);
                            x += sqlCmd.ExecuteNonQuery();

                        }

                        break;


                    case "Zeiterfassung":
                        foreach (Zeiterfassung a in liste)
                        {
                            sqlQuery = "UPDATE dbo.Zeiterfassung SET ";
                            sqlQuery += "ProjektID = '" + a.ProjektID.ToString() + "',";
                            sqlQuery += "Vorname = '" + a.Vorname.ToString() + "',";
                            sqlQuery += "Nachname = '" + a.Nachname.ToString() + "',";
                            sqlQuery += "Datum = '" + a.Datum.ToString() + "',";
                            sqlQuery += "Stunden = '" + a.Stunden.ToString() + "'";
                            sqlQuery += "WHERE ZeiterfassungID = '" + a.ZeiterfassungID.ToString() + "';";
                            sqlCmd.CommandText = sqlQuery;
                            Console.WriteLine(sqlQuery);
                            x += sqlCmd.ExecuteNonQuery();

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
                                    sqlQuery += "([FK_ProjektID] ,[FK_KundeID], [FK_AusgangsrechnungID], [Angebotsname], [Angebotssumme], [Dauer], [Datum], [UmsetzungsChance]) VALUES (";
                                    sqlQuery += "'" + k.FK_ProjektID.ToString() + "',";
                                    sqlQuery += "'" + k.FK_KundeID.ToString() + "',";
                                    sqlQuery += "'" + k.FK_AusgangsrechnungID.ToString() + "',";
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
                                    sqlQuery = "INSERT INTO dbo.Projekt VALUES (";
                                    sqlQuery += "'" + k.Name.ToString() + "')";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }

                                foreach (Ausgangsrechnung k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Ausgangsrechnung ";
                                    sqlQuery += "([FK_ProjektID]) VALUES ((SELECT TOP 1 ProjektID FROM dbo.Projekt ORDER BY ProjektID DESC))";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }

                                foreach (Konto k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Konto ";
                                    sqlQuery += "([FK_Ausgangsrechnung]) VALUES ((SELECT TOP 1 AusgangsrechnungID FROM dbo.Ausgangsrechnung ORDER BY AusgangsrechnungID DESC))";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Eingangsrechnung":
                                foreach (Eingangsrechnung k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Eingangsrechnung ";
                                    sqlQuery = "([FK_Kontakt_ID], [Summe], [Datum], [Beschreibung]) VALUES (";
                                    sqlQuery += "'" + k.FK_KontaktID.ToString() + "',";
                                    sqlQuery += "'" + k.Summe.ToString() + "',";
                                    sqlQuery += "'" + k.Datum.ToString() + "',";
                                    sqlQuery += "'" + k.Beschreibung.ToString() + "')";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }

                                foreach (Konto k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Konto ";
                                    sqlQuery += "([FK_Eingangsrechnung]) VALUES ((SELECT TOP 1 EingangsrechnungID FROM dbo.Eingangsrechnung ORDER BY EingangsrechnungID DESC))";


                                    sqlCmd.CommandText = sqlQuery;
                                    a += sqlCmd.ExecuteNonQuery();
                                }
                                break;
                    case "Zeiterfassung":
                                foreach (Zeiterfassung k in liste)
                                {
                                    sqlQuery = "INSERT INTO dbo.Zeiterfassung ";
                                    sqlQuery += "([ProjektID], [Vorname], [Nachname], [Datum], [Stunden]) VALUES (";
                                    sqlQuery += "'" + k.ProjektID.ToString() + "',";
                                    sqlQuery += "'" + k.Vorname.ToString() + "',";
                                    sqlQuery += "'" + k.Nachname.ToString() + "',";
                                    sqlQuery += "'" + k.Datum.ToString() + "',";
                                    sqlQuery += "'" + k.Stunden.ToString() + "')";


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
                    case "Ausgangsrechnung":
                        foreach (Ausgangsrechnung k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Ausgangsrechnung ";
                            sqlQuery += "WHERE AusgangsrechnungID = '" + k.AusgangsrechnungID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;
                    case "Eingangsrechnung":
                        foreach (Eingangsrechnung k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Eingangsrechnung ";
                            sqlQuery += "WHERE EingangsrechnungID = '" + k.EingangsrechnungID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;
                    case "Konto":
                        foreach (Konto k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Konto ";
                            sqlQuery += "WHERE KontoID = '" + k.BuchungszeileID.ToString() + "';";

                            sqlCmd.CommandText = sqlQuery;
                            a += sqlCmd.ExecuteNonQuery();
                        }
                        break;
                    case "Zeiterfassung":
                        foreach (Zeiterfassung k in liste)
                        {
                            sqlQuery = "DELETE FROM dbo.Zeiterfassung ";
                            sqlQuery += "WHERE ZeiterfassungID = '" + k.ZeiterfassungID.ToString() + "';";

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
