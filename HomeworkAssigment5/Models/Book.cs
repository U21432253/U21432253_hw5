using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworkAssigment5.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Author Author { get; set; }
        public Type Type { get; set; }
        public int PageCount { get; set; }
        public int Points { get; set; }
        // Work on the status
        public string Status { get; set; }


    }
}