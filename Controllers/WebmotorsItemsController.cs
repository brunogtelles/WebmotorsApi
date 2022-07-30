using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebmotorsApi.Models;

namespace WebmotorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebmotorsItemsController : ControllerBase
    {
        private readonly WebmotorsContext _context;

        public WebmotorsItemsController(WebmotorsContext context)
        {
            _context = context;
        }

        // GET: api/WebmotorsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebmotorsItem>>> GetWebmotorsItems()
        {
          if (_context.WebmotorsItems == null)
          {
              return NotFound();
          }
            return await _context.WebmotorsItems.ToListAsync();
        }

        // GET: api/WebmotorsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebmotorsItem>> GetWebmotorsItem(Guid id)
        {
          if (_context.WebmotorsItems == null)
          {
              return NotFound();
          }
            var webmotorsItem = await _context.WebmotorsItems.FindAsync(id);

            if (webmotorsItem == null)
            {
                return NotFound();
            }

            return webmotorsItem;
        }

        // PUT: api/WebmotorsItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebmotorsItem(Guid id, WebmotorsItem webmotorsItem)
        {
            if (id != webmotorsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(webmotorsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebmotorsItemExists(id))
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

        // POST: api/WebmotorsItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebmotorsItem>> PostWebmotorsItem(WebmotorsItem webmotorsItem)
        {
          if (_context.WebmotorsItems == null)
          {
              return Problem("Entity set 'WebmotorsContext.WebmotorsItems'  is null.");
          }
            _context.WebmotorsItems.Add(webmotorsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWebmotorsItem), new { id = webmotorsItem.Id }, webmotorsItem);
        }

        // DELETE: api/WebmotorsItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebmotorsItem(Guid id)
        {
            if (_context.WebmotorsItems == null)
            {
                return NotFound();
            }
            var webmotorsItem = await _context.WebmotorsItems.FindAsync(id);
            if (webmotorsItem == null)
            {
                return NotFound();
            }

            _context.WebmotorsItems.Remove(webmotorsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebmotorsItemExists(Guid id)
        {
            return (_context.WebmotorsItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
