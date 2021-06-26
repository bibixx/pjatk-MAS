using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class BuyoutOffer : Offer
    {
        [Required]
        public float Price { get; set; }
    }
}
