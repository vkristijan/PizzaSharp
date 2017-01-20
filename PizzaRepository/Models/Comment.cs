using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }
        public Pizza Pizza { get; set; }
        public Guid User { get; set; }

        public void UpdateValues(Comment comment)
        {
            if (CommentId != comment.CommentId || Pizza.ProductId != comment.Pizza.ProductId || User != comment.User)
            {
                throw new ArgumentException("Not allowed to update given comment!");
            }

            Text = comment.Text;
        }
    }
}
