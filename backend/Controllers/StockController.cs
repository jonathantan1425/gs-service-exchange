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
    public class StockController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public StockController(DataContext context)
        {
            _context = context;
        }


        // Get all Stocks
        [HttpGet]
        [SwaggerOperation("Gets all stocks that is stored in our DB.")]
        public async Task<ActionResult<List<Stock>>> Get()
        {
            return Ok(await _context.Stocks
                .ToListAsync());
        }


        // Get a Stock based on a given Stock Ticker (ticker)
        [HttpGet("{ticker}")]
        [SwaggerOperation("Retrieve a stock base on it's ticker.")]
        public async Task<ActionResult<List<Stock>>> Get(string ticker)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(b => b.Ticker == ticker);
            if (stock == null)
                return BadRequest("Stock not found.");
            return Ok(stock);
        }


        // // Add a new Stock
        // [HttpPost]
        // [ApiExplorerSettings(IgnoreApi = true)]
        // public async Task<ActionResult<List<Stock>>> AddStock(Stock stock)
        // {
        //     await _context.Stocks.AddAsync(stock);
        //     await _context.SaveChangesAsync();
        //
        //     return Ok(await _context.Stocks.ToListAsync());
        // }
        //
        //
        // // Update a Stock fields
        // [HttpPut]
        // [ApiExplorerSettings(IgnoreApi = true)]
        // public async Task<ActionResult<List<Stock>>> UpdateStock(Stock request)
        // {
        //     var stock = await _context.Stocks.FindAsync(request.Ticker);
        //     if (stock == null)
        //         return BadRequest("Stock not found.");
        //
        //     stock.Ticker = request.Ticker;
        //     stock.StockName = request.StockName;
        //
        //     await _context.SaveChangesAsync();
        //
        //     return Ok(await _context.Stocks.ToListAsync());
        // }
        //
        //
        // // Delete a Stock based on a given Stock Ticker (ticker)
        // [HttpDelete("{ticker}")]
        // [ApiExplorerSettings(IgnoreApi = true)]
        // public async Task<ActionResult<List<Stock>>> DeleteStock(int ticker)
        // {
        //     var stock = await _context.Stocks.FindAsync(ticker);
        //     if (stock == null)
        //         return BadRequest("Stock not found.");
        //
        //     _context.Stocks.Remove(stock);
        //     await _context.SaveChangesAsync();
        //
        //     return Ok(await _context.Stocks.ToListAsync());
        // }
        //
        // // Search for a stock based on an input string
        // [HttpGet("search/{text}")]
        // [ApiExplorerSettings(IgnoreApi = true)]
        // public async Task<ActionResult<List<Stock>>> TextSearch(string text)
        // {
        //     if (!string.IsNullOrEmpty(text))
        //     {
        //         return Ok(await _context.Stocks.FullTextSearchQuery(text).ToListAsync());
        //     }
        //     else
        //     {
        //         return Ok(await _context.Stocks.ToListAsync());
        //     }
        // }
    }
}
