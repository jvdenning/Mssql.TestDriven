using SqlTestDriven.Model;

namespace SqlTestDriven.Expectations
{
    internal class DatabaseExistsExpectation : ObjectExistsExpectation<Database, Microsoft.SqlServer.Management.Smo.Database>
    {
        public DatabaseExistsExpectation(Database assertable, string name) : base(assertable, name)
        {
            
        }

        internal override void AssertExpectation()
        {
            var database = Assertable.GetActualDatabase();
            if (database == null)
            {
                string msg = string.Format("Database {0} not found", Assertable.Name);
                Fail(msg);
            }
            else
            {
                string msg = string.Format("Database {0} found", Assertable.Name);
                Succeed(msg);
            }
        }

        internal override bool Fatal
        {
            get {  return true; }
        }
    }
}