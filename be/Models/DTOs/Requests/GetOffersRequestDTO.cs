using System;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models.DTOs.Requests
{
    public class GetOffersRequestDTO {
        [Required]
        public int IdSeller { get; set; }
    }
}
