using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryDirectory.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name: ")]
        public string FristName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number: ")]
        public int Phone { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email Address: ")]
        public string Mail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public byte[] Password { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Home address: ")]
        public string Address { get; set; }
        public int CurrentlyLentBooks { get; set; }
        public int AllLentBooks { get; set; }
        public int Privilege { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
        public int AccountBalance { get; set; } //In future for financial penalties for delays in returning books, new features, buying books etc.
    }

    public class LibraryDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<HistoryOfLendingModel> HistoryOfLending { get; set; }
        public DbSet<LentBooksModel> LentBooks { get; set; }
    }
}