using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> productList = new List<Product>();

        [HttpGet("/product")]
        public IActionResult Products()
        {
            return View(productList);
        }

        [HttpPost("/product")]
        public IActionResult AddProduct(Product product)
        {
            product.Id = productList.Count + 1;
            productList.Add(product);
            return View("Products", productList);
        }

        [HttpGet("/product/add")]
        public IActionResult AddProduct()
        {
            return View();
        }

        // UPDATE - Show Edit
        [HttpGet("/product/edit/{id}")]
        public IActionResult EditProduct(int id)
        {
            var product = productList.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // UPDATE - Save Edit
        [HttpPost("/product/edit/{id}")]
        public IActionResult EditProduct(int id, Product updatedProduct)
        {
            var product = productList.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return RedirectToAction("Products");
        }


        [HttpPost("/product/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = productList.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                productList.Remove(product);
            }

            return RedirectToAction("Products");
        }

    }
}
