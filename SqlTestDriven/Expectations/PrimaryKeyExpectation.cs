using System;

namespace SqlTestDriven
{
    internal class PrimaryKeyExpectation : Expectation
    {
        public PrimaryKeyExpectation()
        {
            
        }


        internal override void AssertExpectation()
        {
            throw new NotImplementedException();
        }

        internal override bool Fatal
        {
            get { return false; }
        }
    }
}