// <copyright file="SearchProductController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Collections.Generic;
    using KaniniEShoppingAPI.ProductSearch;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// SearchProductController.
    /// </summary>
    [ApiController]

    public class SearchProductController : Controller
    {
        private readonly ISearchProduct productBl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProductController"/> class.
        /// </summary>
        /// <param name="bl">Contructor injection of ISearch product from business layer.</param>
        public SearchProductController(ISearchProduct bl)
        {
            this.productBl = bl;
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="productSearch">Parameter from model.</param>
        /// <returns>returns a particular product details.</returns>
        [HttpGet]
        [Route("api/[controller]/Search")]
        public List<Product> Get(Product productSearch)
        {
            List<Product> products = this.productBl.SearchProduct(productSearch);
            return products;
        }
    }
}