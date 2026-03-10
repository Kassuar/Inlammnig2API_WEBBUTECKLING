using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;

namespace Inlammnig2API_WEBBUTECKLING.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;

        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }


        public Posts CreatePost(PostDTO dto)
        {
            var post = new Posts
            {
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.CategoryId,
                UserId = dto.userId,
                CreatedAt = DateTime.Now
            };

            return _postRepo.CreatePost(post);
        }
        public List<Posts> GetAllPosts()
        {
            return _postRepo.GetAllPosts();
        }

        public Posts GetPostById(int id)
        {
            return _postRepo.GetPostById(id);
        }



        public Posts UpdatePost(int id, PostDTO dto)
        {
            var post = _postRepo.GetPostById(id);

            if (post == null)
                return null;

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.CategoryId = dto.CategoryId;

            return _postRepo.UpdatePost(post);
        }

        public bool DeletePost(int id)
        {
            return _postRepo.DeletePost(id);
        }



        public List<Posts> SearchPosts(string keyword)
        {
            return _postRepo.SearchPosts(keyword);
        }
    }
}