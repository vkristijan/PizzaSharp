using System;
using System.Collections.Generic;
using System.Linq;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class ReviewSqlRepository : IReviewRepository
    {
        private readonly PizzaDbContext _context;

        public ReviewSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public void Add(Review review, Guid userId)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            Review oldReview = Get(review.Pizza.ProductId, userId);

            if (oldReview == null)
            {
                _context.Reviews.Add(review);
            }
            else
            {
                oldReview.UpdateValues(review);
            }
            _context.SaveChanges();

        }

        public Review Get(Guid pizzaId, Guid userId)
        {
            return _context
                .Reviews
                .SingleOrDefault(r => r.Pizza.ProductId == pizzaId && r.User == userId);
        }

        public List<Review> GetAll(Guid pizzaId)
        {
            return _context
                .Reviews
                .Where(r => r.Pizza.ProductId == pizzaId)
                .ToList();
        }
    }
}