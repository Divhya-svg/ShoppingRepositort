// <copyright file="FeedbackController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Controllers
{
    using KaniniEShoppingAPI.Feedback;
    using KaniniEShoppingAPI.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Feedback Controller.
    /// </summary>
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepo feedbackRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackController"/> class.
        /// Constructor Injection.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public FeedbackController(IFeedbackRepo repo)
        {
            this.feedbackRepo = repo;
        }

        /// <summary>
        /// Post Method.
        /// </summary>
        /// <param name="feedback">Param1.</param>
        /// <returns>Retuns integer.</returns>
        [HttpPost]
        [Route("api/[controller]/GiveFeedback")]
        public int Post(Feedback feedback)
        {
            return this.feedbackRepo.InsertFeedback(feedback);
        }
    }
}