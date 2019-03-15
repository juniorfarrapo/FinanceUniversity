using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FinanceUniversity.Models;

namespace FinanceUniversity.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="Joao",Birthday=DateTime.Parse("2000-09-01"),StudentID=201},
            new Student{Name="Maria",Birthday=DateTime.Parse("2001-02-04"),StudentID=202},
            new Student{Name="Jose",Birthday=DateTime.Parse("1995-04-03"),StudentID=203},
            new Student{Name="Ana",Birthday=DateTime.Parse("1998-09-17"),StudentID=204}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
            new Teacher{TeacherID=101,Name="Marcos Melo",Birthday=DateTime.Parse("1976-02-14"),Salary=3500},
            new Teacher{TeacherID=102,Name="Rubens Pinto",Birthday=DateTime.Parse("1980-10-24"),Salary=4500},
            new Teacher{TeacherID=103,Name="Cristina Fernandes",Birthday=DateTime.Parse("1968-03-11"),Salary=5000}
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=2,Title="History"},
            new Course{CourseID=1,Title="Computer Science"},
            new Course{CourseID=3,Title="Medicine"},
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
            new Subject{SubjectID=14,Title="Introduction to History",CourseID=2,TeacherID=101},
            new Subject{SubjectID=15,Title="Data structure",CourseID=1,TeacherID=102},
            new Subject{SubjectID=16,Title="Data science",CourseID=1,TeacherID=102},
            new Subject{SubjectID=17,Title="Anatomy",CourseID=3, TeacherID=103}
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment{SubjectID=14,StudentID=201,Grade=9},
            new Enrollment{SubjectID=14,StudentID=202,Grade=8},
            new Enrollment{SubjectID=15,StudentID=203,Grade=6},
            new Enrollment{SubjectID=16,StudentID=203,Grade=7},
            new Enrollment{SubjectID=17,StudentID=204,Grade=10}
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}