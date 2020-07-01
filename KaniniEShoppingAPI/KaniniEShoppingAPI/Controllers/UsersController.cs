// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Collections.Generic;
    using KaniniEShoppingAPI.User;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// UserController Class.
    /// </summary>
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepo userbl;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="bl">Param from Interface business layer.</param>
        public UsersController(IUserRepo bl)
        {
            this.userbl = bl;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="userDetails">Register Param from Register model.</param>
        /// <returns>Insert and return interger.</returns>
        [HttpPost]
        [Route("api/[controller]/InsertUsers")]
        public int Post(UserDetails userDetails)
        {
           
            return this.userbl.InsertUser(userDetails);
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="roleNumber">Param1.</param>
        /// <returns>Returns list of Users.</returns>
        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public List<UserDetails> Get(UserDetails roleNumber)
        {
            return this.userbl.GetUserDetails(roleNumber);
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="register">Register Param from Register model.</param>
        /// <returns>boolean status.</returns>
        [HttpDelete]
        [Route("api/[controller]/DeleteUsers")]
        public bool Delete(Register register)
        {
            return this.userbl.DeleteUser(register);
        }
    }
}