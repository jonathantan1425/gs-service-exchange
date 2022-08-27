using System.Text.Json;

namespace rainbow_unicorn.Data;

public class DataSeeder
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _env;

    public DataSeeder(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    
    // private method for Seeder Methods to get the data according to the specified model
    private string GetData(string modelName)
    {
        string rootPath = _env.ContentRootPath;
        string fileName = modelName + ".json";
        string filePath = Path.GetFullPath(Path.Combine(rootPath, "Data", "JsonFiles", fileName));
        using (var r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            return json;
        }
    }
    
    // Seeder Methods for each model

    public void SeedStocks()
    {
        string data = GetData("Stocks");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            var s = new Stock(item["Ticker"], item["stockName"]);
            _db.Stocks.Add(s);
            _db.SaveChanges();
        }
    }

    public void SeedSolutions()
    {
        string data = GetData("Solutions");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int solutionId = int.Parse(item["SolutionId"]);
            int rating = int.Parse(item["Rating"]);
            DateTime releaseDate = DateTime.Parse(item["ReleaseDate"]);
            bool newsolution = bool.Parse(item["New"]);
            var s = new Solution(solutionId,
                                item["SolutionTitle"], 
                                item["Organisation"], 
                                item["Description"], 
                                releaseDate, 
                                rating, 
                                item["Category"],
                                newsolution);
            _db.Solutions.Add(s);
            _db.SaveChanges();
        }
    }

    public void SeedFeatures()
    {
        string data = GetData("Features");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int solutionId = int.Parse(item["SolutionId"]);
            var f = new Feature(item["FeatureTitle"], 
                                item["Description"],
                                solutionId);
            _db.Features.Add(f);
            _db.SaveChanges();
        }
    }
}