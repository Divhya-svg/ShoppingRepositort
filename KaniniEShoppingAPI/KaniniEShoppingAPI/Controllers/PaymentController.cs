// <copyright file="PaymentController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using KaniniEShoppingAPI.Payment;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Payment Controller.
    /// </summary>
    [ApiController]
    public class PaymentController : Controller
    {
        /// <summary>
        /// Class Payment Controller.
        /// </summary>
        private readonly IPaymentRepo paymentsBl;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentController"/> class.
        /// Construtor injection.
        /// </summary>
        /// <param name="bl">From interface Payment business layer.</param>
        public PaymentController(IPaymentRepo bl)
        {
            this.paymentsBl = bl;
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="payment">payment refered Model Payment.</param>
        /// <returns>payment.</returns>
        [HttpPost]
        [Route("api/[controller]/MakePaymentType")]
        public int Post(Payment payment)
        {
            return this.paymentsBl.InsertPaymentType(payment);
        }

        /// <summary>
        /// Insert Method.
        /// </summary>
        /// <param name="payment">Param1.</param>
        /// <returns>Returns integer.</returns>
        [HttpPost]
        [Route("api/[controller]/MakePayment")]
        public int Put(Payment payment)
        {
            return this.paymentsBl.InsertPayment(payment);
        }
    }
}