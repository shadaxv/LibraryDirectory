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
    }

    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
    }
}