using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IThen<T> : ICore where T : IAssertable
    {
        IIt<T> Then { get; }
    }
}