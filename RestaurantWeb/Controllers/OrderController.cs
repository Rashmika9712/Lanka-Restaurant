using Restaurant.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Utility;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;       

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(string? status=null)
        {
            var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser");

            if(status== "cancelled")
            {
                OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.StatusCancelled || u.Status == SD.StatusRejected);
            }
            else
            {
                if(status== "completed")
                {
                    OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.StatusCompleted);
                }
                else
                {
                    if (status == "ready")
                    {
                        OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.StatusReady);
                    }
                    else
                    {
                        OrderHeaderList = OrderHeaderList.Where(u => u.Status == SD.StatusSubmitted || u.Status == SD.StatusInProcess);
                    }
                }
            }

            return Json(new{ data = OrderHeaderList});
        }       
        
    }
}
