using System;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
	public partial class SelfPickup : CollectionMethod
    {
        [Required]
        public DateTime EstimatedPickupDate { get; set; }
    }
}
