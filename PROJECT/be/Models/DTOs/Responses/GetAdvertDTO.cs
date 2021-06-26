using System;
using System.Collections.Generic;

namespace mas_project.Models.DTOs.Responses
{
    public class GetAdvertDTOSeller {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SelfPickupAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class GetAdvertDTO {
        public int IdAdvert { get; set; }
        public GameConditionType GameCondition { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public GetAdvertDTOSeller Seller { get; set; }
        public IEnumerable<GameDTO> Games { get; set; }
        public IEnumerable<GameDTO> GamesThatCanBeTraded { get; set; }
	}
}
