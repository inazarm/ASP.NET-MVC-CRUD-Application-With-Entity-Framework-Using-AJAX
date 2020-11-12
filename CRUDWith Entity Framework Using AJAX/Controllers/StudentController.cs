using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWith_Entity_Framework_Using_AJAX.Models;

namespace CRUDWith_Entity_Framework_Using_AJAX.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                List<tbl_Student> studentList = db.tbl_Student.ToList<tbl_Student>();
                return Json(new { data = studentList },
                JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult StoreOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new tbl_Student());
            else
            {
                using (TestDBEntities db = new TestDBEntities())
                {


                    return View(db.tbl_Student.Where(x => x.Id == id).FirstOrDefault<tbl_Student>());

                }
            }
        }

        [HttpPost]
        public ActionResult StoreOrEdit(tbl_Student studentob)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                if (studentob.Id == 0)
                {
                    db.tbl_Student.Add(studentob);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    db.Entry(studentob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                }
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                tbl_Student emp = db.tbl_Student.Where(x => x.Id == id).FirstOrDefault<tbl_Student>();
                db.tbl_Student.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
            }
        }

    }
}