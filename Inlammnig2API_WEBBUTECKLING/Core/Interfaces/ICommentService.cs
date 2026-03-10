using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.DTO;

namespace Inlammnig2API_WEBBUTECKLING.Core.Services
{
    public interface ICommentService
    {
         
        Comments CreateComment(CommentDTO dto);

        List<Comments> GetCommentsByPostId(int postId);

        bool DeleteComment(int id);
    }
}
