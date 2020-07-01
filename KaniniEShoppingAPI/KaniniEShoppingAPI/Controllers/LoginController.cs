// <copyright file="LoginController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using KaniniEShoppingAPI.UserLogin;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Login Controller with Authentication.
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
   // [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Constructor injection.
        /// </summary>
        private readonly IUserLoginRepo loginbl;
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="bl">From ILoginBl.</param>
        /// <param name="configuration">Configuration from Startup.</param>
        public LoginController(IUserLoginRepo bl, IConfiguration configuration)
        {
            this.loginbl = bl;
            this.config = configuration;
        }

        /// <summary>
        /// Authenticate Method.
        /// </summary>
        /// <param name="loginid">Param1.</param>
        /// <param name="password">Param2.</param>
        /// <returns>Return user.</returns>
        [AllowAnonymous]
        [Route("api/Login")]
        [HttpGet]
        public IActionResult Authenticate(string EmailId, string Password)
        {
            string secret = this.config.GetSection("Secret").ToString();

            this.loginbl.Secret = secret;
            var user = this.loginbl.Authenticate(EmailId, " ", Password, secret);

            if (user == null)
            {
                return this.BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                var msg = this.HttpContext.Request.Headers;
                msg.Add("JWT_TOKEN", user);
                return this.Ok(user);
            }
        }

        /// <summary>
        /// GetUsers Method.
        /// </summary>
        /// <returns>View.</returns>
        [Route("Login/getusers")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = this.loginbl.GetAll();
            return this.Ok(users);
        }
    }
}