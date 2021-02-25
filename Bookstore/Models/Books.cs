using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//EntityFrameworkCore has to deal with Databases on ASP.Net
namespace Bookstore.Models
{
    //making the Books class form 
    public class Books
    {
        [Key]
        [Required]
        public int BookID { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required]

        public string Publisher { get; set; }
        //making the regular expression for the ISBN
        [Required(ErrorMessage = "You must enter a valid ISBN number. XXX-XXXXXXXXXX")]
        [RegularExpression(@"\([0-9]{3})\[-]\([0-9]{10})$")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
