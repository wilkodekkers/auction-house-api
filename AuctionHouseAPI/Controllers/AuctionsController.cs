#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuctionHouseAPI.Models;

namespace AuctionHouseAPI.Controllers
{
    [Route("api/auctionhouse/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly AuctionContext _context;

        public AuctionsController(AuctionContext context)
        {
            _context = context;
        }

        // GET: api/Auctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auction>>> GetAuctions()
        {
            return await _context.Auctions.ToListAsync();
        }

        // GET: api/Auctions/upcomming
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<Auction>>> GetUpcommingAuctions()
        {
            return await _context.Auctions.Where(auction => auction.StartTime > DateTime.Now).ToListAsync();
        }

        // GET: api/Auctions/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Auction>>> GetActiveAuctions()
        {
            return await _context.Auctions.Where(auction => auction.StartTime < DateTime.Now && auction.EndTime > DateTime.Now).ToListAsync();
        }


        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auction>> GetAuction(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            return auction;
        }

        // PUT: api/Auctions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuction(Guid id, Auction auction)
        {
            if (id != auction.Id)
            {
                return BadRequest();
            }

            _context.Entry(auction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Auctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auction>> PostAuction(Auction auction)
        {
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuction", new { id = auction.Id }, auction);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }

            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuctionExists(Guid id)
        {
            return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
