using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MelbournePrimeMinisters.Models;

namespace MelbournePrimeMinisters.Controllers
{
    public class PrimeMinistersController : Controller
    {
        private MelbournePrimeMinistersContext db = new MelbournePrimeMinistersContext();

        // GET: PrimeMinisters
        public async Task<ActionResult> Index()
        {
            var primeMinisters = db.PrimeMinisters.Include(p => p.PoliticalParty);
            return View(await primeMinisters.ToListAsync());
        }

        // GET: PrimeMinisters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            if (primeMinister == null)
            {
                return HttpNotFound();
            }
            return View(primeMinister);
        }

        // GET: PrimeMinisters/Create
        public ActionResult Create()
        {
            ViewBag.PoliticalPartyId = new SelectList(db.PoliticalParties, "Id", "PartyName");
            return View();
        }

        // POST: PrimeMinisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Year,PoliticalPartyId")] PrimeMinister primeMinister)
        {
            if (ModelState.IsValid)
            {
                db.PrimeMinisters.Add(primeMinister);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PoliticalPartyId = new SelectList(db.PoliticalParties, "Id", "PartyName", primeMinister.PoliticalPartyId);
            return View(primeMinister);
        }

        // GET: PrimeMinisters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            if (primeMinister == null)
            {
                return HttpNotFound();
            }
            ViewBag.PoliticalPartyId = new SelectList(db.PoliticalParties, "Id", "PartyName", primeMinister.PoliticalPartyId);
            return View(primeMinister);
        }

        // POST: PrimeMinisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Year,PoliticalPartyId")] PrimeMinister primeMinister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primeMinister).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PoliticalPartyId = new SelectList(db.PoliticalParties, "Id", "PartyName", primeMinister.PoliticalPartyId);
            return View(primeMinister);
        }

        // GET: PrimeMinisters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            if (primeMinister == null)
            {
                return HttpNotFound();
            }
            return View(primeMinister);
        }

        // POST: PrimeMinisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PrimeMinister primeMinister = await db.PrimeMinisters.FindAsync(id);
            db.PrimeMinisters.Remove(primeMinister);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
