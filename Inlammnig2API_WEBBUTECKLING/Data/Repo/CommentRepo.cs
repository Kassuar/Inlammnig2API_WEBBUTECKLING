using Inlammnig2API_WEBBUTECKLING.Data;
using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.EntityFrameworkCore;


public class CommentRepo : ICommentRepo
{
    private readonly AppDbContext _context;

    public CommentRepo(AppDbContext context)
    {
        _context = context;
    }

    public Comments CreateComment(Comments comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    public List<Comments> GetCommentsByPostId(int postId)
    {
        return _context.Comments
             .Include(p => p.User)
            .Include(p => p.Post)
            .Where(c => c.PostId == postId)
            .ToList();
    }

    public Comments GetCommentById(int id)
    {
        return _context.Comments
             .Include(p => p.User)
            .Include(p => p.Post)
            .FirstOrDefault(c => c.Id == id);
    }

    public bool DeleteComment(int id)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment == null)
            return false;

        _context.Comments.Remove(comment);
        _context.SaveChanges();
        return true;
    }
}