using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class TradeOfferGame
    {
        [Key]
        public int IdTradeOfferGame { get; set; }

        [Required]
        public int IdGame { get; set; }

        [ForeignKey(nameof(IdGame))]
        public Game Game { get; set; }

        [Required]
        public int IdOffer { get; set; }

        [ForeignKey(nameof(IdOffer))]
        public TradeOffer TradeOffer { get; set; }
    }
}
