using BookTrail.DataAccess.Repository.IRepository;
using BookTrail.Models.ViewModels;
using BookTrail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookTrailWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties : "Category").ToList();
            return View(products);
        }

        public IActionResult Upsert(int ? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            if (id is null or 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u=>u.ProductId.Equals(id));
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if(productVM.Product.ProductId == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                TempData["suceess"] = "New Product Added";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete (int ? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            productVM.Product = _unitOfWork.Product.Get(u => u.ProductId.Equals(id));
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Delete(ProductVM productVM)
        {
            _unitOfWork.Product.Remove(productVM.Product);
            _unitOfWork.Save();
            TempData["suceess"] = "New Product Added";
            return RedirectToAction("Index");
        }
    }
}
