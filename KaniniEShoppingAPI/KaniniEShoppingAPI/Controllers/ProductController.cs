// <copyright file="ProductController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Collections.Generic;
    using KaniniEShoppingAPI.Product;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class ProductController.
    /// </summary>
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productBl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="bl">bl is passed as param.</param>
        public ProductController(IProductRepo bl)
        {
            this.productBl = bl;
        }

        /// <summary>
        /// Get.
        /// </summary>
        /// <returns>returns product.</returns>
        [HttpGet]
        [Route("api/[controller]/GetProduct")]
        public List<Product> Get()
        {
            return this.productBl.GetProduct();
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="product">product param is passed.</param>
        /// <returns>Insert product and returns lastid.</returns>
        [HttpPost]
        [Route("api/[controller]/AddProduct")]
        public int Post(Product product)
        {
            return this.productBl.InsertProduct(product);
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="product">product param passed.</param>
        /// <returns>Return true if a product is deleted.</returns>
        [HttpDelete]
        [Route("api/[controller]/DeleteProduct")]
        public bool Delete(Product product)
        {
            return this.productBl.DeleteProduct(product);
        }

        /// <summary>
        /// Put Method.
        /// </summary>
        /// <param name="product">product is param passed.</param>
        /// <returns>Return true if product is updated.</returns>
        [HttpPut]
        [Route("api/[controller]/UpdateProduct")]
        public bool Put(Product product)
        {
            return this.productBl.UpdateProduct(product);
        }
    }
}