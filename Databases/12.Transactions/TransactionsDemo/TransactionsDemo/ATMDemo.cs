
namespace TransactionsDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ATM.Model;
    using ATM.Data;
    using System.Data.Entity;
    using System.Transactions;

    class ATMDemo
    {
        static Random rnd = new Random();

        static void PopulateData(ATMDBContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                CardAccount account = new CardAccount
                {
                    CardPin = rnd.Next(9999).ToString(),
                    CardNumber = (rnd.Next(999999999) + 1000000000).ToString(),
                    CardCash = rnd.Next(500) + 20.0M
                };
                db.Accounts.Add(account);
            }
            db.SaveChanges();

        }

        static void Main(string[] args)
        {
            var accountDB = new ATMDBContext();
            // please, commnet next line after first start to avoid further accounts generation
            PopulateData(accountDB);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ID Card Number  Card PIN   Amount");
                foreach (var account in accountDB.Accounts)
                {
                    Console.WriteLine(account);
                }
                Console.Write("Enter source card number: ");
                string sourceAccountNo = Console.ReadLine();
                Console.Write("Enter source card PIN: ");
                string sourcePIN = Console.ReadLine();
                Console.Write("Enter amount of money to transfer: ");
                decimal amountToTransfer = decimal.Parse(Console.ReadLine());

                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    CardAccount sourceAccount = accountDB.Accounts.FirstOrDefault<CardAccount>(a => a.CardNumber == sourceAccountNo && a.CardPin == sourcePIN);

                    if (sourceAccount == null)
                    {
                        Console.WriteLine("No such account");
                        scope.Dispose();
                        Console.WriteLine("Press ENTER for new transaction");
                        Console.ReadLine();
                        continue;
                    }

                    if (amountToTransfer < 0)
                    {
                        Console.WriteLine("You cannot withdraw negative value.");
                        scope.Dispose();
                        Console.WriteLine("Press ENTER for new transaction");
                        Console.ReadLine();
                        continue;
                    }

                    if (sourceAccount.CardCash - amountToTransfer < 0)
                    {
                        Console.WriteLine("This account don't have enough money");
                        scope.Dispose();
                        Console.WriteLine("Press ENTER for new transaction");
                        Console.ReadLine();
                        continue;                        
                    }
                    sourceAccount.CardCash = sourceAccount.CardCash - amountToTransfer;

                    accountDB.TransactionLogs.Add(new TransactionLog
                    {
                        CardNumber = sourceAccount.CardNumber,
                        TransactionDate = DateTime.Now,
                        Amount = amountToTransfer,
                        NewBalance = sourceAccount.CardCash,
                    });

                    accountDB.SaveChanges();
                    scope.Complete();
                    Console.WriteLine("Transaction successful. New acaount balance is {0}",sourceAccount.CardCash);
                    Console.WriteLine("Press ENTER for new transaction");
                    Console.ReadLine();
                }
            }
        }
    }
}
