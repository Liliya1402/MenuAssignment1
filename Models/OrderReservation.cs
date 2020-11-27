using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAssignment.Models
{
    [Table("OrderReservation")]
    public class OrderReservation
    {
        [Key]
        public int orderId { set; get; }
    
        public virtual Reservation Reservation { get; set; }
        List<MenuItem> MenuItems { set; get; }
       
    }
}