using SqlTestDriven.Model;

namespace SqlTestDriven.Contracts
{
    public class Whichable<T> : CoreAssertable, IWhichOrThen<T> where T : IAssertable
    {
        public Whichable(T instanceOf)
        {
            Which = instanceOf;
            Then = new Itable<T>(instanceOf);
        }

        public T Which { get; private set; }
        public IIt<T> Then { get; private set; }
 
        internal override void Assert()
        {
            Which.Assert();
        }
    }
}