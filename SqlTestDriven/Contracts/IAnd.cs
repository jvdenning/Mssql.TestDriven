using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IAnd<T> : ICore where T : IAssertable
    {
        IIt<T> And { get; }
        T AndThatsAll { get; }
   
    }
}