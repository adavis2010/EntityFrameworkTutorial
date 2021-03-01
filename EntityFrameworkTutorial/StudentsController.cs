using EntityFrameworkTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Turn into Asynchronous Method 3/1
        public async Task<IEnumerable<Student>> GetAll() {
            //pick collection
            return await _context.Students.ToListAsync();
        }

        //Get by Primary Key
        //Turn into Asynchronous Method 3/1
        public async Task<Student> GetByPk(int id) {
            return await _context.Students.FindAsync(id);
        }

        //Insert (Create)
        public async Task<Student> Create(Student student) {
            if (student == null) {
                throw new Exception("Student cannot be null!");
            }
            if (student.Id != 0) {
                throw new Exception("Student.Id must be zero!");
            }
            _context.Students.Add(student);
            var rowsAffected =  await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Insert/Create failed");
            }
            return student;
        }

        //Update (Change)
        public async Task Change(Student student) {
            if (student == null) {
                throw new Exception("Student cannot be null!");
            }
            if (student.Id <= 0) {
                throw new Exception("Student.Id must be greater than zero!");
            }
             _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) { 
                throw new Exception("Change failed");
            }
            return;
        }

        //Delete (Remove)
        public async Task <Student> Remove(int id) {
            var student = await _context.Students.FindAsync(id);
            if(student == null) {
                return null;
            }
            _context.Students.Remove(student);
            var rowsAffected = await _context.SaveChangesAsync();
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
