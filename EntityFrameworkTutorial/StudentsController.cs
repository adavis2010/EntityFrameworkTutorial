using EntityFrameworkTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial {
    public class StudentsController {

        private readonly eddbContext _context;

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
        

        //Default Construtor no parameter
        public StudentsController() {
            _context = new eddbContext();

        }


    }
}
