using MenuAssignment.Data;
using MenuAssignment.Models;
using MenuAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//
namespace MenuAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly AppDbContext _dbc = new AppDbContext();
        private readonly ILogger<MenuItemController> _logger;

        public ReservationController(ILogger<MenuItemController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<ReservationViewModel> Get()
        {
            _logger.LogInformation("The Get ReservationViewModel was invoked!");
            List<ReservationViewModel> list = _dbc
                .OrderReservations
                .Select(o => o.Reservation)
                .Distinct()
                .Select(o => new ReservationViewModel
                {
                    Name = o.Name,
                    Date = o.Date,
                    MenuItems = _dbc
                        .OrderReservations
                        .Where(rmi => rmi.ReservationId == o.Id)
                        .Select(rmi => rmi.MenuItem)
                        .ToList()
                })
                .ToList();

            return list;
        }



        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public ReservationViewModel Get(int id)
        {
            _logger.LogInformation("The Get by ID ReservationViewModel was invoked!");
            ReservationViewModel order = _dbc
                .OrderReservations
                .Where(rmi => rmi.ReservationId == id)
                .Select(r => r.Reservation)
                .Select(r => new ReservationViewModel
                {
                    Name = r.Name,
                    Date = r.Date,
                    MenuItems = _dbc
                        .OrderReservations
                        .Where(rmi => rmi.ReservationId == r.Id)
                        .Select(rmi => rmi.MenuItem)
                        .ToList()
                })
                .FirstOrDefault();

            return order;
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] ReservationViewModel value)
        {
            _logger.LogInformation("The Post  ReservationViewModelwas invoked!");
            int id = _dbc.Reservations.Last().Id + 1;

            Reservation  order = new Reservation
            {
                Id = id,
                Name = value.Name,
                Date = value.Date
            };
            _dbc.Reservations.Add(order);

            foreach (MenuItem mi in value.MenuItems)
            {
                OrderReservationItems rmi = new OrderReservationItems
                {
                    MenuItemId = mi.Id,
                    ReservationId = order.Id
                };
                _dbc.OrderReservations.Add(rmi);
            }

            _dbc.SaveChanges();

        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReservationViewModel value)
        {
            _logger.LogInformation("The Put ReservationViewModel was invoked!");
            Reservation reser = _dbc
                .Reservations
                .Where(r => r.Id == id)
                .FirstOrDefault();

            if (reser != null)
            {
                reser.Name = value.Name;
                reser.Date = value.Date;

                var rangeMI = _dbc.OrderReservations
                    .Where(rmi => rmi.ReservationId == id).ToList();
                _dbc.OrderReservations.RemoveRange(rangeMI);

                foreach (MenuItem mi in value.MenuItems)
                {
                    OrderReservationItems orderMi = new OrderReservationItems
                    {
                        MenuItemId = mi.Id,
                        ReservationId = id
                    };
                    _dbc.OrderReservations.Add(orderMi);
                }

                _dbc.SaveChanges();

            }
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("The Delete was invoked!");
            Reservation reservationToDelete = _dbc.Reservations.Find(id);

            if (reservationToDelete != null)
            {
                var rangeMI = _dbc.OrderReservations
                    .Where(rmi => rmi.ReservationId == id).ToList();

                _dbc.OrderReservations.RemoveRange(rangeMI);

                _dbc.Reservations.Remove(reservationToDelete);

                _dbc.SaveChanges();

            }
        }
    }
}
