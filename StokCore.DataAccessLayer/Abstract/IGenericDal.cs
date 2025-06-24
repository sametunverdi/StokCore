using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        List<T> GetList();
        T GetByID(int id);
        void Insert(T t);
        void Update(T t);   
        void Delete(T t);


    }
}
