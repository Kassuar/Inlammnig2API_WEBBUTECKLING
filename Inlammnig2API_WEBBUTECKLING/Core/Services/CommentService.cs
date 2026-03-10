using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;


namespace Inlammnig2API_WEBBUTECKLING.Core.Services
{
   
        public class CommentService: ICommentService
    {
            private readonly ICommentRepo _commentRepo;
            private readonly IPostRepo _postRepo;

            public CommentService(ICommentRepo commentRepo, IPostRepo postRepo)
            {
                _commentRepo = commentRepo;
                _postRepo = postRepo;
            }



        public Comments CreateComment(CommentDTO dto)
        {
            var post = _postRepo.GetPostById(dto.PostId);

            if (post == null)
                return null;

            if (post.UserId == dto.userId)
                return null;

            var comment = new Comments
            {
                Content = dto.Content,
                PostId = dto.PostId,
                UserId = dto.userId,
                CreatedAt = DateTime.Now
            };

            return _commentRepo.CreateComment(comment);
        }

               
            

            public List<Comments> GetCommentsByPostId(int postId)
            {
                return _commentRepo.GetCommentsByPostId(postId);
            }

            public bool DeleteComment(int id)
            {
                return _commentRepo.DeleteComment(id);
            }
    }
}
