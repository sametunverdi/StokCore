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
    public class EfCategoryDal:GenericRepository<Category>, ICategoryDal
    {
    }
}
