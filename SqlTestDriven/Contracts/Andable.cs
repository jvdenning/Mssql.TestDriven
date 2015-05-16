using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public class Andable<TInterface> : CoreAssertable, IAnd<TInterface> where TInterface : IAssertable
    {
        public Andable(TInterface instanceOfAnd)
        {
            And = new Itable<TInterface>(instanceOfAnd);
            AndThatsAll = instanceOfAnd;

        }

        public IIt<TInterface> And { get; private set; }
        public TInterface AndThatsAll { get; private set; }

        internal override void Assert()
        {
            And.It.Assert();
        }
    }
}