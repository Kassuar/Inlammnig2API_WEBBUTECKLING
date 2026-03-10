using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.DTO;

namespace Inlammnig2API_WEBBUTECKLING.Interfaces
{
    public interface IPostService
    {
        Posts CreatePost(PostDTO dto);
        List<Posts> GetAllPosts();
        Posts GetPostById(int id);
        Posts UpdatePost(int id,PostDTO dto);
        bool DeletePost(int id);
        List<Posts> SearchPosts(string keyword);


    }
}
