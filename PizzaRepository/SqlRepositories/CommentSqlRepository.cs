using System;
using System.Collections.Generic;
using System.Linq;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class CommentSqlRepository : ICommentRepository
    {
        private readonly PizzaDbContext _context;

        public CommentSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment, Guid userId)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            Comment oldReview = Get(comment.Pizza.ProductId, userId);

            if (oldReview == null)
            {
                _context.Comments.Add(comment);
            }
            else
            {
                oldReview.UpdateValues(comment);
            }
            _context.SaveChanges();
        }

        public Comment Get(Guid commentId, Guid userId)
        {
            return _context
                .Comments
                .SingleOrDefault(c => c.CommentId == commentId && c.User == userId);
        }

        public List<Comment> GetAll(Guid pizzaId)
        {
            return _context
                .Comments
                .Where(c => c.Pizza.ProductId == pizzaId)
                .ToList();
        }
    }
}
