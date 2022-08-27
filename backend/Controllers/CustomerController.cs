using System.ComponentModel;
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
    
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public CustomerController(DataContext context)
        {
            _context = context;
        }
        
        // Get a Customer based on a given customerName
        [HttpGet("getCustomerDetails/{customerName}")]
        [SwaggerOperation(Summary = "Get customer details")]
        public async Task<ActionResult<List<Customer>>> GetGetCustomerDetails(string customerName)

        {
            var customer = await _context.Customers
                .Include(c=>c.SolutionCustomers)
                .FirstOrDefaultAsync(u => u.CustomerName == customerName);
            if (customer == null)
                return BadRequest("Customer not found.");
            return Ok(customer);
        }
        
        [HttpGet("getCustomerSolutions/{customerName}")]
        [SwaggerOperation(Summary = "Get all the solutions that a Customer subscribed to.")]
        // Get all subscriptions to solutions
        public async Task<ActionResult<List<Customer>>> GetCustomerSolutions(string customerName)
        {
            var customer = await _context.Customers
                .Include(c=>c.SolutionCustomers)
                .FirstOrDefaultAsync(u => u.CustomerName == customerName);
            var solutions = customer.SolutionCustomers;
            if (solutions == null)
                return BadRequest("Customer is not subscribed to any solutions.");
            return Ok(solutions);
        }
        
        [HttpGet("getStocks/{customerName}")]
        [SwaggerOperation(Summary = "Get all the stocks that a Customer added to their dashboard.")]
        public async Task<ActionResult<List<Customer>>> GetStocks(string customerName)
        {
            var allRecords = await _context.CustomerStocks
                .Include(c => c.Stock)
                .ToListAsync();
            
            var filtered = new List<string>();
            
            foreach(var record in allRecords)
            {
                if (record.CustomerName == customerName)
                {
                    filtered.Add(record.Stock.Ticker);
                }
            }
            return Ok(filtered);
        }
        
    }
}