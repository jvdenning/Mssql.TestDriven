namespace SqlTestDriven.Contracts
{
    public interface INamed
    {
        string Name { get; set; }
        IDbObject Parent { get; set; }
    }
}