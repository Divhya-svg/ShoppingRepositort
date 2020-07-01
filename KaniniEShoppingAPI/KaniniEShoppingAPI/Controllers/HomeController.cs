// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Diagnostics;
    using KaniniEShoppingAPI.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Home Controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Method Index.
        /// </summary>
        /// <returns>View.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Method Privacy.
        /// </summary>
        /// <returns>View.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Method Error.
        /// </summary>
        /// <returns>View .</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
