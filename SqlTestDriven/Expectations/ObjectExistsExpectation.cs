namespace SqlTestDriven
{
    internal abstract class ObjectExistsExpectation<T1, T2> : Expectation where T1 : DbObject<T2>
    {
        protected readonly T1 Assertable;
        protected readonly string Name;

        protected ObjectExistsExpectation(T1 assertable, string name)
        {
            Assertable = assertable;
            Name = name;
        }
    }
}