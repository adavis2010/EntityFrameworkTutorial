using EntityFrameworkTutorial.Models;
using System;

using System.Linq;
namespace EntityFrameworkTutorial {
    class Program {
        static void Main(string[] args) {
            //create instance of context
            var _context = new eddbContext();

            //getting all Students firstname and lastname
            //easier way to get all Student names add context statement in foreach loop
            //var students = _context.Students.ToList();
            //foreach(var s in _context.Students.ToList()) {
            //  Console.WriteLine($" {s.Firstname} {s.Lastname}");
            //} 

            //using LINQ Method Syntax with Lambda 
            // var _context = new eddbContext();
            //Framework_context
            // _context.Students.ToList()
            //  .ForEach(s => Console.WriteLine($" {s.Firstname} {s.Lastname}"));

            //USING LINQ QUERY SYNTAX
           // var majors = from m in _context.Majors
                         //where m.MinSat > 1000
                         //orderby m.Description
                         //select m;
            //foreach (var m in majors) {
                //Console.WriteLine($"{m.Description}|{m.MinSat}");
           // }
        

            //CLASS EXERCISE-- Join students and Majors. Print Name and Major (inner join)
            var allstudents = (from s in _context.Students
                              join m in _context.Majors
                              on s.MajorId equals m.Id
                              select new {
                                  Name = s.Firstname + " " + s.Lastname,
                                  Major = s.MajorId == null ? "Undeclared" : m.Description
                              }).ToList();
                  allstudents.ForEach(s => Console.WriteLine($"{s.Name}- {s.Major}"));





        }



    }
}
