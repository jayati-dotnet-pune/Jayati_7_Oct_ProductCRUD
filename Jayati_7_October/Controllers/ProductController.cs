using Jayati_7_October.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jayati_7_October.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product {pid=1, pname="Guitar", pprice = 8000},
            new Product {pid=2, pname="Book", pprice = 200},
            new Product {pid=3, pname="Cheesecake", pprice = 120},
            new Product {pid=4, pname="Bottle", pprice = 180}
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAllProducts()
        {
            return View(products);
        }

        public IActionResult DisplayById(int id)
        {
            var prod = products.FirstOrDefault(p => p.pid == id);
            return View(prod);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            products.Add(product);
            return RedirectToAction("DisplayAllProducts");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.pid == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.pid == updatedProduct.pid);
            if (product != null)
            {
                product.pprice = updatedProduct.pprice;
            }
            return RedirectToAction("DisplayAllProducts");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.pid == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var product = products.FirstOrDefault(p => p.pid == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("DisplayAllProducts");
        }
    }
}
