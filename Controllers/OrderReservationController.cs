using MenuAssignment.Data;
using MenuAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReservationController : ControllerBase
    {
        private readonly ILogger<OrderReservationController> _logger;
        public OrderReservationController(ILogger<OrderReservationController> logger)
        {
            _logger = logger;
        }
        private readonly AppDbContext _dbc = new AppDbContext();
        // GET: api/<OrderResevationController>5
        [HttpGet]
        public IEnumerable<OrderReservation> Get()
        {
            _logger.LogInformation("The Get Order was invoked!");


            //   . Where(o =>o.orderId== customerId)
            //   .include("Reservation")
            //   .theninclude("Menuitems")
            //    .ToList();
            //return _dbc.orderreservations
            return _dbc.orderreservations.ToList();
         } 
        
        // GET api/<OrderReservationController>/5
        [HttpGet("{id}")]
        public OrderReservation Get(int id)
        {
            return _dbc.orderreservations.Find(id);
        }

        // POST api/<OrderReservation>
        [HttpPost]
        public void Post([FromBody] OrderReservation value)
        {
            value.orderId = _dbc.orderreservations.Last().orderId + 1;
            _dbc.orderreservations.Add(value);
            _dbc.SaveChangesAsync();
        }

        // PUT api/<OrderReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderReservation value)
        {
            OrderReservation or = _dbc.orderreservations.Where(o => o.orderId==id).FirstOrDefault();
            if (or !=null)
            {
                or.orderId = value.orderId;
                or.Reservation = value.Reservation;
                _dbc.SaveChanges();
            }

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


            OrderReservation or = _dbc.orderreservations.Find(id);
            _dbc.orderreservations.Remove(or);
            _dbc.SaveChanges();

        }
    }
}
