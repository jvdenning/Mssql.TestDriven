using SqlTestDriven.Contracts;
using SqlTestDriven.Model;

namespace SqlTestDriven
{
    public static class GivenTheDatabaseToTest
    {
        public static IWhich<IDatabaseAssertable> WhichHasASchemaCalled(string schemaName)
        {
            var database = new Database(Configuration.Current.DatabaseName);
            var schema = new Schema(schemaName, database);
            return new Whichable<IDatabaseAssertable>(database);
        }
    }


    public class Configuration
    {
        public static Configuration Current { get; set; }
        
        public string ServerName { get; set; }        
        public string DatabaseName { get; set; }

    }
}