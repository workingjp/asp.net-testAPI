using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace practiceweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VampiresController : ControllerBase

    {
        public static List<Vampires> vampires = new List<Vampires> {


            };
        private readonly DataContext _context;
        public VampiresController(DataContext context)
        {
            
                _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Vampires>>> Get()
        {

            return Ok(await _context.Vampires.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Vampires>>> Post(Vampires wolf)
        {
            _context.Vampires.Add(wolf);
            await _context.SaveChangesAsync();
            return Ok(await _context.Vampires.ToListAsync());
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Vampires>>> Delete(int Id)
        {
            var dbVampires = await _context.Vampires.FindAsync(Id);
            if (dbVampires == null)
                return BadRequest("wolf not found");
            _context.Vampires.Remove(dbVampires);
            await _context.SaveChangesAsync(); 
            return Ok(await _context.Vampires.ToListAsync());
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<List<Vampires>>> Get(int Id)
        {
            var dbVampires = await _context.Vampires.FindAsync(Id);
            if (dbVampires == null)

                return BadRequest("wolf not found");
        
            return Ok(dbVampires);
        }
        [HttpPut]

        public async Task<ActionResult<List<Vampires>>> Update(Vampires request)
        {
            var dbVampires = await _context.Vampires.FindAsync(request.Id);
            if(dbVampires == null)
                return NotFound();
            dbVampires.FirstName = request.FirstName;
            dbVampires.LastName = request.LastName;
            dbVampires.Age = request.Age;
            dbVampires.Description = request.Description;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Vampires.ToListAsync());
        }

    }
}
