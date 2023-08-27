using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        public MovieController()
        {
            _context = new MovieContext();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {

                var mv = _context.Movies.Find(id);
                if (mv == null)
                {
                    return NotFound();
                }
                return Ok(mv);
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(Movie mv)
        {
            var seacrh = new Movie
            {

               
                Decription = mv.Decription,
                Name = mv.Name,
                Time = mv.Time

            };

            _context.Add(seacrh);
            
            return Ok(new
            {
                Success = true,
                Data = seacrh
            });

            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Movie mvEdit)
        {
            try
            {
           
                var mv = _context.Movies.SingleOrDefault(c => c.Id == Guid.Parse(id));
                if (mv == null)
                {
                    return NotFound();
                }
                if (id != mv.Id.ToString())
                {
                    return BadRequest();
                }
            
                mv.Decription = mvEdit.Decription;
                mv.Name = mvEdit.Time;
                return Ok();
            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {

            try
            {
               
                var mv = _context.Movies.SingleOrDefault(c => c.Id == Guid.Parse(id));
                if (mv == null)
                {
                    return NotFound();
                }

                _context.Remove(mv);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
