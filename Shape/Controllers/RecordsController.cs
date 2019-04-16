using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Shape.Models;

namespace Shape.Controllers
{
    public class RecordsController : Controller
    {
        private RecordsDbContext db = new RecordsDbContext();
       // enum Mon { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        //enum Year { 2018,2019};

        // GET: Records
        public ActionResult Index(string Months, string Years)
        {
            var mon = new List<string>() { "1","2","3","4","5","6","7","8","9","10","11","12"};
            //var mon = monnum.ToString();
            var years = new List<string>() { "2018", "2019" };
            ViewBag.Months =new SelectList(mon);
            ViewBag.Years = new SelectList(years);
            IQueryable<Record> allRecords = from m in db.Records
                             orderby m.RecordDate descending
                             select m ;
           
            Debug.WriteLine(DateTime.Now.Year.ToString());
            if (!String.IsNullOrEmpty(Years))
            {
                //Debug.WriteLine(Years);
                allRecords = allRecords.Where(s => s.RecordDate.Year.ToString() == Years);
            }
            if (!String.IsNullOrEmpty(Months))
            {
                //Debug.WriteLine(Months);
                allRecords = allRecords.Where(x => x.RecordDate.Month.ToString() == Months);
            }


            return View(allRecords);
        }

        //GET /Records/Chart
        public ActionResult Chart()
        {
            //var records = from m in db.Records select m;
            new Chart(width: 800, height: 300).AddSeries(
                chartType: "Line",
                xValue: from m in db.Records select m.RecordDate,
                yValues: from m in db.Records select m.Weight
                ).Write("png");
            return View();
        }




        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RecordDate,Weight,Waist")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RecordDate,Weight,Waist")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
