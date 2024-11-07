using BookTrail.DataAccess.Data;
using BookTrail.DataAccess.Repository.IRepository;
using BookTrail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrail.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context) {
            {
                _context = context;
            }
        }
        public void Update(Product product)
        {
            var existProduct = _context.Products.FirstOrDefault(u=>u.ProductId == product.ProductId);
            if (existProduct != null)
            {
                existProduct.Title = product.Title;
                existProduct.Description = product.Description;
                existProduct.Category = product.Category;
                existProduct.ISBN = product.ISBN;
                existProduct.Author = product.Author;
                existProduct.ListPrice = product.ListPrice;
                existProduct.Price = product.Price;
                existProduct.Price50 = product.Price50;
                existProduct.Price100 = product.Price100;
                existProduct.CategoryId = product.CategoryId;
                if (product.ImageUrl != null)
                {
                    existProduct.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
