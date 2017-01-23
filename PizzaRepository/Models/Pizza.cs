using System;
using System.Collections.Generic;
using System.Linq;


namespace PizzaSharp.Models
{
    public class Pizza : Product
    {
        private int _baseSmall = 25;
        private int _baseMedium = 35;
        private int _baseBig = 45;

        private double _smallModifier = 0.8;
        private double _mediumModifier = 1;
        private double _bigModifier = 1.2;

        public Guid User { get; set; }
        public bool IsCreatedByAdmin { get; set; }
        public virtual List<Ingredient> Ingredients {get; set;}
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public int GetRating()
        {
            int rating = 0;
            double sumOfRatings = 0;

            if (Reviews == null || !Reviews.Any())
                return 0;

            foreach (Review review in Reviews)
                sumOfRatings += review.Grade;

            rating = Convert.ToInt32(sumOfRatings / Reviews.Count());

            return rating;
        }

        public void UpdateValues(Pizza other)
        {
            if(ProductId != other.ProductId  ||  User != other.User)
            {
                throw new ArgumentException("Not allowed to update given pizza!");
            }

            Ingredients = other.Ingredients;

            base.UpdateValues(other);
        }

        public void CalculatePrices()
        {
            int ingredientPrice = Ingredients.Sum(ingredient => ingredient.Price);

            PriceSmall = _baseSmall + (int)(_smallModifier * ingredientPrice);
            PriceMedium = _baseMedium + (int)(_mediumModifier * ingredientPrice);
            PriceBig = _baseBig + (int)(_bigModifier * ingredientPrice);
        }

        public int CommentCount()
        {
            return Comments?.Count ?? 0;
        }
    }
}