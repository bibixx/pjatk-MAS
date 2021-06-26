using System;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models.DTOs.Requests
{
    public class LoginDTORequest {
        [Required]
        public string UserName { get; set; }
    }
}
