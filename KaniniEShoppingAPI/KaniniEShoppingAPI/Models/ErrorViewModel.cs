// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KaniniEShoppingAPI.Models
{
    /// <summary>
    /// Class ErrorViewModel.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or Sets Request Id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether returns the statuswhen request id is passed.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}