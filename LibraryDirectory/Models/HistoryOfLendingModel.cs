using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryDirectory.Models
{
    public class HistoryOfLendingModel
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int UniqueBookId { get; set; }
        public DateTime BookLentOn { get; set; }
        public DateTime BookReturnedOn { get; set; }
    }
}