using System.Collections.Generic;

namespace mas_project.Models.DTOs.Responses
{
    public class GetAdvertsDTOAdvert {
        public int IdAdvert { get; set; }
        public GameConditionType GameCondition { get; set; }
        public string Category { get; set; }
        public IEnumerable<GameDTO> Games { get; set; }
	}

    public class GetAdvertsDTO {
		public IEnumerable<GetAdvertsDTOAdvert> Adverts { get; set; }
	}
}
