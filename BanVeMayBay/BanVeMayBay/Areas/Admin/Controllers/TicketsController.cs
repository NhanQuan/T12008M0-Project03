using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanVeMayBay.Common;
using BanVeMayBay.Models;

namespace BanVeMayBay.Areas.Admin.Controllers
{
    public class TicketsController : BaseController
    {
        private BanVeMayBayDbContext db = new BanVeMayBayDbContext();

        // GET: Admin/Tickets
        public ActionResult Index()
        {
            return View(db.tickets.Where(m=>m.status != 0).ToList());
        }

        // GET: Admin/Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Admin/Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ticket ticket)
        {
            ticket.flightCode = "NB_"+ticket.departure_date;
            ticket.img = "img";
            ticket.sold = 0;
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file;
                file = Request.Files["airline"];
                string filename = file.FileName.ToString();
               // string ExtensionFile = Mystring.GetFileExtension(filename);
               // string namefilenew = Mystring.ToSlug(ticket.departure_date.Year.ToString())+ "." + ExtensionFile;
                var path = Path.Combine(Server.MapPath("~/Public/images/flight"), filename);
                file.SaveAs(path);
                ticket.airline = filename;
                ticket.created_at = DateTime.Now;
                ticket.updated_at = DateTime.Now;
                ticket.created_by = int.Parse(Session["Admin_id"].ToString());
                ticket.updated_by = int.Parse(Session["Admin_id"].ToString());
                ticket.priceSale = ticket.price;
             
                db.tickets.Add(ticket);
                Message.set_flash("Successfully added ticket", "success");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Message.set_flash("More failed tickets", "danger");
            return View("Create");
        }

       
        public ActionResult Status(int id)
        {
            ticket tickets = db.tickets.Find(id);
            tickets.status = (tickets.status == 1) ? 2 : 1;
            db.Entry(tickets).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Status change successful", "success");
            return RedirectToAction("Index");
        }
        //trash
        public ActionResult trash()
        {
            var list = db.tickets.Where(m => m.status == 0).ToList();
            return View("Trash", list);
        }
        [CustomAuthorizeAttribute(RoleID = "ADMIN")]
        public ActionResult Deltrash(int id)
        {
            ticket morder = db.tickets.Find(id);
            morder.status = 0;
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Delete successfully", "success");
            return RedirectToAction("Index");
        }
        [CustomAuthorizeAttribute(RoleID = "ADMIN")]
        public ActionResult Retrash(int id)
        {
            ticket morder = db.tickets.Find(id);
            morder.status = 2;
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Successful recovery", "success");
            return RedirectToAction("trash");
        }
        [CustomAuthorizeAttribute(RoleID = "ADMIN")]
        public ActionResult deleteTrash(int id)
        {
            ticket morder = db.tickets.Find(id);
            db.tickets.Remove(morder);
            db.SaveChanges();
            Message.set_flash("Permanently deleted 1 Order", "success");
            return RedirectToAction("trash");
        }


    }
}
