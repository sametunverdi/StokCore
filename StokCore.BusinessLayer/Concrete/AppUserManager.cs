using StokCore.BusinessLayer.Abstract;
using StokCore.DataAccessLayer.Abstract;
using StokCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void AddUser(AppUser user)
        {
            _appUserDal.Insert(user);
        }

        public AppUser GetUser(string username, string password)
        {
            return _appUserDal.GetByUsernameAndPassword(username, password);
        }
    }
}
