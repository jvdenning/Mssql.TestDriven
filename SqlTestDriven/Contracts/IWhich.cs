namespace SqlTestDriven.Contracts
{
    public interface IWhich<out T> : ICore
    {
        T Which { get; }
    }
}