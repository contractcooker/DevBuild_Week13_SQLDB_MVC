using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DevBuild_Week13_SQLDB_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DevBuild_Week13_SQLDB_MVC.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration ConfigRoot;
        DAL dal;

        public ProductController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("coffeeDB"));
        }

        public IActionResult Index()
        {
            ViewData["Products"] = dal.GetProductCategories();

            return View("ProductIndex");
        }

        public IActionResult Category(string cat)
        {
            ViewData["Title"] = cat;
            ViewData["Products"] = dal.GetProductsInCategory(cat);

            return View();
        }

        public IActionResult Detail(int id)
        {
            Product prod = dal.GetProductById(id);
            
            if (prod == null)
            {
                return View("NoSuchItem");
            }
            else
            {
                ViewData["Title"] = prod.Name;
                ViewData["Product"] = prod;

                return View();
            }
        }
    }
}