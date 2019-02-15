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
        public static string MSSQLDBName = System.Configuration.ConfigurationManager.AppSettings.Get("MSSQLDBName");
        public static string PGDBName = System.Configuration.ConfigurationManager.AppSettings.Get("PGDBName");
        public static OleDbConnection GetConnection(DBType type)
        {
            string connString;
            string dbName;
            switch (type)
            {
                case DBType.MSSQL:
                    dbName =
                    connString = $"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={MSSQLDBName};Provider=SQLNCLI11.1;Integrated Security=SSPI;Auto Translate=False;";
                    break;
                case DBType.PG:
                    connString = $"Data Source=localhost;User ID=postgres;Initial Catalog={PGDBName};Provider=PGNP.1;Persist Security Info=True;Extended Properties=\"SSL = prefer; \";";
                    break;
                default:
                    throw new NotImplementedException();
            }
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;
        }
        //public static void CreateorUpdatePGDB()
        //{
        //}
        //public static void CreateorUpdateMSSQLDB()
        //{

        //}
    }
    public enum DBType
    {
        MSSQL,
        PG
    }
    public static class Constants
    {
        public const string CreateTable1SQL = @"
if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='table1')
Begin
    DROP TABLE dbo.table1
End
CREATE TABLE dbo.table1(
	Id int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(50) NULL,
	SomeKey varbinary(50) NULL,
CONSTRAINT [PK_table1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
);
";
        public const string CreateTableImageSQL = @"
if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tableimage')
Begin
    DROP TABLE dbo.tableimage
End
CREATE TABLE dbo.tableimage(
	Id int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(50) NULL,
	SomeKey IMAGE NULL,
CONSTRAINT [PK_tableimage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
);
";
        public const string CreateTable1PG = @"
Drop table if exists table1 CASCADE;

CREATE TABLE public.table1
(
    id integer,
    firstname character varying (128) NULL,
    somekey bytea NOT NULL
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.table1
    OWNER to postgres;
";
        public const string CreateTableimagePG = @"
Drop table if exists tableimage CASCADE;

CREATE TABLE public.tableimage
(
    id integer,
    firstname character varying (128) NULL,
    somekey bytea NOT NULL
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.tableimage
    OWNER to postgres;
";
        public const string CreateTableSimplePG = @"
Drop table if exists tablesimple CASCADE;

CREATE TABLE public.tablesimple
(
    id integer,
    firstname character varying (128) NULL
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.tablesimple
    OWNER to postgres;
";
    }
}
