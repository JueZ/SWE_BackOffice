using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IPlugin;
using WebServer;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Data;

namespace backofficePlugin
{
    class BL
    {
        DAL myDAL;
        Fake_DAL fakeDal;
        public List<EntityInterface> check(string _sqlSelect, string from, int useFake = 0)
        {
            if (useFake == 0)
            {
                myDAL = new DAL();
                return myDAL.sql(_sqlSelect, from);
            }
            else
            {
                fakeDal = new Fake_DAL();
                return fakeDal.sql(_sqlSelect, from);
            }
            
        }
        public string update(List<EntityInterface> liste, string from, int useFake = 0)
        {
            myDAL = new DAL();

            return myDAL.update(liste, from);
        }
        public string add(List<EntityInterface> liste, string from, int useFake = 0)
        {
            myDAL = new DAL();

            return myDAL.add(liste, from);
        }
        public string delete(List<EntityInterface> liste, string from, int useFake = 0)
        {
            myDAL = new DAL();

            return myDAL.delete(liste, from);
        }
    }
}
