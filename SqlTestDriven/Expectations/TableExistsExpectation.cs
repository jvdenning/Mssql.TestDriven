using SqlTestDriven.Model;

namespace SqlTestDriven.Expectations
{
    internal class TableExistsExpectation : ObjectExistsExpectation<Table, Microsoft.SqlServer.Management.Smo.Table>
    {
        public TableExistsExpectation(Table assertable, string name)
            : base(assertable, name)
        {
            
        }

        internal override void AssertExpectation()
        {
            var table = Assertable.GetActualTable();
            if (table == null)
            {
                var database = Assertable.ResolveDatabase();
                string msg = string.Format("Table {0} in database {1} not found", Assertable.Name, database.Name);
                Fail(msg);
            }
            else
            {
                var database = Assertable.ResolveDatabase();
                string msg = string.Format("Table {0} in database {1} exists", table.Name, database.Name);
                Succeed(msg);
            }
        }

        internal override bool Fatal
        {
            get {  return true; }
        }
    }
}