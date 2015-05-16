using System.Linq;
using SqlTestDriven.Contracts;

namespace SqlTestDriven
{
    internal class NamedItemExpectation : Expectation
    {
        private readonly string _name;
        private readonly INamedItemParent _namedItemParent;


        public NamedItemExpectation(string name, INamedItemParent namedItemParent)
        {
            _name = name;
            _namedItemParent = namedItemParent;
        }

        internal override void AssertExpectation()
        {
            if (_namedItemParent.NamedItems.Contains(_name))
            {
                var msg = string.Format("{0} {1} found in {2} {3}", _namedItemParent.NamedItemType, _name,
                    _namedItemParent.TypeName, _namedItemParent.Name);
                Succeed(msg);
            }
            else
            {
                var errorMsg = string.Format("{0} {1} not in {2} {3}", _namedItemParent.NamedItemType, _name,
                    _namedItemParent.TypeName, _namedItemParent.Name);
                Fail(errorMsg);
            }

       
         
        }

        internal override bool Fatal
        {
            get { return true; }
        }
    }
}