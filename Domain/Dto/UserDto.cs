namespace Domain.Dto
{
    public class UserDto
    {
        public int User_id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }

        public string Image { get; set; }

        public string? location { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public bool? status { get; set; }
        public int? role_id { get; set; }
        public DateTime CreationTime { get; set; }


    }
}
