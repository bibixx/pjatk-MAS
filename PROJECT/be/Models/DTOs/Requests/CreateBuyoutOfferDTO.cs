using System;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models.DTOs.Requests
{
    public class CreateBuyoutOfferDTO {
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public float Price { get; set; }

        [Required]
        public int IdBuyer { get; set; }
    }
}
