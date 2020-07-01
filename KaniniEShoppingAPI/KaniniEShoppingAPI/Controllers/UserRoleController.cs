// <copyright file="UserRoleController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using System.Collections.Generic;
    using KaniniEShoppingAPI.UserRole;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// UserRole Controller class.
    /// </summary>
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IRoleRepo roleBl;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleController"/> class.
        /// Contructor injection.
        /// </summary>
        /// <param name="bl">Reference from business layer Interface.</param>
        public UserRoleController(IRoleRepo bl)
        {
            this.roleBl = bl;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="userRoles">Parameter from UserRole Model.</param>
        /// <returns>Returnt int last id.</returns>
        [HttpPost]
        [Route("api/[controller]/InsertUserRole")]
        public int Post(UserRoles userRoles)
        {
            return this.roleBl.InsertUserRole(userRoles);
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="userRoles">Parameter from UserRole Model.</param>
        /// <returns>Boolean status.</returns>
        [HttpDelete]
        [Route("api/[controller]/DeleteUserRole")]
        public bool Delete(UserRoles userRoles)
        {
            return this.roleBl.DeleteUserRole(userRoles);
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <returns>Return List of User Roles.</returns>
        [HttpGet]
        [Route("api/[controller]/GetUserRole")]
        public List<UserRoles> Get()
        {
            return this.roleBl.GetUserRole();
        }

        /// <summary>
        /// Put Method.
        /// </summary>
        /// <param name="userRoles">Parameter from UserRole Model.</param>
        /// <returns>Boolean status.</returns>
        [HttpPut]
        [Route("api/[controller]/PutUserRole")]
        public bool Put(UserRoles userRoles)
        {
            return this.roleBl.UpdateUserRole(userRoles);
        }
    }
}