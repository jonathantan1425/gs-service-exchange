using System.ComponentModel.DataAnnotations;

namespace rainbow_unicorn;

public class Solution
{
    public Solution()
    {
    }
    
    public Solution(int solutionId, string solutiontitle, string organisation, string description, DateTime releasedate, int rating, string category, bool newsolution)
    {
        SolutionId = solutionId;
        SolutionTitle = solutiontitle;
        Organisation = organisation;
        Description = description;
        ReleaseDate = releasedate;
        Rating = rating;
        Category = category;
        New = newsolution;
    }

    [Key]
    public int SolutionId { get; set; }
    public string SolutionTitle { get; set; }
    
    public string Organisation { get; set; }
    
    public string Description { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public int Rating { get; set; }
    
    public string Category { get; set; }
    
    public bool New { get; set; }
    
    public ICollection<Feature>? Features { get; set; }
    public ICollection<SolutionCustomer>? SolutionCustomers { get; set; }


}