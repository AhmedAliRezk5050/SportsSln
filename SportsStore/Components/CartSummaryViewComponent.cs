using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartservice)
        {
            cart = cartservice;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
