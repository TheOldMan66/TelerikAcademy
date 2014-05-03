using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{

    abstract class Account
    {
        private decimal balance;
        private decimal interestRate;
        private Customer customer;

        public Account(Customer customer, decimal rate)
        {
            if (customer == null)
                throw new ArgumentNullException("Account owner cannot be null");
            this.customer = customer;
            this.InterestRate = rate;
            this.balance = 0.0m;
        }

        public Account(Customer customer, decimal rate, decimal balance)
            : this(customer, rate)
        {
            if (balance < 0)
                throw new ArgumentException("Initial balance of deposit account cannot be negative");
            this.balance = balance;
        }

        public Customer Owner
        {
            get { return customer; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Interest rate cannot be negative");
                interestRate = value;
            }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public virtual decimal CalculateInterest(int months)
        {
            return balance * interestRate / 100 * months;
        }

        public abstract void Deposit(decimal sum);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Account type: " + this.GetType().Name + Environment.NewLine);
            sb.Append("Account owner: " + this.Owner.Name + " (" + this.Owner.GetType().Name + ")" + Environment.NewLine);
            sb.Append("Account balance: " + this.Balance + Environment.NewLine);
            sb.Append("Account mounthly interest rate: " + this.InterestRate + "%");
            return sb.ToString();
        }
        public void PrintInterestTable()
        {
            Console.WriteLine("Interest for 1 month: " + this.CalculateInterest(1));
            Console.WriteLine("Interest for 2 month: " + this.CalculateInterest(2));
            Console.WriteLine("Interest for 3 month: " + this.CalculateInterest(3));
            Console.WriteLine("Interest for 6 month: " + this.CalculateInterest(6));
            Console.WriteLine("Interest for 9 month: " + this.CalculateInterest(9));
            Console.WriteLine("Interest for 1 year : " + this.CalculateInterest(12));
            Console.WriteLine("Interest for 2 years: " + this.CalculateInterest(24));

        }
    }

    class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal rate)
            : base(customer, rate)
        {
        }
        public DepositAccount(Customer customer, decimal rate, decimal balance)
            : base(customer, rate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
                throw new ArgumentException("Cannot calculate interest for less than a 1 month");
            if (Balance > 0 && Balance < 1000.0m)
                return 0.0m;
            else
                return base.CalculateInterest(months);
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0.0m)
                throw new ArgumentException("Cannot deposit negative value");
            Balance = Balance + sum;
        }

        public void Withdraw(decimal sum)
        {
            if (sum <= 0.0m)
                throw new ArgumentException("Cannot deposit negative value");
            if (Balance - sum < 0.0m)
                throw new InvalidOperationException("Insufficient funds");
            Balance = Balance - sum;
        }
    }

    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal rate)
            : base(customer, rate)
        {
        }

        public LoanAccount(Customer customer, decimal rate, decimal balance)
            : base(customer, rate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
                throw new ArgumentException("Cannot calculate interest for less than a 1 month");
            if (months <= 2 || (Owner is IndividualCustomer && months <= 3))
                return 0.0m;
            else
                return base.CalculateInterest(months);
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0.0m)
                throw new ArgumentException("Cannot deposit negative value");
            Balance = Balance - sum;
        }

    }

    class MortageAccount : Account
    {
        public MortageAccount(Customer customer, decimal rate)
            : base(customer, rate)
        {
        }

        public MortageAccount(Customer customer, decimal rate, decimal balance)
            : this(customer, rate)
        {
            if (balance < 0)
                throw new ArgumentException("Initial balance of deposit account cannot be negative");
            this.Balance = balance;
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
                throw new ArgumentException("Cannot calculate interest for less than a 1 month");
            if (Owner is CompanyCustomer)
            {
                if (months < 13)
                    return base.CalculateInterest(months) / 2;
                else
                    return base.CalculateInterest(12) / 2 + base.CalculateInterest(months - 12);
            }
            else
            {
                if (months > 6)
                    return base.CalculateInterest(months);
                else
                    return 0.0m;
            }
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0.0m)
                throw new ArgumentException("Cannot deposit negative value");
            Balance = Balance - sum;
        }
    }
}
