using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCollection.DAL;
using MusicCollection.Models;

namespace MusicCollection.Controllers
{
    /// <summary>
    /// Controls Band CD window
    /// </summary>
    public class BandCDsController : Controller
    {
        private MusicCollectionContext db = new MusicCollectionContext();

        /// <summary>
        /// Method which generate list in sorted order.
        /// </summary>
        /// <returns>
        /// bandCD list view
        /// </returns>
        public ActionResult Index(string sortOrder,  string searchString)
        {
            ViewBag.NameSortParamA = String.IsNullOrEmpty(sortOrder) ? "AlbumName_desc" : "";
            ViewBag.NameSortParamM = String.IsNullOrEmpty(sortOrder) ? "BandName_desc" : "";

            var bandCDs = from b in db.BandCDs
                           select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                bandCDs = bandCDs.Where(b => b.BandName.Contains(searchString)
                                       || b.AlbumName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "AlbumName_desc":
                    bandCDs = bandCDs.OrderBy(b => b.AlbumName);
                    break;
                case "BandName_desc":
                    bandCDs = bandCDs.OrderBy(b => b.BandName);
                    break;

            }
            return View(bandCDs.ToList());
        }
        /// <summary>
        /// Display details for band CD
        /// </summary>
        /// <returns>
        ///bandCD view
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandCD bandCD = db.BandCDs.Find(id);
            if (bandCD == null)
            {
                return HttpNotFound();
            }
            return View(bandCD);
        }
        /// <summary>
        /// return view of Create
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create new band CD
        /// </summary>
        /// <returns>
        /// BandCD view
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BandCDId,BandName,AlbumName")] BandCD bandCD)
        {
            if (ModelState.IsValid)
            {
                db.BandCDs.Add(bandCD);
                db.SaveChanges();              
                return RedirectToAction("Index");
            }

            return View(bandCD);
        }
        /// <summary>
        /// Edit band CD
        /// </summary>
        /// <returns>
        /// Band CD edited model
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandCD bandCD = db.BandCDs.Find(id);
            if (bandCD == null)
            {
                return HttpNotFound();
            }
            return View(bandCD);
        }
        /// <summary>
        /// Edit band CD
        /// </summary>
        /// <returns>
        /// Band CD edited model
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BandCDId,BandName,AlbumName")] BandCD bandCD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bandCD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bandCD);
        }
        /// <summary>
        /// Delete band CD
        /// </summary>
        /// <returns>
        /// Return band CD to delete
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandCD bandCD = db.BandCDs.Find(id);
            if (bandCD == null)
            {
                return HttpNotFound();
            }
            return View(bandCD);
        }
        /// <summary>
        /// Delete band CD
        /// </summary>
        /// <returns>
        /// Return band CD to delete
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BandCD bandCD = db.BandCDs.Find(id);
            db.BandCDs.Remove(bandCD);
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
