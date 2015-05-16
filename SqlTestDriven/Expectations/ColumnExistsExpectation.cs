using SqlTestDriven.Model;

namespace SqlTestDriven.Expectations
{
    internal class ColumnExistsExpectation : ObjectExistsExpectation<Column, Microsoft.SqlServer.Management.Smo.Column>
    {
        public ColumnExistsExpectation(Column assertable, string name) : base(assertable, name)
        {
            
        }

        internal override void AssertExpectation()
        {
            var column = Assertable.GetActualColumn();
            if (column == null)
            {
                var table = (Table) Assertable.TheTable;
                string msg = string.Format("Column {0} on table {1} not found", Assertable.Name, table.Name);
                Fail(msg);
            }
            else
            {
                var table = (Table) Assertable.TheTable;
                string msg = string.Format("Column {0} on table {1} exists", column.Name, table.Name);
                Succeed(msg);
            }
        }

        internal override bool Fatal
        {
            get {  return false; }
        }
    }
}