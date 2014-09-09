namespace CarCorp.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    public class Car
    {
        public int Id { get; set; }

        //[Required]
        //[Index(IsUnique = true)]
        //[StringLength(10)]

        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }


    }
}
