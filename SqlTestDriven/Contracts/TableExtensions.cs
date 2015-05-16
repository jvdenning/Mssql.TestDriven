using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public static class TableExtensions
    {
        public static  IWhichAndable<ITableAssertable,IColumnAssertable> ShouldHaveA(this ITableAssertable tableAssertable, IColumnAssertable columnAssertable)
        {
            var table = (Table) tableAssertable;
            var column = (Column) columnAssertable;
            table.Columns.Add(column);
            column.TheTable = table;
            return new WhichAndable<ITableAssertable, IColumnAssertable>(table, column);
        }
    }
}