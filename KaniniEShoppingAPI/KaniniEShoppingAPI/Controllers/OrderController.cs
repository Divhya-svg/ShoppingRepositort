// <copyright file="OrderController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using KaniniEShoppingAPI.Orders;
using KaniniEShoppingAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace KaniniEShoppingAPI.Controllers
{
    /// <summary>
    /// Order Controller.
    /// </summary>
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrdersRepo bl;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public OrderController(IOrdersRepo repo)
        {
            this.bl = repo;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="order">Param1.</param>
        /// <returns>Returns Integer.</returns>
        [HttpPost]
        [Route("api/[controller]/MakeOrders")]
        public int Post(Order order)
        {
            return this.bl.InsertOrder(order);
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="orderId">Param1.</param>
        /// <returns>Returns List.</returns>
        [HttpGet]
        [Route("api/[controller]/GetOrders")]
        public List<Order> Get(Order orderId)
        {
            return this.bl.GetOrderList(orderId);
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="orderId">Param1.</param>
        /// <returns>Returns Boolean status.</returns>
        [HttpDelete]
        [Route("api/[controller]/CancelOrders")]
        public bool Delete(Order orderId)
        {
            return this.bl.DeleteOrders(orderId);
        }
    }
}