// <copyright file="WishListController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Collections.Generic;
    using KaniniEShoppingAPI.WishList;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// WishList controller.
    /// </summary>
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListRepo wishListBl;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishListController"/> class.
        /// Contructor injection.
        /// </summary>
        /// <param name="bl">Parameter from interface of Wishlist business layer.</param>
        public WishListController(IWishListRepo bl)
        {
            this.wishListBl = bl;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="wishList">Parameter from WishList model.</param>
        /// <returns>Returns integer.</returns>
        [HttpPost]
        [Route("api/[controller]/InsertWishList")]
        public int Post(WishList wishList)
        {
            return this.wishListBl.InsertIntoWishList(wishList);
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <returns>Return Products from wishList.</returns>
        [HttpGet]
        [Route("api/[controller]/GetWishList")]
        public List<WishList> Get(WishList userId)
        {
            return this.wishListBl.GetWishList(userId);
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="wishList">wishList reference from Model.</param>
        /// <returns>boolean status.</returns>
        [HttpDelete]
        [Route("api/[controller]/RemoveProductsFromWishList")]
        public bool Delete(WishList wishList)
        {
            return this.wishListBl.RemoveFromWishList(wishList);
        }
    }
}