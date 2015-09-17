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
    public class PoliticalPartiesController : Controller
    {
        private MelbournePrimeMinistersContext db = new MelbournePrimeMinistersContext();

        // GET: PoliticalParties
        public async Task<ActionResult> Index()
        {
            return View(await db.PoliticalParties.ToListAsync());
        }

        // GET: PoliticalParties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            if (politicalParty == null)
            {
                return HttpNotFound();
            }
            return View(politicalParty);
        }

        // GET: PoliticalParties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliticalParties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PartyName")] PoliticalParty politicalParty)
        {
            if (ModelState.IsValid)
            {
                db.PoliticalParties.Add(politicalParty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(politicalParty);
        }

        // GET: PoliticalParties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            if (politicalParty == null)
            {
                return HttpNotFound();
            }
            return View(politicalParty);
        }

        // POST: PoliticalParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PartyName")] PoliticalParty politicalParty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(politicalParty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(politicalParty);
        }

        // GET: PoliticalParties/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            if (politicalParty == null)
            {
                return HttpNotFound();
            }
            return View(politicalParty);
        }

        // POST: PoliticalParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            db.PoliticalParties.Remove(politicalParty);
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
