using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class AdvertGameCanBeTradedFor
    {
        [Key]
        public int IdAdvertGameCanBeTradedFor { get; set; }

        [Required]
        public int IdAdvert { get; set; }

        [ForeignKey(nameof(IdAdvert))]
        public Advert Advert { get; set; }

        [Required]
        public int IdGame { get; set; }

        [ForeignKey(nameof(IdAdvert))]
        public Game Game { get; set; }
    }
}
