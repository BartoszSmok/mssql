using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSQLDOCKER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TestDbContext _context;


        public WeatherForecastController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TestEntry> Get()
        {
            var entries = _context.TestEntries.ToList();
            return entries;
        }

        [HttpPost]
        public void Post([FromBody] TestEntry entry)
        {
            _context.TestEntries.Add(entry);
            _context.SaveChanges();
        }
    }
}
