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
using MelbournePrimeMinisters.Models;

namespace MelbournePrimeMinisters.Controllers.Api
{
    public class PrimeMinistersController : ApiController
    {
        private MelbournePrimeMinistersContext db = new MelbournePrimeMinistersContext();

        // GET: api/PrimeMinisters
        public IQueryable<PrimeMinister> GetPrimeMinisters()
        {
            return db.PrimeMinisters.Include(p => p.PoliticalParty);
        }

        // GET: api/PrimeMinisters/5
        [ResponseType(typeof(PrimeMinister))]
        public async Task<IHttpActionResult> GetPrimeMinister(int id)
        {
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            if (primeMinister == null)
            {
                return NotFound();
            }

            return Ok(primeMinister);
        }

        // PUT: api/PrimeMinisters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrimeMinister(int id, PrimeMinister primeMinister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primeMinister.Id)
            {
                return BadRequest();
            }

            db.Entry(primeMinister).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimeMinisterExists(id))
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

        // POST: api/PrimeMinisters
        [ResponseType(typeof(PrimeMinister))]
        public async Task<IHttpActionResult> PostPrimeMinister(PrimeMinister primeMinister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimeMinisters.Add(primeMinister);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = primeMinister.Id }, primeMinister);
        }

        // DELETE: api/PrimeMinisters/5
        [ResponseType(typeof(PrimeMinister))]
        public async Task<IHttpActionResult> DeletePrimeMinister(int id)
        {
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            if (primeMinister == null)
            {
                return NotFound();
            }

            db.PrimeMinisters.Remove(primeMinister);
            await db.SaveChangesAsync();

            return Ok(primeMinister);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimeMinisterExists(int id)
        {
            return db.PrimeMinisters.Count(e => e.Id == id) > 0;
        }
    }
}