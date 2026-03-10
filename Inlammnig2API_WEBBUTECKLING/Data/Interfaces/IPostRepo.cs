using Inlammnig2API_WEBBUTECKLING.Data.Enteties;


namespace Inlammnig2API_WEBBUTECKLING.Data.Interfaces
{
    public interface IPostRepo
    {
        Posts CreatePost(Posts post);
        List<Posts> GetAllPosts();
        Posts GetPostById(int id);
        Posts UpdatePost(Posts post);
        bool DeletePost(int id);

        List<Posts> SearchPosts(string keyword);


    }
}
