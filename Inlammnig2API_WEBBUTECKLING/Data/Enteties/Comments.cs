namespace Inlammnig2API_WEBBUTECKLING.Data.Enteties
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        //Navigation props för att kunna hämta ut info om vem som har kommenterat och vilken post det är kopplat till.
        //Kolla Users klassen där det finns en lista av comments, det är där den här propsen kommer in i bilden.
        //Samma sak gäller för Post klassen där det finns en lista av comments, det är där den här propsen kommer in i bilden.
        public Users User { get; set; }
        public Posts Post { get; set; }
    }
}
