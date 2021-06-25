using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
	public partial class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Icon { get; set; }

        [Column("SelfPickupAddress")]
        public string _SelfPickupAddress { get; set; }

        [NotMapped]
        public string SelfPickupAddress {
            get {
                if (!this.IsSeller) {
                    throw new Exception("User is not a seller");
                }

                return this._SelfPickupAddress;
            }
            set {
                if (!this.IsSeller) {
                    throw new Exception("User is not a seller");
                }

                _SelfPickupAddress = value;
            }
        }

        [Column("PhoneNumber")]
        public string _PhoneNumber { get; set; }

        [NotMapped]
        public string PhoneNumber {
            get {
                if (!this.IsSeller) {
                    throw new Exception("User is not a seller");
                }

                return this.PhoneNumber;
            }
            set {
                if (!this.IsSeller) {
                    throw new Exception("User is not a seller");
                }

                _PhoneNumber = value;
            }
        }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public bool IsSeller { get; set; } = false;

        [Required]
        public bool IsBuyer { get; set; } = false;

        public ICollection<Advert> CreatedAdverts { get; set; }

        public ICollection<Offer> CreatedOffers { get; set; }
    }
}
