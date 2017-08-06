using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryDirectory.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int CurrentlyLentBooks { get; set; }
        public int AllLentBooks { get; set; }
        public int Privilege { get; set; }
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