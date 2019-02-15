using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OleDb;
namespace Tests
{
    [TestClass]
    public class Global
    {
        [AssemblyInitialize]
        static public void AssInit(TestContext context)
        {
            try
            {
                CheckCanConnectToMSSQLDB();
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message);
            }
            try
            {
                CheckCanConnectToPGLDB();
            }
            catch (Exception ex)
            {
                Assert.Inconclusive($"{ex.Message}. Check {Fixtures.PGDBName} exists on loacal PG server.");
            }
        }
        static private void CheckCanConnectToMSSQLDB()
        {
            OleDbConnection conn = Fixtures.GetConnection(DBType.MSSQL);
            conn.Open();
            conn.Close();
        }
        static private void CheckCanConnectToPGLDB()
        {
            OleDbConnection conn = Fixtures.GetConnection(DBType.PG);
            conn.Open();
            conn.Close();
        }
    }
}
