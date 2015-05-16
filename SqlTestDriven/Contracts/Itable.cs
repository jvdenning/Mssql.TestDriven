using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public class Itable<T> : CoreAssertable, IIt<T> where T: IAssertable
    {
        public Itable(T interfaceOf)
        {
            It = interfaceOf;

        }
        public T It { get; private set; }
       
        internal override void Assert()
        {
            It.Assert();
        }
    }
}