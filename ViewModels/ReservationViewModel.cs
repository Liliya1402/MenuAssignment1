using MenuAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment.ViewModels
{
    public class ReservationViewModel
    {
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public List<MenuItem> MenuItems { set; get; }

    }
}
