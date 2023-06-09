using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Controllers for containing the flow control logic
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor for ProductsController
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// getter for JsonFileProductService 
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// When called, gets all data from products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Applies partial modifications rating to the product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// Gets and sets product id to system generated id
        /// and contains getter setter for rating
        /// </summary>
        public class RatingRequest
        {
            /// <summary>
            /// Getter setter for ProductId
            /// </summary>
            public string ProductId { get; set; } = System.Guid.NewGuid().ToString();

            /// <summary>
            /// Getter setter for rating
            /// </summary>
            public int Rating { get; set; }
        }
    }
}