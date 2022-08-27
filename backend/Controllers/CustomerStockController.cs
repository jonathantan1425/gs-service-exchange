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
    
    public class CustomerStockController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public CustomerStockController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("{ticker}/{customerName}/{interval}/{stockName}")]
        [SwaggerOperation("Adds a stock to customer dashboard.")]
        public async Task<ActionResult<List<CustomerStock>>> AddStockToDashboard(string ticker, string customerName, string interval, string stockName)
        {
            var customerStock = await _context.CustomerStocks
                .FirstOrDefaultAsync(cs => (cs.Ticker == ticker) && (cs.CustomerName == customerName));
            if (customerStock != null)
                return Conflict("Stock already on customer's dashboard.");
            
            customerStock = new CustomerStock(ticker, customerName, interval);
            var stock =  await _context.Stocks
                .FirstOrDefaultAsync(b=>b.Ticker == ticker);
            if (stock == null)
            {
                var newStock = new Stock(ticker, stockName);
                await _context.Stocks.AddAsync(newStock);
            }
            await _context.CustomerStocks.AddAsync(customerStock);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.CustomerStocks.ToListAsync());
        }
        
        [HttpPut]
        [SwaggerOperation("Update interval for a customer's stock.")]
        public async Task<ActionResult<List<CustomerStock>>> UpdateInterval(CustomerStock customerStock)
        {
            var record = await _context.CustomerStocks
                .FirstOrDefaultAsync(cs => cs.Ticker == customerStock.Ticker & cs.CustomerName == customerStock.CustomerName);
            if (record == null)
                return BadRequest("Stock not found.");
            
            record.Interval = customerStock.Interval;
            await _context.SaveChangesAsync();
            
            return Ok(await _context.CustomerStocks.ToListAsync());
        }
        
        [HttpDelete("{ticker}/{customerName}")]
        [SwaggerOperation("Remove stock from the customer's dashboard.")]
        public async Task<ActionResult<List<CustomerStock>>> DeleteBasket(string ticker, string customerName)
        {
            var customerStock = await _context.CustomerStocks
                .FirstOrDefaultAsync(cs => (cs.Ticker == ticker) && (cs.CustomerName == customerName));
            if (customerStock == null)
                return BadRequest("Stock not found.");

            _context.CustomerStocks.Remove(customerStock);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.CustomerStocks.ToListAsync());
        }
    }
}