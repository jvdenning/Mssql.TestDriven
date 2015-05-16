using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlTestDriven.Contracts;
using SqlTestDriven.Extensions;
using Column = SqlTestDriven.Model.Column;

namespace SqlTestDriven.Tests
{
    [TestClass]
    public class EnvironmentTests
    {
        [TestInitialize]
        public void SetUp()
        {
            Configuration.Current = new Configuration
            {
                ServerName = "localhost\\Sql2012",
                DatabaseName = "AdventureWorksLT2008R2"
            };
        }


        [TestMethod]
        public void TestForOneColumn()
        {
            var expectation = GivenTheDatabaseToTest
                .WhichHasASchemaCalled("SalesLT")
                .Which.HasATableCalled("Product")
                .Then.It.ShouldHaveA(
                    Column.Called("ProductId").Which.ShouldBeOfType(SqlDataType.Int).AndThatsAll)
                .And.It.ShouldHaveA(
                    Column.Called("Name")
                        .Which.ShouldBeOfType(SqlDataType.UserDefinedDataType).AndThatsAll);

            expectation.Assert();

        }



    }

}
