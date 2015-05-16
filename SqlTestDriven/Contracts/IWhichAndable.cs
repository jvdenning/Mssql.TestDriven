using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public interface IWhichAndable<TParentInterface, TChildInterface> : IWhich<TChildInterface>, IAnd<TParentInterface> where TParentInterface : IAssertable where TChildInterface : IAssertable
    {
    }
}