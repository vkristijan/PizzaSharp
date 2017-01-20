using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    /// <summary>
    /// Representation of allowed actions for a review.
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// Adds the given review to the repository. If the review already exists, it will just be updated.
        /// </summary>
        /// <param name="review">The review that should be added.</param>
        /// <param name="userId">The id of the user trying to add the review.</param>
        void Add(Review review, Guid userId);

        Review Get(Guid pizzaId, Guid userId);

        /// <summary>
        /// Returns a list of all the reviews for a given pizza.
        /// </summary>
        /// <param name="pizzaId">The pizza that we want to get the reviews for.</param>
        /// <returns>A list of all the reviews for the given pizza. </returns>
        List<Review> GetAll(Guid pizzaId);
    }
}
