using Inlammnig2API_WEBBUTECKLING.Data.Enteties;

namespace Inlammnig2API_WEBBUTECKLING.Interfaces
{
    public interface ICommentRepo

    {
        Comments CreateComment(Comments comment);
        List<Comments> GetCommentsByPostId (int PostId);
        Comments GetCommentById(int id);
        bool DeleteComment(int id);



    }
}
