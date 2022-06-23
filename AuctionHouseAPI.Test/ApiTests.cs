using System.Net.Http.Json;
using System.Text;
using AuctionHouseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

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

    [TestMethod]
    public async Task GetAuction_ReturnsJson()
    {
        var Model = new Auction
        {
            Auctiontype = AuctionType.Anynomous_Auction,
            BottlingLine = null,
            EndTime = DateTime.Now.AddDays(1),
            StartTime = DateTime.Now,
            Id = Guid.NewGuid(),
            Teams = null
        };
        var JsonString = JsonConvert.SerializeObject(Model);
        await _httpClient.PostAsync(
            requestUri: "api/auctionhouse/Auctions",
            content: new StringContent(JsonString, Encoding.UTF8, "application/json")
        );

        var Response = await _httpClient.GetAsync($"api/auctionhouse/Auctions/{Model.Id}");
        var StringResult = await Response.Content.ReadAsStringAsync();

        Assert.IsTrue(StringResult.ToLower().Equals(JsonString.ToLower()));
    }

    [TestMethod]
    public async Task PutAuction_Returns200()
    {
        var Model = new Auction
        {
            Auctiontype = AuctionType.Anynomous_Auction,
            BottlingLine = null,
            EndTime = DateTime.Now.AddDays(1),
            StartTime = DateTime.Now,
            Id = Guid.NewGuid(),
            Teams = null
        };
        var JsonString = JsonConvert.SerializeObject(Model);
        await _httpClient.PostAsync(
            "api/auctionhouse/Auctions",
            new StringContent(JsonString, Encoding.UTF8, "application/json"));

        Model.Auctiontype = AuctionType.Bidding_Auction;
        JsonString = JsonConvert.SerializeObject(Model);

        await _httpClient.PutAsync(
            $"api/auctionhouse/Auctions/{Model.Id}",
            new StringContent(JsonString, Encoding.UTF8, "application/json")
        );
        
        var Response = await _httpClient.GetAsync($"api/auctionhouse/Auctions/{Model.Id}");
        var StringResult = await Response.Content.ReadAsStringAsync();

        Assert.IsTrue(StringResult.ToLower().Equals(JsonString.ToLower()));
    }
    
    [TestMethod]
    public async Task DeleteAuction_Returns204()
    {
        var Model = new Auction
        {
            Auctiontype = AuctionType.Anynomous_Auction,
            BottlingLine = null,
            EndTime = DateTime.Now.AddDays(1),
            StartTime = DateTime.Now,
            Id = Guid.NewGuid(),
            Teams = null
        };
        var JsonString = JsonConvert.SerializeObject(Model);
        await _httpClient.PostAsync(
            "api/auctionhouse/Auctions",
            new StringContent(JsonString, Encoding.UTF8, "application/json"));

        var Response = await _httpClient.DeleteAsync($"api/auctionhouse/Auctions/{Model.Id}");

        Assert.IsTrue(Response.IsSuccessStatusCode);
    }
}