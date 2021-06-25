using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
	public abstract partial class PaymentMethod
    {
        [Key]
        public int IdPaymentMethod { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
