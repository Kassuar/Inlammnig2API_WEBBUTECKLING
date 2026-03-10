using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;


namespace Inlammnig2API_WEBBUTECKLING.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<Categories> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public Categories CreateCategory(CategoryDTO dto)
        {
            var category = new Categories
            {
                Name = dto.Name
            };

            return _categoryRepo.CreateCategory(category);
        }
    }
}
