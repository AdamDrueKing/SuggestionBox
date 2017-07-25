using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuggestionBox.Models;

namespace SuggestionBox.Controllers
{
    public class SuggestionCommentsController : Controller
    {
        private SuggestionBoxContext db = new SuggestionBoxContext();

        // GET: SuggestionComments
        public ActionResult Index()
        {
            return View(db.SuggestionComments.ToList());
        }

        // GET: SuggestionComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionComment suggestionComment = db.SuggestionComments.Find(id);
            if (suggestionComment == null)
            {
                return HttpNotFound();
            }
            return View(suggestionComment);
        }

        // GET: SuggestionComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuggestionComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionComment suggestionComment)
        {
            if (ModelState.IsValid)
            {
                db.SuggestionComments.Add(suggestionComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestionComment);
        }

        // GET: SuggestionComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionComment suggestionComment = db.SuggestionComments.Find(id);
            if (suggestionComment == null)
            {
                return HttpNotFound();
            }
            return View(suggestionComment);
        }

        // POST: SuggestionComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionComment suggestionComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestionComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestionComment);
        }

        // GET: SuggestionComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionComment suggestionComment = db.SuggestionComments.Find(id);
            if (suggestionComment == null)
            {
                return HttpNotFound();
            }
            return View(suggestionComment);
        }

        // POST: SuggestionComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggestionComment suggestionComment = db.SuggestionComments.Find(id);
            db.SuggestionComments.Remove(suggestionComment);
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
