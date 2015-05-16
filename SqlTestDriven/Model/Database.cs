using System;
using System.Collections.Generic;
using System.Linq;
using SqlTestDriven.Contracts;
using SqlTestDriven.Expectations;

namespace SqlTestDriven.Model
{
    public class Database : Assertable<Database, Microsoft.SqlServer.Management.Smo.Database>, IDatabaseAssertable
    {
        public Database(string name)
        {
            Name = name;
            Tables = new List<Table>();
            Schemas = new List<Schema>();
            Views = new List<View>();
        }

        public new IDbObject Parent { get { throw new InvalidOperationException(); } set { throw new InvalidOperationException(); } }

        internal List<Table> Tables { get; set; }
        internal List<Schema> Schemas { get; set; }
        internal List<View> Views { get; set; }

        internal Schema CurrentSchema { get; set; }

        internal override Database ResolveDatabase()
        {
            return this;
        }
        
        internal override void BuildExpectations()
        {
            var dbExpectation = new DatabaseExistsExpectation(this, Name);
         
            Schemas.ForEach(s => s.BuildExpectations());
            dbExpectation.ChildExpectations.AddRange(Schemas.SelectMany(s => s.Expectations));
            Tables.ForEach(t => t.BuildExpectations());
            dbExpectation.ChildExpectations.AddRange(Tables.SelectMany(t => t.Expectations));
            Views.ForEach(v => v.BuildExpectations());
            dbExpectation.ChildExpectations.AddRange(Views.SelectMany(v => v.Expectations));
            Expectations.Add(dbExpectation);
        }

        public override string TypeName { get { return "Database"; } }
    }
}