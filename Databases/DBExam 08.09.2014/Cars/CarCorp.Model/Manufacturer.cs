namespace CarCorp.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
