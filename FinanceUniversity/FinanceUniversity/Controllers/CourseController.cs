using FinanceUniversity.DAL;
using FinanceUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceUniversity.Controllers
{
    public class CourseController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCourses()
        {
            UniversityContext db = new UniversityContext();
            return Json(db.Courses.ToList());
        }

        [HttpPost]
        public JsonResult InsertCourse(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }

            return Json(course);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Course updatedCourse = (from c in db.Courses
                                            where c.CourseID == course.CourseID
                                            select c).FirstOrDefault();
                updatedCourse.Title = course.Title;
                db.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteCourse(int courseId)
        {
            using (UniversityContext db = new UniversityContext())
            {
                Course course = (from c in db.Courses
                                     where c.CourseID == courseId
                                     select c).FirstOrDefault();
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}