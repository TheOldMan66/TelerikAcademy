using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Customer
    {
        private string name;
        public Customer( string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }

    class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name)
            : base(name)
        {
        }
    }

    class CompanyCustomer : Customer
    {
        public CompanyCustomer(string name)
            : base(name)
        {
        }
    }
}
