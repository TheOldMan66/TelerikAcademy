/* A bank account has a holder name (first name, middle name and last name), 
 * available amount of money (balance), bank name, IBAN, BIC code and 3 credit card 
 * numbers associated with the account. Declare the variables needed to keep 
 * the information for a single bank account using the appropriate data types and descriptive names */

using System;


namespace BankAccount
{
    class BankAccount
    {
        static void Main()
        {
            string firstName = "John";
            string middleName = "Baker";
            string lastName = "Smith";
            decimal accountBalance = 14523.78M;
            string bankName = "Bank of America";
            string IBAN = "US80 BAUS 9661 1020 3456 78";
            string BIC = "BAUSWSDC";
            ulong creditCard1 = 4024007141773175UL;
            ulong creditCard2 = 5502621724765073UL;
            ulong creditCard3 = 6011058323972416UL;
            Console.WriteLine("Name: {0} {1} {2}", firstName, middleName,lastName);
            Console.WriteLine("Account balance: {0}", accountBalance);
            Console.WriteLine("Bank name: {0} IBAN: {1}, BIC: {2}", bankName, IBAN, BIC);
            Console.WriteLine("Credit card 1: {0}", creditCard1);
            Console.WriteLine("Credit card 2: {0}", creditCard2);
            Console.WriteLine("Credit card 3: {0}", creditCard3);
        }
    }
}
