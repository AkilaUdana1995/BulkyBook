using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller

    {
    // private readonly ApplicationDbContext _db;   //interchanging dbContext with Repository
    private readonly IUnitOfWork _db;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
        _db = db;
        _webHostEnvironment = webHostEnvironment;
        }
    public IActionResult Index()
        {
        //IEnumerable<Product> objCategoryList = _db.Product.GetAll();  //_db then get db set name
        //return View(objCategoryList);    //28/29 line methods also working......

        //here in this way, trying to perform same task via API controllers
        return View();
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
        //Product product=new ();
        //IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
        //    u => new SelectListItem
        //        {
        //        Text = u.name,
        //        Value = u.id.ToString()
        //        }
        //    );

        //IEnumerable<SelectListItem> CoverTypeList = _db.CoverType.GetAll().Select(
        //   u => new SelectListItem
        //       {
        //       Text = u.name,
        //       Value = u.id.ToString()
        //       }
        //   );


        //another way to perform action

        ProductVM productVM = new()
            {
            Product = new(),
            CategoryList = _db.Category.GetAll().Select(
            u => new SelectListItem
                {
                Text = u.name,
                Value = u.id.ToString()
                }
            ),
            CoverTypeList = _db.CoverType.GetAll().Select(
           u => new SelectListItem
               {
               Text = u.name,
               Value = u.id.ToString()
               }
           )

            };


        if (id == null || id == 0)
            {
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(productVM);
            //craete product
            }

        else
            {
            //update product
            }


        return View(productVM);
        }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM obj, IFormFile file)
        {



        if (ModelState.IsValid)
            {
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
                {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Images\Products");
                var extention = Path.GetExtension(file.FileName);

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                    {
                    file.CopyTo(fileStreams);
                    }

                obj.Product.ImageURL = @"\Images\Products\" + fileName + extention;
                }



            _db.Product.Add(obj.Product);
            _db.Save();
            TempData["success"] = "Product Created  Succesfully!!";
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

    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
        {
        var ProductList = _db.Product.GetAll();
        return Json(ProductList);
        //  return Json(new {data= ProductList });

        }
    #endregion
    }

