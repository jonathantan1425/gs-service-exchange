using System.ComponentModel.DataAnnotations;

namespace rainbow_unicorn;

public class Customer
{
    public Customer()
    {
    }

    public Customer(string customerName, byte[] passwordHash, byte[] passwordSalt, string fullName, string email)
    {
        CustomerName = customerName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        FullName = fullName;
        Email = email;
    }
    
    [Key]
    public string CustomerName { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<SolutionCustomer>? SolutionCustomers { get; set; }

    public ICollection<CreditCard>? CreditCards { get; set; }
    
    public ICollection<UserPurchase>? UserPurchases { get; set; }
    
    public ICollection<User>? Users { get; set; }
    public ICollection<CustomerStock>? CustomerStocks { get; set; }
}