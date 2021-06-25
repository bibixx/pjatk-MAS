using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
	public abstract partial class CollectionMethod
    {
        [Key]
        public int IdCollectionMethod { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
