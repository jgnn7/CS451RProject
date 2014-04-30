using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KpiMetricsSystem.Models;

namespace AspnetIdentitySample.Controllers
{
    public class kpiController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /kpi/
        public ActionResult Index()
        {
            return View(db.KPIs.ToList());
        }

        // GET: /kpi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPIs.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }

        // GET: /kpi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /kpi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,KPIName")] KPI kpi)
        {
            if (ModelState.IsValid)
            {
                db.KPIs.Add(kpi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kpi);
        }

        // GET: /kpi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPIs.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }

        // POST: /kpi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,KPIName")] KPI kpi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kpi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kpi);
        }

        // GET: /kpi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPIs.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }

        // POST: /kpi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KPI kpi = db.KPIs.Find(id);
            db.KPIs.Remove(kpi);
            db.SaveChanges();
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
