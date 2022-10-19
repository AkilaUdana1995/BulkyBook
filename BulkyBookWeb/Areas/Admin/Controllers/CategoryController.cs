using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
       
{
        // private readonly ApplicationDbContext _db;   //interchanging dbContext with Repository
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Category.GetAll();  //_db then get db set name
            return View(objCategoryList);
        }

        //GET

        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.name == obj.displayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Display order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);                     //_db.Categories.Add(obj);
                _db.Save();                            //_db.SaveChanges();
                TempData["success"] = "Category Added Succesfully!!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //GET

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  var categoryFromDb = _db.Categories.Find(id);
            var categoryDbFirst = _db.Category.GetFirstOrDefault(u => u.id == id);
            //  var categoryDbSingleOrDefault = _db.Categories.FirstOrDefault(u => u.id == id);
            if (categoryDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.name == obj.displayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Display order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.Save();
                TempData["success"] = "Category Updated Succesfully!!";
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
            var categoryDbFirst = _db.Category.GetFirstOrDefault(u => u.id == id);
            if (categoryDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (obj.name == obj.displayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Display order cannot be same");
            }

            if (ModelState.IsValid)
            {
                _db.Category.Remove(obj);
                _db.Save();
                TempData["success"] = "Category Deleted Succesfully!!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }

