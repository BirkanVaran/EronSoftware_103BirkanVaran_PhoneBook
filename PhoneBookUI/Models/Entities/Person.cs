using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookUI.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}