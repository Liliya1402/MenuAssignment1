using MenuAssignment.Data;
using MenuAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _dbc = new AppDbContext();
        // GET: api/<MenuItemController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return _dbc.MenuItems.ToList();
              
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return _dbc.MenuItems.Find(id);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public void Post([FromBody] MenuItem value)
        {
            value.Id = _dbc.MenuItems.Last().Id + 1;
            _dbc.MenuItems.Add(value);
            _dbc.SaveChanges();
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuItem value)
        {
            MenuItem mi = _dbc.MenuItems.Where(m => m.Id == id).FirstOrDefault();
            if(mi !=null)
            {
                mi.Name = value.Name;
                mi.Price = value.Price;
                _dbc.SaveChanges();
            }
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MenuItem mi = _dbc.MenuItems.Find(id);
            _dbc.MenuItems.Remove(mi);
            _dbc.SaveChanges();


        }
    }
}
