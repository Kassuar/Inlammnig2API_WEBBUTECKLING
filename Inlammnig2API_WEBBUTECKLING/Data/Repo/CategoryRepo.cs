using Inlammnig2API_WEBBUTECKLING.Data;
using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;

public class CategoryRepo : ICategoryRepo
{
    private readonly AppDbContext _context;

    public CategoryRepo(AppDbContext context)
    {
        _context = context;
    }

    public Categories CreateCategory(Categories category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    public List<Categories> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Categories GetCategoryById(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.Id == id);
    }
}