using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        //class to create a proper cart session with attributes
        //beginning of cart object array
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        //method to add objects
        public virtual void AddItem (Books books, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Books.BookID == books.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        //remove a line
        public virtual void RemoveLine(Books books) =>
            Lines.RemoveAll(x => x.Books.BookID == books.BookID);
        //clear the array
        public virtual void Clear() => Lines.Clear();
        //declaring of variables
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Books.Price * e.Quantity); //Price is hard coded
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }
        }
    }
}
