using Microsoft.EntityFrameworkCore;
using rainbow_unicorn.Data.Mappings;

namespace rainbow_unicorn.Data;

public class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    // Creates database tables
    // Degree points to the Degree.cs in models, Degrees refer to the table name in DB
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Solution> Solutions { get; set; }
    public DbSet<Feature> Features { get; set; }
    
    public DbSet<SolutionCustomer> SolutionCustomers { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<UserPayment> UserPayments { get; set; }
    public DbSet<UserPurchase> UserPurchases { get; set; }
    public DbSet<CustomerStock> CustomerStocks { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.UseIdentityColumns();
        
        var customerMap = new CustomerMap(builder.Entity<Customer>());
        builder.Entity<Customer>();
        
        var creditCardMap = new CreditCardMap(builder.Entity<CreditCard>());
        builder.Entity<CreditCard>();
        
        var stockMap = new StockMap(builder.Entity<Stock>());
        builder.Entity<Stock>();
        
        var solutionCustomerMap = new SolutionCustomerMap(builder.Entity<SolutionCustomer>());
        builder.Entity<SolutionCustomer>();
        
        var userMap = new UserMap(builder.Entity<User>());
        builder.Entity<User>();
        
        var userPurchaseMap = new UserPurchaseMap(builder.Entity<UserPurchase>());
        builder.Entity<UserPurchase>();
        
        var userPaymentMap = new UserPaymentMap(builder.Entity<UserPayment>());
        builder.Entity<UserPayment>();
        
        var customerStockMap = new CustomerStockMap(builder.Entity<CustomerStock>());
        builder.Entity<CustomerStock>();
    }
}