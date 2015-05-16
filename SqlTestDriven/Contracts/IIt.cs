using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IIt<T> : ICore where T : IAssertable
    {
        T It { get; }
    }
}