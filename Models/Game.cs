using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
	public partial class Game
    {
        [Key]
        public int IdGame { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string CoverPhoto { get; set; }

        public ICollection<AdvertGameSubject> AdvertGameSubjects { get; set; }

        public ICollection<AdvertGameCanBeTradedFor> AdvertGamesCanBeTradedFor { get; set; }
    }
}
