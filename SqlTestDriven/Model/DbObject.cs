using SqlTestDriven.Contracts;

namespace SqlTestDriven
{
    public abstract class DbObject<T> : IDbObject
    {
        internal T ServerObject { get; set; }
        public string Name { get; set; }
        public IDbObject Parent { get; set; }
        public abstract string TypeName { get; }
    }
}