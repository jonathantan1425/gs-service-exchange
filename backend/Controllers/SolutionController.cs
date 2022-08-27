using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rainbow_unicorn.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace rainbow_unicorn.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "rainbow-unicorn-customer")]
    public class SolutionController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public SolutionController(DataContext context)
        {
            _context = context;
        }


        // Get all Solutions
        [HttpGet]
        [SwaggerOperation(Summary = "Get all existing solutions by GS")]
        public async Task<ActionResult<List<Solution>>> Get()
        {
            return Ok(await _context.Solutions
                .Include(f=>f.Features)
                .ToListAsync());
        }


        // Get a Solution based on a given SolutionId
        [HttpGet("{solutionId}")]
        [SwaggerOperation(Summary = "Retrieve solution details base on given ID")]
        public async Task<ActionResult<List<Solution>>> Get(int solutionId)
        {
            var solution = await _context.Solutions
                .Include(f=>f.Features)
                .FirstOrDefaultAsync(s => s.SolutionId == solutionId);
            if (solution == null)
                return BadRequest("Solution not found.");
            return Ok(solution);
        }
        
        [HttpGet("AllId")]
        [SwaggerOperation(Summary = "Returns an array of all solution IDs")]
        public async Task<ActionResult<List<Solution>>> GetSolutionId()
        {
            return Ok(await _context.Solutions
                .Select(s => s.SolutionId)
                .ToListAsync());
        }
    }
}
