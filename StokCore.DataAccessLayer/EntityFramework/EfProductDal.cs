using Microsoft.EntityFrameworkCore;
using StokCore.DataAccessLayer.Abstract;
using StokCore.DataAccessLayer.Repository;
using StokCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.DataAccessLayer.EntityFramework
{
    public class EfProductDal:GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductWithCategory()
        {
            using var context = new AppDbContext();
            return context.Products.Include(p => p.Category).ToList();
        }
    }
}
