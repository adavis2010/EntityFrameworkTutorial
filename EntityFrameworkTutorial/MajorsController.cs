using EntityFrameworkTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            // Update (Change)
            public void Change(Major major);{
            { 
                if (major == null) {
                    throw new Exception("Major cannot be null");
                }
                if (major.Id <= 0) {
                    throw new Exception("Major.Id must be greater than zero!");
                }
                _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var rowssAffected = _context.SaveChanges();
                if (rowsAffected != 1) {
                    throw new Exception("Change Failed!");
                }
                    return;

            }
                //Delete (Remove)
                public Major Remove(int id) {
                var major = _context.Majors.Find(id);
                if (major == null) {
                    return null;
                }

                _context.Majors.Remove(major);
                var rowsAffected = _context.SaveChanges();
                if (rowsAffected! = 1) {
                    throw new Exception("Remove Failed");
                }
                return student
            }


            
        }

            public MajorsController() {
                _context = neweddbContext();
            }
        }

}


