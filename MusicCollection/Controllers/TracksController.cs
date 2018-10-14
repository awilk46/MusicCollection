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
    ///Controls Track window
    /// </summary>
    public class TracksController : Controller
    {
        private MusicCollectionContext db = new MusicCollectionContext();

        /// <summary>
        /// Method which return list of tracks.
        /// </summary>
        /// <returns>
        /// Tracks list view
        /// </returns>
        public ActionResult Index()
        {
            var tracks = db.Tracks.Include(t => t.BandCD);
            return View(tracks.ToList());
        }
        /// <summary>
        /// Display details for track
        /// </summary>
        /// <returns>
        ///track view
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }
        /// <summary>
        /// Create new track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.BandCDId = new SelectList(db.BandCDs, "BandCDId", "AlbumName");
            return View();
        }
        /// <summary>
        /// Create new track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,BandCDId,TrackName")] Track track)
        {

            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BandCDId = new SelectList(db.BandCDs, "BandCDId", "AlbumName", track.BandCDId);
            return View(track);
        }
        /// <summary>
        /// Edit track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.BandCDId = new SelectList(db.BandCDs, "BandCDId", "BandName", track.BandCDId);
            return View(track);
        }
        /// <summary>
        /// Edit track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,BandCDId,TrackName")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BandCDId = new SelectList(db.BandCDs, "BandCDId", "BandName", track.BandCDId);
            return View(track);
        }
        /// <summary>
        /// Delete track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }
        /// <summary>
        /// Delete track
        /// </summary>
        /// <returns>
        /// Track view
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
