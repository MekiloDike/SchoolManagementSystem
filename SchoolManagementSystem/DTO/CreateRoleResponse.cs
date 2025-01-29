namespace SchoolManagementSystem.DTO
{
    public class CreateRoleResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
       
    }

    public class ResponseDto 
    {
        public bool IsSuccessful { get; set;}
        public string? Message { get; set;}
        public string Id { get; set;}
    }
}
