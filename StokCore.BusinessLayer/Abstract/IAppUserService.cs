using StokCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.BusinessLayer.Abstract
{
    public interface IAppUserService
    {
        void AddUser(AppUser user);
        AppUser GetUser(string username, string password);
    }
}
