using EntityFrameworkTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial {
    public class StudentsController {

        private readonly eddbContext _context;

        // CLASS EXERCISE -- read all students with SAT score between 1000 and 1200 inclusive
        // and sort the result SAT score by descending order (using METHOD syntax)
        public IEnumerable<Student> GetBySatRange(int LowSat, int HighSat) {
            return _context.Students
                .Where(s => s.Sat >= LowSat && s.Sat <= HighSat)
                .OrderByDescending(s => s.Sat)
                .ToList();

            //QUERY syntax fpr CLASS EXERCISE ABOVE
           // return (from s in _context.Students
                  // where s.Sat >= LowSat && s.Sat <= HighSat
                  // orderby s.Sat descending
                   //select s).ToList();

        }

        //Get All Method
        public IEnumerable<Student> GetAll() {
            //pick collection
            return _context.Students.ToList();
        }

        //Get by Primary Key
        public Student GetByPk(int id) {
            return _context.Students.Find(id);
        }

        //Insert (Create)
        public Student Create(Student student) {
            if (student == null) {
                throw new Exception("Student cannot be null!");
            }
            if (student.Id != 0) {
                throw new Exception("Student.Id must be zero!");
            }
            _context.Students.Add(student);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1) {
                throw new Exception("Insert/Create failed");
            }
            return student;
        }

        //Update (Change)
        public void Change(Student student) {
            if (student == null) {
                throw new Exception("Student cannot be null!");
            }
            if (student.Id <= 0) {
                throw new Exception("Student.Id must be greater than zero!");
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1) { 
                throw new Exception("Change failed");
            }
            return;
        }

        //Delete (Remove)
        public Student Remove(int id) {
            var student = _context.Students.Find(id);
            if(student == null) {
                return null;
            }
            _context.Students.Remove(student);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1) {
                throw new Exception("Remove Failed");
            }
            return student;
        }



        //Default Construtor no parameter
        public StudentsController() {
            _context = new eddbContext();

        }


    }
}
