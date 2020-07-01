// <copyright file="ShippingController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using KaniniEShoppingAPI.Shipping;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Shipping Controller.
    /// </summary>
    [ApiController]
    public class ShippingController : Controller
    {
        private readonly IShippingRepo shippingRepobl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingController"/> class.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public ShippingController(IShippingRepo repo)
        {
            this.shippingRepobl = repo;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="userAddress">Param1.</param>
        /// <returns>Returns integer.</returns>
        [HttpPost]
        [Route("api/[controller]/AddShipping")]
        public int Post(UserAddress userAddress)
        {
            return this.shippingRepobl.InsertShipDetail(userAddress);
        }
    }
}