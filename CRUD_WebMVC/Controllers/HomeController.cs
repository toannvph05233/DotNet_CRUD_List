using CRUD_WebMVC.Models;
using CRUD_WebMVC.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_WebMVC.Controllers
{
    public class HomeController : Controller
    {
         List<Product> ListProduct = new List<Product>();
        WriteFile WriteFile = new WriteFile();

        public ActionResult Index()
        {
            ListProduct = WriteFile.Read();
            if(ListProduct.Count == 0)
            {
                ListProduct.Add(new Product(1, "JT", 5));
                ListProduct.Add(new Product(2, "JT", 5));
                ListProduct.Add(new Product(3, "JT", 5));
            }

            WriteFile.Write(ListProduct);

            ViewBag.ListProduct = ListProduct;
            return View();
        }
        public ActionResult Create()
        {        
            return View();
        }
        public ActionResult Delete(int Id)
        {
            ListProduct = WriteFile.Read();
            int index = ListProduct.FindIndex(item => item.Id == Id);
            ListProduct.Remove(ListProduct[index]);
            WriteFile.Write(ListProduct);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            ListProduct = WriteFile.Read();
            ListProduct.Add(product);
            WriteFile.Write(ListProduct);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int Id)
        {
            ListProduct = WriteFile.Read();
            int index = ListProduct.FindIndex(item => item.Id == Id);
            Product product = ListProduct[index];
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ListProduct = WriteFile.Read();
            int index = ListProduct.FindIndex(item => item.Id == product.Id);
            ListProduct[index] = product;
            WriteFile.Write(ListProduct);
            return RedirectToAction("Index","Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
       

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}