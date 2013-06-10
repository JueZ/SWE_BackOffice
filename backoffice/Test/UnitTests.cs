using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Xml;
using System.IO;
using backoffice;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TableTest()
        {
            DataSet result = new DataSet();
            XmlReader xRead = XmlReader.Create(new StringReader(new backoffice.proxy().request("", "Angebote")));

            result.ReadXml(xRead);
            
            Assert.AreEqual("Angebote", result.Tables[0].ToString());
        }

        [TestMethod]
        public void RequestFullTable()
        {
            DataSet result = new DataSet();
            XmlReader xRead = XmlReader.Create(new StringReader(new backoffice.proxy().request("", "Angebote")));

            result.ReadXml(xRead);

            Assert.AreNotEqual(1, result.Tables[0].Rows.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException))]
        public void ThrowException()
        {
            DataSet result = new DataSet();
            XmlReader xRead = XmlReader.Create(new StringReader(new backoffice.proxy().request("", "")));

            result.ReadXml(xRead);
        }

        [TestMethod]
        public void ShowData()
        {
            DataTable test = new DataTable();
            for (int i = 0; i <= 8; i++)
            {
                test.Columns.Add("test"+i);
            }
            DataRow row = test.NewRow();
            row["test1"] = "testitest";
            test.Rows.Add(row);
            GUI_Update GUI_new = new GUI_Update();
            GUI_new.ShowDataSet(test);
        }

        [TestMethod]
        public void TestMainFunction()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_main());
        }
    }
}
