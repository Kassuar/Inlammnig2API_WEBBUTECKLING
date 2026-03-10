using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.DTO;

namespace Inlammnig2API_WEBBUTECKLING.Interfaces
{
    public interface ICategoryService 
    {
        Categories CreateCategory(CategoryDTO dto);
        List<Categories> GetAllCategories();


    }
}
