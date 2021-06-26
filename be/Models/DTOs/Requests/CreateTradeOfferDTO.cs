using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models.DTOs.Requests
{
    public class CreateTradeOfferDTO {
        [Required]
        public List<int> GameIds { get; set; }

        [Required]
        public int IdBuyer { get; set; }
    }
}
