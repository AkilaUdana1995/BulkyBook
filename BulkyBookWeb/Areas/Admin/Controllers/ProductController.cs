using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
       
{
        // private readonly ApplicationDbContext _db;   //interchanging dbContext with Repository
        private readonly IUnitOfWork _db;

        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objCategoryList = _db.Product.GetAll();  //_db then get db set name
            return View(objCategoryList);
        }

        //GET

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Product obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _db.Product.Add(obj);                     //_db.Categories.Add(obj);
        //        _db.Save();                            //_db.SaveChanges();
        //        TempData["success"] = "Product Added Succesfully!!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);

        //}


        //GET


    //upsert method(update + insert)   logic, if id is null or empty, then we create new product object, else we will update it....
        public IActionResult Upsert(int? id)
        {
        Product product=new ();
        IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
            u => new SelectListItem
                {
                Text = u.name,
                Value = u.id.ToString()
                }
            );

        IEnumerable<SelectListItem> CoverTypeList = _db.CoverType.GetAll().Select(
           u => new SelectListItem
               {
               Text = u.name,
               Value = u.id.ToString()
               }
           );

        if (id == null || id == 0)
            {
            ViewBag.CategoryList = CategoryList;
            return View(product);
               //craete product
            }

        else
            {
            //update product
            }
         
           
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {

        
            if (ModelState.IsValid)
            {
                _db.Product.Update(obj);
                _db.Save();
                TempData["success"] = "Product Updated Succesfully!!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //method to delete object

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //   var categoryFromDb = _db.Categories.Find(id);
            var categoryDbFirst = _db.Product.GetFirstOrDefault(u => u.Id == id);
            if (categoryDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product obj)
        {


            if (ModelState.IsValid)
            {
                _db.Product.Remove(obj);
                _db.Save();
                TempData["success"] = "Category Deleted Succesfully!!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }

