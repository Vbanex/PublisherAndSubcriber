using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherAndSubcriber.Data;
using PublisherAndSubcriber.Models;

namespace PublisherAndSubcriber.Controllers
{
   // [Route("api/[controller]")]
   [Route("publish/topic1")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly SubscriberContext _context;

        public SubscribesController(SubscriberContext context)
        {
            _context = context;
        }

        // GET: api/Subscribes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscribe>>> GetSubscribes()
        {
            return await _context.Subscribes.ToListAsync();
        }

        // GET: api/Subscribes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscribe>> GetSubscribe(long id)
        {
            var subscribe = await _context.Subscribes.FindAsync(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            return subscribe;
        }

        // PUT: api/Subscribes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscribe(long id, Subscribe subscribe)
        {
            if (id != subscribe.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribeExists(id))
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

        // POST: api/Subscribes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscribe>> PostSubscribe(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            await _context.SaveChangesAsync();
            
          Publisher publisher = new Publisher();
          publisher.Message = subscribe.msg;
          string Url1 = "http://localhost:9000/test1";
          Subscribers subscribers1 = new Subscribers(publisher, Url1);

          string Url2 = "http://localhost:9000/test2";
          Subscribers subscribers2 = new Subscribers(publisher, Url2);

            publisher.Subscribe(subscribers1);
            publisher.Subscribe(subscribers2);

            return Ok(publisher.NotifySubscriberObservers());

           // return CreatedAtAction("GetSubscribe", new { id = subscribe.Id }, subscribe);
        }

        // DELETE: api/Subscribes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(long id)
        {
            var subscribe = await _context.Subscribes.FindAsync(id);
            if (subscribe == null)
            {
                return NotFound();
            }

            _context.Subscribes.Remove(subscribe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscribeExists(long id)
        {
            return _context.Subscribes.Any(e => e.Id == id);
        }
    }
}
