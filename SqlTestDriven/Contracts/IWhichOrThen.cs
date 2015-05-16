using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IWhichOrThen<T> : IWhich<T>, IThen<T> where T : IAssertable
    {
        
    }
}