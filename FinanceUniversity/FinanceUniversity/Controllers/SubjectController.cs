using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanceUniversity.DAL;
using FinanceUniversity.Models;

namespace FinanceUniversity.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetSubjects()
        {
            UniversityContext db = new UniversityContext();
            return Json(db.Subjects.ToList());
        }


        [HttpPost]
        public JsonResult InsertSubject(Subject subject)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }

            return Json(subject);
        }

        [HttpPost]
        public ActionResult UpdateSubject(Subject subject)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Subject updatedSubject = (from c in db.Subjects
                                        where c.SubjectID == subject.SubjectID
                                        select c).FirstOrDefault();
                updatedSubject.Title = subject.Title;
                updatedSubject.TeacherID = subject.TeacherID;
                updatedSubject.CourseID = subject.CourseID;
                db.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteSubject(int subjectId)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Subject subject = (from c in db.Subjects
                                 where c.SubjectID == subjectId
                                 select c).FirstOrDefault();
                db.Subjects.Remove(subject);
                db.SaveChanges();
            }
            return new EmptyResult();
        }

       
    }
}
