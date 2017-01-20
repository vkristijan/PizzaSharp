using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    /// <summary>
    /// Representation of allowed actions for a comment.
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// Adds the given Comment to the repository.
        /// </summary>
        /// <param name="comment"> The comment that should be added. </param>
        /// <param name="userId"> The id of the user trying to add the comment. </param>
        void Add(Comment comment, Guid userId);

        Comment Get(Guid commentId, Guid userId);

        /// <summary>
        /// Returns a list of all the comments for the given pizza.
        /// </summary>
        /// <param name="pizzaId">The pizza that we want to get the comments for.</param>
        /// <returns>A list of all the comments.</returns>
        List<Comment> GetAll(Guid pizzaId);
    }
}
