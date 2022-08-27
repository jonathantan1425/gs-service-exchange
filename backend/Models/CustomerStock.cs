using System.ComponentModel.DataAnnotations.Schema;

namespace rainbow_unicorn;

public class CustomerStock
{
    public CustomerStock()
    {
    }

    public CustomerStock(string ticker, string customerName, string interval)
    {
        Ticker = ticker;
        CustomerName = customerName;
        Interval = interval;
    }

    [ForeignKey("Stock")]
    public string Ticker { get; set; } = string.Empty;
    
    [ForeignKey("Customer")]
    public string CustomerName { get; set; }
    public string Interval { get; set; }
    
    public virtual Customer? Customer { get; set; }
 
    public virtual Stock? Stock { get; set; }
}