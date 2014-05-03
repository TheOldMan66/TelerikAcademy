using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{

    /* A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
     * Customers could be individuals or companies.	All accounts have customer, balance and interest rate (monthly based). 
     * Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
     * All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated 
     * as follows: number_of_months * interest_rate.
     * Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held 
     * by a company.Deposit accounts have no interest if their balance is positive and less than 1000. Mortgage accounts have 
     * ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
     * Your task is to write a program to model the bank system by classes and interfaces. You should identify the classes, 
     * interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.*/

    class BankTest
    {
        static void Main()
        {

            // deposit account, individual owner

            Console.SetWindowSize(80, 40);
            IndividualCustomer customer1 = new IndividualCustomer("John Smith");
            DepositAccount deposit1 = new DepositAccount(customer1, 10, 500);
            Console.WriteLine(deposit1);
            deposit1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            deposit1.Deposit(2500.0m);
            deposit1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            deposit1.InterestRate = 5.0m;
            deposit1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Trying to withdraw 5000 from account:");
            try
            {
                deposit1.Withdraw(5000);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Insufficent funds in account");
            }

            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // loan account, individual owner

            Console.Clear();
            LoanAccount loan1 = new LoanAccount(customer1, 10, 10000.0m);
            Console.WriteLine(loan1);
            loan1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            loan1.Deposit(2500.0m);
            loan1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            loan1.InterestRate = 5.0m;
            loan1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // Mortage account, individual owner

            Console.Clear();
            MortageAccount mortage1 = new MortageAccount(customer1, 10, 10000.0m);
            Console.WriteLine(mortage1);
            mortage1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            mortage1.Deposit(2500.0m);
            mortage1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            mortage1.InterestRate = 5.0m;
            mortage1.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // deposit account, company owner

            Console.Clear();
            Console.SetWindowSize(80, 40);
            CompanyCustomer customer2 = new CompanyCustomer("ACME Ltd.");
            DepositAccount deposit2 = new DepositAccount(customer2, 10, 500);
            Console.WriteLine(deposit2);
            deposit2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            deposit2.Deposit(2500.0m);
            deposit2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            deposit2.InterestRate = 5.0m;
            deposit2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Trying to withdraw 5000 from account:");
            try
            {
                deposit2.Withdraw(5000);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Insufficent funds in account");
            }

            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // loan account, individual owner

            Console.Clear();
            LoanAccount loan2 = new LoanAccount(customer2, 10, 10000.0m);
            Console.WriteLine(loan2);
            loan2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            loan2.Deposit(2500.0m);
            loan2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            loan2.InterestRate = 5.0m;
            loan2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // Mortage account, individual owner

            Console.Clear();
            MortageAccount mortage2 = new MortageAccount(customer2, 10, 10000.0m);
            Console.WriteLine(mortage2);
            mortage2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Depositing 2500 in account. New status of account:");
            mortage2.Deposit(2500.0m);
            mortage2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Changing interest rate to 5%. New status of account:");
            mortage2.InterestRate = 5.0m;
            mortage2.PrintInterestTable();
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> for next example");
            Console.ReadLine();

            // test all together
            Console.Clear();
            List<Account> musaka = new List<Account>();
            musaka.Add(deposit1);
            musaka.Add(mortage2);
            musaka.Add(loan2);
            musaka.Add(deposit2);
            musaka.Add(loan1);
            musaka.Add(mortage1);
            Console.WriteLine("Printing interest for various account types (for 7 months):");
            foreach (Account account in musaka)
            {
                Console.WriteLine("Type: {0}, Owner: {1}, Balance: {2}, Interst: {3}", account.GetType().Name, account.Owner.Name, account.Balance, account.CalculateInterest(7));                
            }

        }
    }
}
