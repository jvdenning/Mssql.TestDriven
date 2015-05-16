using System.Collections.Generic;

namespace SqlTestDriven.Contracts
{
    internal interface INamedItemParent : IDbObject
    {
        IEnumerable<string> NamedItems { get; set; }
        IDbObject NamedItemType { get; set; }
    }
}