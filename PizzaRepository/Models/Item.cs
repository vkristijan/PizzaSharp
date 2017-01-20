using System;

namespace PizzaSharp.Models
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        public void UpdateValues(Item item)
        {
            if (item.ItemId != ItemId)
            {
                throw new ArgumentException("Not allowed to change the item!");
            }

            Amount = item.Amount;
            Size = item.Size;
            Product = item.Product;
        }

        public int CalculatePrice()
        {
            int price;

            switch (Size)
            {
                case (int) Sizes.Small:
                    price = Product.PriceSmall;
                    break;
                case (int) Sizes.Medium:
                    price = Product.PriceMedium;
                    break;
                case (int) Sizes.Big:
                    price = Product.PriceBig;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Given size is invalid!");
            }

            return price * Amount;
        }
    }
}
