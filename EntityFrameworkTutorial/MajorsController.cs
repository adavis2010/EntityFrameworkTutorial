using EntityFrameworkTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTutorial {
    public class MajorsController {

        private readonly eddbContext _context;


        // Get All Method
        public IEnumerable<Major> GetAll() {
            return _context.Majors.ToList();

        }
        //Get by Primary Key
        public Major GetByPK(int id) {
            return _context.Majors.Find(id);

        }
        //Insert (Create) 
        public Major Create(Major major) {
            if (major == null) {
                throw new Exception("Major cannot be null");
            }
            if (major.Id != 0) {
                throw new Exception("Major.Id must be zero");
            }
            _context.Majors.Add(major);

            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1) {
                throw new Exception("Insert/Create failed");
            }
            return major;
        }
        // Update (Change)
        public void Change(Major major) {

            if (major == null) {
                throw new Exception("Major cannot be null");
            }
            if (major.Id <= 0) {
                throw new Exception("Major.Id must be greater than zero!");
            }
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1) {
                throw new Exception("Change Failed!");
            }
            return;

        }
        //Delete (Remove)
        public async Task<Major> Remove(int id) {
            var major = await _context.Majors.FindAsync(id);
            if (major == null) {
                return null;
            }
            int count = await _context.Students.Where(s => s.MajorId == major.Id).CountAsync();
            if (count > 0)
                throw new Exception("Cannot remove Major. It is a PK to a student");

            _context.Majors.Remove(major);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1000) {
                throw new Exception("Remove Failed");
            }
            return major;
        }


        public MajorsController() {
            _context = new eddbContext();
        }
    }

}


