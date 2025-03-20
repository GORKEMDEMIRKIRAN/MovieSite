




/*
    Bu kısımda database içinde film türleri oluşturmuştuk. Bu film türlerini
    direkt database alıp filmlerin yanındaki bölümlere kategörileri yansıtacağız.
*/

// ==================================
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// ==================================
using Repositories.ServerRepository.Abstract;
using Repositories.ServerRepository.Concrete.EfCore;
// ==================================

namespace movieapp.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public CategoriesViewComponent(ICategoryRepository categoryRepository)
        {
            this._categoryRepository=categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.GetAllCategories());
        }
    }
}