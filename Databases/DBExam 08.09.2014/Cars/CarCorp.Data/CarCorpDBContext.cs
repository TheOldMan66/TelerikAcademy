namespace CarCorp.Data
{
    using System.Data.Entity;
    using CarCorp.Model;

    public class CarCorpDBContext : DbContext
    {

        // change connections string if needed!!!!!
        public CarCorpDBContext()
            : base("CarCorp")
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
