using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public static class DatabaseExtensions
    {
        public static IWhichOrThen<ITableAssertable> HasATableCalled(this IDatabaseAssertable databaseAssertable, string tableName)
        {
            var database = (Database) databaseAssertable;
            
            var table = new Table(tableName, database, database.CurrentSchema);
            return new Whichable<ITableAssertable>(table);
        }
    }
}