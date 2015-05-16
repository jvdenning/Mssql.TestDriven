using System;
using SqlTestDriven.Contracts;

namespace SqlTestDriven.Model
{
    public class View : Assertable<View, Microsoft.SqlServer.Management.Smo.View>, ITableAssertable
    {
        internal override Database ResolveDatabase()
        {
            return Parent as Database;
        }

        internal override void BuildExpectations()
        {
            throw new NotImplementedException();
        }

        public override string TypeName
        {
            get {return "View"; }
        }
    }
}