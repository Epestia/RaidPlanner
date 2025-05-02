namespace RaidPlanner.Api.Dto
{
    public class LoginDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }


        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
}
