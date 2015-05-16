using System.Collections.Generic;
using SqlTestDriven.Contracts;
using SqlTestDriven.Model;
using Smo =Microsoft.SqlServer.Management.Smo; 

namespace SqlTestDriven
{
    public class Index : Assertable<Index, Smo.Index>, ITableAssertable
    {
        public Table ParentTable { get; set; }
        public Dictionary<int, Column> Columns { get; set; }
        public bool Unique { get; set; }

        public override string TypeName
        {
            get { return "Index"; }
        }

        internal override Database ResolveDatabase()
        {
            return ParentTable.ResolveDatabase();   
        }

        internal override void BuildExpectations()
        {
           
        }
    }
}