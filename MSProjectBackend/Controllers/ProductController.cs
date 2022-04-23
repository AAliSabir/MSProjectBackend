using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy"), Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _productService.GetAllProducts());
        }

        //[HttpPost]
        //[Route("AddCategory")]
        //public int AddCategory(Category category)
        //{
        //    categoryService.AddCategory(category);
        //    int lastID = categoryService.GetLatestCategoryID();

        //    return lastID;
        //}

        //[HttpGet("{id}")]
        //[Route("GetCategoryById")]
        //public ActionResult<Category> GetCategoryById([FromQuery]int categoryId)
        //{
        //    return categoryService.GetCategoryById(categoryId);
        //}

        //[HttpGet]
        //[Route("GetAllCategories")]
        //public ActionResult<List<Category>> GetAllCategories()
        //{
        //    return categoryService.GetAllCategories();
        //}

        //[HttpDelete("{id}")]
        //[Route("DeleteCategory")]
        //public void DeleteCategory([FromQuery]int id)
        //{

        //    itemService.deleteCategoryItems(id);
        //    categoryService.DeleteCategory(id);
        //}

        //[HttpPut("{id}")]
        //[Route("/{id}")]
        //public ActionResult<Category> UpdateCategory(Category category)
        //{
        //    int id = Convert.ToInt32(this.RouteData.Values["id"]);

        //    Category updatedCategory = categoryService.UpdateCategory(id, category);
        //    updatedCategory.id = id;
        //    return updatedCategory;
        //}

    }
}