using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;//DI çerçevesi

        public CategoryManager(IRepositoryManager manager)//injectionu kurucu üzerinden gerçekleştiriyorum
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
           return _manager.Category.FindAll(trackChanges);
        }
    }


}