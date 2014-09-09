namespace CarCorp.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }
        public int Id { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [StringLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Cities
        {
            get
            {
                return this.dealers;
            }
            set
            {
                this.dealers = value;
            }
        }
    }
}
