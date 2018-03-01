using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eStoreServices.Models;

namespace eStoreServices.Controllers
{
    public class PatternsController : ApiController
    {
        private eStoreServicesContext db = new eStoreServicesContext();

        // GET: api/Patterns
        public IQueryable<Pattern> GetPatterns()
        {
            return db.Patterns;
        }

        // GET: api/Patterns/5
        [ResponseType(typeof(Pattern))]
        public async Task<IHttpActionResult> GetPattern(int id)
        {
            Pattern pattern = await db.Patterns.FindAsync(id);
            if (pattern == null)
            {
                return NotFound();
            }

            return Ok(pattern);
        }

        // PUT: api/Patterns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPattern(int id, Pattern pattern)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pattern.Id)
            {
                return BadRequest();
            }

            db.Entry(pattern).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatternExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Patterns
        [ResponseType(typeof(Pattern))]
        public async Task<IHttpActionResult> PostPattern(Pattern pattern)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patterns.Add(pattern);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pattern.Id }, pattern);
        }

        // DELETE: api/Patterns/5
        [ResponseType(typeof(Pattern))]
        public async Task<IHttpActionResult> DeletePattern(int id)
        {
            Pattern pattern = await db.Patterns.FindAsync(id);
            if (pattern == null)
            {
                return NotFound();
            }

            db.Patterns.Remove(pattern);
            await db.SaveChangesAsync();

            return Ok(pattern);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatternExists(int id)
        {
            return db.Patterns.Count(e => e.Id == id) > 0;
        }
    }
}