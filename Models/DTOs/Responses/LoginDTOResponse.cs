namespace mas_project.Models.DTOs.Responses
{
    public class LoginDTOResponse {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public bool IsSeller { get; set; }
        public bool IsBuyer { get; set; }
        public string SelfPickupAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
