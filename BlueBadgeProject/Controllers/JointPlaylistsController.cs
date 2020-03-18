using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurTunes.Data;

namespace BlueBadgeProject.Controllers
{
    public class JointPlaylistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JointPlaylists
        public ActionResult Index()
        {
            var jointPlaylists = db.JointPlaylists.Include(j => j.Playlist).Include(j => j.Song);
            return View(jointPlaylists.ToList());
        }

        // GET: JointPlaylists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JointPlaylist jointPlaylist = db.JointPlaylists.Find(id);
            if (jointPlaylist == null)
            {
                return HttpNotFound();
            }
            return View(jointPlaylist);
        }

        // GET: JointPlaylists/Create
        public ActionResult Create()
        {
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistName");
            ViewBag.SongId = new SelectList(db.Songs, "SongId", "ArtistName");
            return View();
        }

        // POST: JointPlaylists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JointId,SongId,PlaylistId")] JointPlaylist jointPlaylist)
        {
            if (ModelState.IsValid)
            {
                db.JointPlaylists.Add(jointPlaylist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistName", jointPlaylist.PlaylistId);
            ViewBag.SongId = new SelectList(db.Songs, "SongId", "ArtistName", jointPlaylist.SongId);
            return View(jointPlaylist);
        }

        // GET: JointPlaylists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JointPlaylist jointPlaylist = db.JointPlaylists.Find(id);
            if (jointPlaylist == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistName", jointPlaylist.PlaylistId);
            ViewBag.SongId = new SelectList(db.Songs, "SongId", "ArtistName", jointPlaylist.SongId);
            return View(jointPlaylist);
        }

        // POST: JointPlaylists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JointId,SongId,PlaylistId")] JointPlaylist jointPlaylist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jointPlaylist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "PlaylistId", "PlaylistName", jointPlaylist.PlaylistId);
            ViewBag.SongId = new SelectList(db.Songs, "SongId", "ArtistName", jointPlaylist.SongId);
            return View(jointPlaylist);
        }

        // GET: JointPlaylists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JointPlaylist jointPlaylist = db.JointPlaylists.Find(id);
            if (jointPlaylist == null)
            {
                return HttpNotFound();
            }
            return View(jointPlaylist);
        }

        // POST: JointPlaylists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JointPlaylist jointPlaylist = db.JointPlaylists.Find(id);
            db.JointPlaylists.Remove(jointPlaylist);
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
