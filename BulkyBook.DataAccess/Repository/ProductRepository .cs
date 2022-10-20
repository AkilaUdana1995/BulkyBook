using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{


    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private  ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);
            //_db.SaveChanges();

            //suppose we have to update specific  records from DB, recreating the object 

            var ObjFromDB = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (ObjFromDB !=null)
                {
                  ObjFromDB.Title=obj.Title;
                ObjFromDB.ISBN = obj.ISBN;
                ObjFromDB.Price= obj.Price;
                ObjFromDB.ListPrice= obj.ListPrice;
                ObjFromDB.Price50= obj.Price50; 
                ObjFromDB.Price100= obj.Price100;
                ObjFromDB.Description= obj.Description;
                ObjFromDB.Author= obj.Author;
                ObjFromDB.CategoryId= obj.CategoryId;
                ObjFromDB.CoverType= obj.CoverType;

                if (obj.ImageURL!=null)
                    {
                    ObjFromDB.ImageURL = obj.ImageURL;
                    }
                }
        }
    }
}
