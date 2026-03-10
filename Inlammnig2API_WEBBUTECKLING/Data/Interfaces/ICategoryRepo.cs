using Inlammnig2API_WEBBUTECKLING.Data.Enteties;


namespace Inlammnig2API_WEBBUTECKLING.Data.Interfaces
{
    public interface ICategoryRepo 
    {
        Categories CreateCategory(Categories category);
        List<Categories> GetAllCategories();
        Categories GetCategoryById(int id);
      



    }
}
