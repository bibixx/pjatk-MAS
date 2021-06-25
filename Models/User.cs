using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
    public enum UserType {
        Seller,
        Buyer
    }

	public partial class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [NotMapped]
        public List<UserType> Types { get; set; }

        public ICollection<Advert> CreatedAdverts { get; set; }

        public ICollection<Offer> CreatedOffers { get; set; }
    }
}
