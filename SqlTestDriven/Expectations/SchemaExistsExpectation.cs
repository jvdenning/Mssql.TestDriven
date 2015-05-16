using SqlTestDriven.Model;

namespace SqlTestDriven.Expectations
{
    internal class SchemaExistsExpectation : ObjectExistsExpectation<Schema, Microsoft.SqlServer.Management.Smo.Schema>
    {
        public SchemaExistsExpectation(Schema assertable, string name)
            : base(assertable, name)
        {
        }

        internal override void AssertExpectation()
        {
            var schemaObject = Assertable.GetActualSchema();
            if (schemaObject == null)
            {
                string msg = string.Format("Schema {0} not found", Assertable.Name);
                Fail(msg);
            }
            else
            {
                string msg = string.Format("Schema {0} found", Assertable.Name);
                Succeed(msg);
            }
        }

        internal override bool Fatal
        {
            get { return false; }
        }
    }
}