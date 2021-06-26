using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
	public partial class Delivery : CollectionMethod
    {
        [Required]
        public string DeliveryAddress { get; set; }
    }
}
