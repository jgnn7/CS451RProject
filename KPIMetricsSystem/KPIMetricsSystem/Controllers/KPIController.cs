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
    public class KPIController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /KPI/
        public ActionResult Index()
        {
            return View(db.KPI.ToList());
        }

        // GET: /KPI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPI.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }
        //public ActionResult KPI_List()
        //{
        //    return KPI_List(db.KPI.ToList());
        //}

        //private ActionResult KPI_List(List<KPI> list)
        //{
        //    throw new NotImplementedException();
        //}
        // GET: /KPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KPI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,KPI_Name")] KPI kpi)
        {
            if (ModelState.IsValid)
            {
                db.KPI.Add(kpi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kpi);
        }

        // GET: /KPI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPI.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }

        // POST: /KPI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,KPI_Name")] KPI kpi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kpi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kpi);
        }

        // GET: /KPI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kpi = db.KPI.Find(id);
            if (kpi == null)
            {
                return HttpNotFound();
            }
            return View(kpi);
        }

        // POST: /KPI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KPI kpi = db.KPI.Find(id);
            db.KPI.Remove(kpi);
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
