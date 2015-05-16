using SqlTestDriven.Contracts;
using SqlTestDriven.Model;

namespace SqlTestDriven.Extensions
{
    public static class CoreExtensions
    {
        public static void Assert(this ICore core)
        {
            var assertable = core as IAssertable;
            if (assertable != null)
            {
                assertable.Assert();
            }

            var coreAssertable = core as CoreAssertable;

            if (coreAssertable != null)
            {
                coreAssertable.Assert();
            }
        }
    }
}
