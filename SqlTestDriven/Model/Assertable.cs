using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlTestDriven.Contracts;

namespace SqlTestDriven.Model
{
    public interface IAssertable : ICore
    {
        void Assert();
    }

    public abstract class Assertable<T, T2> : DbObject<T2>, IAssertable
    {
        protected Assertable()
        {
            Expectations = new List<Expectation>();
        }

        internal List<Expectation> Expectations { get; set; }
   
        public void Assert()
        {
            var database = ResolveDatabase();
            database.BuildExpectations();
            foreach (var expectation in database.Expectations)
            {
                AssertExpectation(expectation);
            }

           
            var feedback = new StringBuilder();
            var success = GetSuccessAndFeedback(database.Expectations, feedback);

            if (!success)
            {
                var msg = string.Format("Assertion Failed: {0}", feedback);
                throw new AssertFailedException(msg);
            }

            Console.Write(feedback);
        }

        private bool GetSuccessAndFeedback(List<Expectation> expectations, StringBuilder feedback)
        {
            bool success = true;
            foreach (var expectation in expectations)
            {
                feedback.AppendLine(expectation.Message);
                if (expectation.Success.HasValue && !expectation.Success.Value)
                {
                    success = false;

                    if (expectation.Fatal)
                    {
                        continue;
                    }
                }

                var childResult = GetSuccessAndFeedback(expectation.ChildExpectations, feedback);

                if (!childResult)
                {
                    success = false;
                }
            }

            return success;
        }

        private void AssertExpectation(Expectation expectation)
        {
            expectation.AssertExpectation();
            if (expectation.Success.HasValue && !expectation.Success.Value && expectation.Fatal)
            {
                return;
            }

            foreach (var childExpectation in expectation.ChildExpectations)
            {
                AssertExpectation(childExpectation);
            }
        }

        internal abstract Database ResolveDatabase();
        internal abstract void BuildExpectations();

    }
}