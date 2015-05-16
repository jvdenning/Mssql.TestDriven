using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public class WhichAndable<TParentInterface, TChildInterface> : CoreAssertable, IWhichAndable<TParentInterface, TChildInterface> where TParentInterface : IAssertable where TChildInterface : IAssertable
    {
        public WhichAndable(TParentInterface instanceOfParent, TChildInterface instanceOfChild)
        {
            Which = instanceOfChild;
            And = new Itable<TParentInterface>(instanceOfParent);
            AndThatsAll = instanceOfParent;
        }

        public TChildInterface Which { get; private set; }
        public IIt<TParentInterface> And { get; private set; }
        public TParentInterface AndThatsAll { get; private set; }
        internal override void Assert()
        {
             And.It.Assert();
        }
    }

}