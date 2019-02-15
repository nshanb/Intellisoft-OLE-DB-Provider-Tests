# Intellisoft-OLE-DB-Provider-Tests
SSIS and C# test project

tests some bugs in PGNP-Postgres-SE-Trial-1.4.0.3542-x64.msi

MSSQL localdb
Postgres localhost

initial catalog: GITTest

BeforePackageRuns.InitPG => initializes Postgresql

BeforePackageRuns.InitMSSQL => initializes MSSQL


VarBinary.dtsx - tries to copy table1 => table1 (no errors, but bytea column is not copied)

VarBinaryFastLoad.dtsx - tries to copy table1 => table1 (crashes)

VarBinaryImage.dtsx - tries to copy table1 => table1 (no errors, copies bytea column)

VarBinaryImageFastLoad.dtsx - tries to copy table1 => table1 (Bulk Mode set to "Text Copy", crashes because of specific binary data)


AfterPackageRuns.TestMSSQL_CanRead_bytea - passes (it can read image data)

AfterPackageRuns.TestPG_CanRead_bytea - fails (it can not read a row with bytea data)

AfterPackageRuns.TestPGA_bytea_HasValue - fails (VarBinary.dtsx has copied the row without somekey column value)

AfterPackageRuns.TestPGA_bytea_HasValue_Image - fails (VarBinaryImage.dtsx (no bulk, fastload) has copied the row without somekey column value)

