using SqlTestDriven.Contracts;
using SqlTestDriven.Expectations;
using Smo = Microsoft.SqlServer.Management.Smo;

namespace SqlTestDriven.Model
{
    public class Schema : Assertable<Schema, Smo.Schema>, IDatabaseAssertable
    {
        public Schema(string name, Database database)
        {
            database.Schemas.Add(this);
            database.CurrentSchema = this;
            this.Database = database;
            Name = name;
        }

        public override string TypeName
        {
            get { return "Schema"; }
        }

        public IDatabaseAssertable Database { get; set; }


        internal override Database ResolveDatabase()
        {
            return Database as Database;;
        }

        internal override void BuildExpectations()
        {
            var schemaExpectation = new SchemaExistsExpectation(this, Name);
            this.Expectations.Add(schemaExpectation);

          
        }
    }

}