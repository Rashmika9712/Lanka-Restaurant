using Restaurant.DataAccess.Repository.IRepository;
using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Models;

namespace AbbyWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby: u=>u.OrderBy(c=>c.DisplayOrder));
        }
    }
}
