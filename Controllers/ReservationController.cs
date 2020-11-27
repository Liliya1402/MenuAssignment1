using MenuAssignment.Data;
using MenuAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(ILogger<ReservationController> logger)
        {
          // _logger = _logger;

        }

        private readonly AppDbContext _dbc = new AppDbContext();
        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            //_logger.LogInformation("The Get Reservation was invoked!");
          //  _logger.LogWarning("This is Warning!");

            return _dbc.reservations.ToList();

        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return _dbc.reservations.Find(id);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] Reservation value)
        {
            value.id = _dbc.reservations.Last().id+ 1;
            _dbc.reservations.Add(value);
            _dbc.SaveChanges();
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reservation value)

        {
            Reservation re = _dbc.reservations.Where(predicate: r => r.id == id).FirstOrDefault();

            if (re != null)
            {
          
                re.customerId = value.customerId;
                re.Name = value.Name;
                re.Date = value.Date;
                re.MenuItems = value.MenuItems.ToList();

                _dbc.SaveChanges();
            }
        }

    

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            Reservation re = _dbc.reservations.Find(id);
            _dbc.reservations.Remove(re);
            _dbc.SaveChanges();
                

            
        }
    }
}
