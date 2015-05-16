using Microsoft.SqlServer.Management.Smo;
using Column = SqlTestDriven.Model.Column;

namespace SqlTestDriven
{
    internal class ColumnTypeExpectation : Expectation
    {
        private readonly SqlDataType _expectedType;
        private readonly Column _column;

        public ColumnTypeExpectation(SqlDataType expectedType, Column column)
        {
            _expectedType = expectedType;
            _column = column;
        }

        internal override void AssertExpectation()
        {
            var actualColumn = _column.GetActualColumn();
            if (actualColumn.DataType.SqlDataType == _expectedType)
            {
                var msg = string.Format("Column {0} has expected data type", _column.Name);
                Succeed(msg);
            }
            else
            {
                var msg = string.Format("Column {0} has data type {1}, expected {2} ", _column.Name, actualColumn.DataType.SqlDataType, _expectedType);
                Fail(msg);      
            }
        }

        internal override bool Fatal
        {
            get { return false; }
        }
    }
}