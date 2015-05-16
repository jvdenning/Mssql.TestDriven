using System;
using SqlTestDriven.Contracts;
using SqlTestDriven.Expectations;
using Smo = Microsoft.SqlServer.Management.Smo;
namespace SqlTestDriven.Model
{
    public class Column : Assertable<Column, Smo.Column>, IColumnAssertable
    {
        private Column(string name)
        {
            Name = name;
        }



        public int ColumnPosition { get; set; }
    

        public override string TypeName
        {
            get { return "Column"; }
        }

        public ITableAssertable TheTable { get; internal set; }
        public Microsoft.SqlServer.Management.Smo.SqlDataType DataType { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public bool Nullable { get; set; }
        public ColumnDefault Default { get; set; }
      

        public static IWhich<IColumnAssertable> Called(string columnName)
        {
            return new Whichable<IColumnAssertable>(new Column(columnName));
        }

        internal override Database ResolveDatabase()
        {
            var table = TheTable as Table;
            if (table != null)
            {
                return table.Parent as Database;
            }
            throw new InvalidOperationException("Cannot resolve Database for Column");
        }

        internal override void BuildExpectations()
        {
            if (TheTable == null)
            {
                throw new InvalidOperationException("Column Table not set");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("Column Name not set");
            }

            Expectations.Add(new ColumnExistsExpectation(this, Name));
            Expectations.Add(new ColumnTypeExpectation(DataType, this));


        }
    }
}