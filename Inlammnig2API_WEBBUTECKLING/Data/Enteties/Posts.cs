namespace Inlammnig2API_WEBBUTECKLING.Data.Enteties
{
    public class Posts
    {
        public int Id { get; set; }
                public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }
        //För Navigationens props.
        //Kolla Users klassen där det finns en lista av posts,det är där den här propsen kommer in i bilden

        public int? CategoryId { get; set; }
        public Users User { get; set; }
       public Categories Category { get; set; }
    }
}
