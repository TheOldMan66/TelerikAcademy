namespace ATM.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    
    using ATM.Model;
    public class ATMDBContext : DbContext
    {
        public ATMDBContext()
        {

        }

        public DbSet<CardAccount> Accounts { get; set; }

        public DbSet<TransactionLog> TransactionLogs { get; set; }
    }
}
