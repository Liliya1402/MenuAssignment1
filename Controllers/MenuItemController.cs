using MenuAssignment.Data;
using MenuAssignment.Models;
using MenuAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MenuAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {

        private readonly AppDbContext _dbc = new AppDbContext();
        private readonly ILogger<MenuItemController> _logger;

        public MenuItemController(ILogger<MenuItemController> logger)
        {
            _logger = logger;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            _logger.LogInformation("The Get MenuItem was invoked!");
            return _dbc.MenuItems.ToList();
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)

        {
            _logger.LogInformation("The Get by id MenuItem was invoked!");

            return _dbc.MenuItems.Find(id);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public void Post([FromBody] MenuItemModel value)
        {
            _logger.LogInformation("The Post MenuItem was invoked!");
            int newid = _dbc.MenuItems.Last().Id + 1;

            MenuItem me = new MenuItem
            {
                Id = newid,
                Name = value.Name,
                Price = value.Price,
               
            };

            _dbc.MenuItems.Add(me);
            _dbc.SaveChanges();


        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuItem value)
        {
            _logger.LogInformation("The Get by ID  MenuItem was invoked!");
            MenuItem me = _dbc.MenuItems.Where(m => m.Id == id)
                                       .FirstOrDefault();

            if (me != null)
            {
                me.Name = value.Name;
                me.Price = value.Price;

                _dbc.SaveChanges();
            }

        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("The Delete  was invoked!");
            MenuItem me = _dbc.MenuItems.Find(id);
            _dbc.MenuItems.Remove(me);
            _dbc.SaveChanges();

        }
    }
}
