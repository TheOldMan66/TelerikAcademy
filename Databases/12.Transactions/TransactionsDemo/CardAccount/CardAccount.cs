
namespace ATM.Model
{
    using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardPin { get; set; }

        [Required]
        public decimal CardCash { get; set; }

        public override string ToString()
        {
            return string.Format("{3,-2} {0,-15} {1,-5} {2,-10:C}", this.CardNumber, this.CardPin, this.CardCash, this.Id);
        }
    }
}
