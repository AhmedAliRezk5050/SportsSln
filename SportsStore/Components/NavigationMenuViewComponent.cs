using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
  private IStoreRepository repository;

  public NavigationMenuViewComponent(IStoreRepository repo)
  {
    repository = repo;
  }

  public IViewComponentResult Invoke()
  {
    ViewBag.SelectedCategory = RouteData?.Values["category"];

    return View(
      repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c)
    );
  }
}