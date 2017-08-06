﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryDirectory.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public string Cover { get; set; }
        public int AvailableBooks { get; set; }
        public int AllBooks { get; set; }
    }

    public class BookDbContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
    }
}