﻿using BookTrail.DataAccess.Data;
using BookTrail.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrail.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category {get; private set;}
        public IProductRepository Product {get; private set;}
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
