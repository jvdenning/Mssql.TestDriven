using System;
using Smo = Microsoft.SqlServer.Management.Smo;
using SqlTestDriven.Contracts;
using SqlTestDriven.Model;

namespace SqlTestDriven
{
    public static class GetActualObjectExtensions
    {
        internal static Smo.Table GetActualTable(this Table table)
        {
            if (table.ServerObject == null)
            {
                var database = table.Parent as Database;
                var databaseObject = database.GetActualDatabase();
                var schema = table.Schema.GetActualSchema();
                var tableObject = databaseObject.Tables[table.Name, schema.Name];
               
                if (tableObject.State != Smo.SqlSmoState.Existing)
                {
                    return null;
                }
                
                table.ServerObject = tableObject;
            }

            return table.ServerObject;
        }


        internal static Smo.Schema GetActualSchema(this Schema schema)
        {
            if (schema.ServerObject == null)
            {
                var database = schema.Database.GetActualDatabase();
                schema.ServerObject = database.Schemas[schema.Name];
            }
            return schema.ServerObject;
        }

        internal static Smo.Column GetActualColumn(this Column column)
        {
            if (column.ServerObject == null)
            {
                var table = column.TheTable as Table;
                var tableObject = table.GetActualTable();
                var columnObject =tableObject.Columns[column.Name];
                if (columnObject.State != Smo.SqlSmoState.Existing)
                {
                    return null;
                }

                column.ServerObject = columnObject;

            }

            return column.ServerObject;
        }

        internal static Smo.Database GetActualDatabase(this IDatabaseAssertable databaseAssertable)
        {
            if(databaseAssertable is Schema)
            { 
                var schema = databaseAssertable as Schema;
                var actualSchema = schema.GetActualSchema();
                return actualSchema.Parent;
            }

            var database = databaseAssertable as Database;
            if (database == null)
            {
                throw new InvalidOperationException("Object not a database");//TODO: make message more obvious
            }
            return database.GetActualDatabase();
        }

        internal static Smo.Database GetActualDatabase(this Database database)
        {
            if (database.ServerObject == null)
            {
                var server = GetSqlServerObject(Configuration.Current.ServerName, database.Name);

                database.ServerObject = server.Databases[database.Name];
            }
            return database.ServerObject;
        }

        private static Smo.Server GetSqlServerObject(string serverName, string databaseName)
        {
            var sqlServer = new Smo.Server(serverName);

            sqlServer.ConnectionContext.DatabaseName = databaseName;
            sqlServer.ConnectionContext.LoginSecure = true;
            sqlServer.ConnectionContext.Connect();
            return sqlServer;
        } 
    }
}