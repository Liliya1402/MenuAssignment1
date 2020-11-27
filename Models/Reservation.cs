using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment.Models
{
    public class Reservation
    {
       
        public int id { set; get; }


        public int customerId { set; get; }
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public List<MenuItem> MenuItems { set; get; }
    }
}
