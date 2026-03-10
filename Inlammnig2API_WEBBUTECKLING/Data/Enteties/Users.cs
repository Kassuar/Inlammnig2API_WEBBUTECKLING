namespace Inlammnig2API_WEBBUTECKLING.Data.Enteties
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        List<Posts> posts { get; set; }
        List<Comments> comments { get; set; }



 
    }


}
