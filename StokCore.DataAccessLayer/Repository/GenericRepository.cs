﻿using StokCore.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace StokCore.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new AppDbContext();
            c.Remove(t);
            c.SaveChanges();    

        }

        public List<T> GetAll()
        {
            using var c = new AppDbContext();
            return c.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            using var c = new AppDbContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new AppDbContext();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new AppDbContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new AppDbContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
