using SqlTestDriven.Contracts;
using Smo = Microsoft.SqlServer.Management.Smo;

namespace SqlTestDriven.Model
{
    public class ColumnDefault : Assertable<ColumnDefault, Smo.DefaultConstraint>, ITableAssertable
    {
        internal  ColumnDefault(Column parentColumn)
        {
            ParentColumn = parentColumn;
        }
        public string DefaultValue { get; set; }
      
        public override string TypeName
        {
            get { return "Column Default"; }
        }

        public Column ParentColumn { get; private set; }
        internal override Database ResolveDatabase()
        {
            return ParentColumn.ResolveDatabase();
        }

        internal override void BuildExpectations()
        {
           
        }
    }
}