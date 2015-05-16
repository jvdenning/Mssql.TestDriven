using System.Collections.Generic;
using System.Linq;
using SqlTestDriven.Contracts;
using SqlTestDriven.Expectations;
using Smo = Microsoft.SqlServer.Management.Smo;

namespace SqlTestDriven.Model
{
    public class Table : Assertable<Table, Smo.Table>, ITableAssertable
    {
        public Table(string tableName, Database database, Schema schema)
        {
            Name = tableName;
            Parent = database;
            this.Schema = schema;
            database.Tables.Add(this);
            Columns= new List<Column>();
        }

        internal override Database ResolveDatabase()
        {
            return this.Parent as Database;
        }

        internal override void BuildExpectations()
        {
            var tableExpectation = new TableExistsExpectation(this, Name);
            Columns.ForEach(c => c.BuildExpectations());
            tableExpectation.ChildExpectations.AddRange(Columns.SelectMany(c => c.Expectations));
            Expectations.Add(tableExpectation);
        }
      
        public List<Column> Columns { get; set; }

        public override string TypeName
        {
            get { return "Table"; }
        }

        public Schema Schema { get; set; }
    }
}