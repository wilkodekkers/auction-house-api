using Microsoft.AspNetCore.Mvc.Testing;

namespace AuctionHouseAPI.Test;

[TestClass]
public class ApiTests
{
    private readonly HttpClient _httpClient;

    public ApiTests()
    {
        var WebAppFactory = new WebApplicationFactory<Program>();
        _httpClient = WebAppFactory.CreateDefaultClient();
    }
    
    [TestMethod]
    public async Task GetUpcomingAuctions_ReturnsEmptyList()
    {
        var Response = await _httpClient.GetAsync("api/auctionhouse/Auctions/upcoming");
        var StringResult = await Response.Content.ReadAsStringAsync();
        
        Assert.AreEqual("[]", StringResult);
    }
    
    [TestMethod]
    public async Task GetActiveAuctions_ReturnsEmptyList()
    {
        var Response = await _httpClient.GetAsync("api/auctionhouse/Auctions/active");
        var StringResult = await Response.Content.ReadAsStringAsync();
        
        Assert.AreEqual("[]", StringResult);
    }
    
    [TestMethod]
    public async Task GetAuction_ReturnsNotFound()
    {
        var Response = await _httpClient.GetAsync("api/auctionhouse/Auctions/3fa85f64-5717-4562-b3fc-2c963f66afa6");
        var StringResult = await Response.Content.ReadAsStringAsync();
        
        Assert.IsTrue(StringResult.Contains("Not Found"));
    }
}