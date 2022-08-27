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
    public class SolutionCustomerController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public SolutionCustomerController(DataContext context)
        {
            _context = context;
        }


        // Add a new subscription
        [HttpPost]
        [SwaggerOperation("Adds a new subscription for a customer.")]
        public async Task<ActionResult<List<SolutionCustomer>>> AddSubscription(int solutionId, string customerName)
        {
            DateTime datePurchased = DateTime.Now;
            var solutionCustomer = new SolutionCustomer(customerName, solutionId, datePurchased, 0);
            await _context.SolutionCustomers.AddAsync(solutionCustomer);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.SolutionCustomers.ToListAsync());
        }
    }
}