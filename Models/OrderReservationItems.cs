using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment.Models
{
  
    public class OrderReservationItems
    {
     
       public int Id { set; get; }
        public int ReservationId { set; get; }
        public int  MenuItemId { set; get; }
        public virtual Reservation Reservation { get; set; }
        public MenuItem MenuItem { set; get; }

        

    }
}