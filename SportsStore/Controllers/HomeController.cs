using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private IStoreRepository repository;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string? category, int productPage = 1)
        {
            var products = repository.Products;
            return View(new ProductsListViewModel
            {
                Products = products.Where(p => category == null || p.Category == category)
                                   .OrderBy(p => p.ProductID)
                                   .Skip((productPage - 1) * PageSize)
                                   .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = category == null ?
                    products.Count()
                    :
                    products.Where(p => p.Category == category).Count(),
                    ItemsPerPage = PageSize,
                    CurrentPage = productPage,
                },
                CurrentCategory = category,
            });
        }
    }
}
