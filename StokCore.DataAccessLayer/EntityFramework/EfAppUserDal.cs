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
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public AppUser GetByUsernameAndPassword(string username, string password)
        {
            using var context = new AppDbContext();
            return context.AppUsers.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
