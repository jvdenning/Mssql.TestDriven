using System.Collections.Generic;

namespace SqlTestDriven
{
    internal abstract class Expectation
    {
        protected Expectation()
        {
            ChildExpectations = new List<Expectation>();
        }

        internal bool? Success { get; private set; }

        internal abstract void AssertExpectation();

        internal string Message { get; private set; }

        internal abstract bool Fatal { get; }

        internal List<Expectation> ChildExpectations { get; set; } 

        protected void Fail(string message)
        {
            Finish(false, message);
        }

        protected void Succeed(string message)
        {
            Finish(true, message);
        }

        private void Finish(bool result, string message)
        {
            Message = message;
            Success = result;
        }
    }
}