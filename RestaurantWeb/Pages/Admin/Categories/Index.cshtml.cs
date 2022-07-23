
using Restaurant.DataAccess.Data;
using Restaurant.DataAccess.Repository.IRepository;
using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Categories = _unitOfWork.Category.GetAll();
        }
    }
}
