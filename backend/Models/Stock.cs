namespace rainbow_unicorn;

public class Stock
{
    public Stock()
    {
    }

    public Stock(string ticker, string stockName)
    {
        Ticker = ticker;
        StockName = stockName;
    }

    public string Ticker { get; set; } = string.Empty;
    public string StockName { get; set; }
    
    public ICollection<CustomerStock>? CustomerStocks { get; set; }
    
}