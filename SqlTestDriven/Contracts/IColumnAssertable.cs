using Microsoft.SqlServer.Management.Smo;
using SqlTestDriven.Model;
using Column = SqlTestDriven.Model.Column;

namespace SqlTestDriven.Contracts
{
    public interface IColumnAssertable : IAssertable
    {
        ITableAssertable TheTable { get; }
    }

    public static class ColumnExtensions
    {
        public static IAnd<IColumnAssertable> ShouldBeOfType(this IColumnAssertable columnAssertable, SqlDataType dbType)
        {
            var column = columnAssertable as Column;
            column.DataType = dbType;
            return new Andable<IColumnAssertable>(column);
        }

        
    }
}