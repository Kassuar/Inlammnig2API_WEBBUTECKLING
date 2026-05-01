using Inlammnig2API_WEBBUTECKLING.Data;
using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PostRepo : IPostRepo
{
    private readonly AppDbContext _context;

    public PostRepo(AppDbContext context)
    {
        _context = context;
    }

    public List<Posts> GetAllPosts()
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .ToList();
    }

    public Posts GetPostById(int id)
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .FirstOrDefault(p => p.Id == id);
    }

    public Posts CreatePost(Posts post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public Posts UpdatePost(Posts post)
    {
        _context.Posts.Update(post);
        _context.SaveChanges();
        return post;
    }

    public bool DeletePost(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);

        if (post == null)
            return false;

        _context.Posts.Remove(post);
        _context.SaveChanges();
        return true;
    }

    public List<Posts> SearchPosts(string keyword)
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .Where(p => p.Title.Contains(keyword) || p.Content.Contains(keyword))
            .ToList();
    }
}
