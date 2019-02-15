using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Tests
{
    public class Fixtures
    {
        public static OleDbConnection GetConnection()
        {
            OleDbConnection conn = new OleDbConnection();
            return conn;
        }
        public static void CreateorUpdatePGDB()
        {
        }
        public static void CreateorUpdateMSSQLDB()
        {

        }

    }
}
