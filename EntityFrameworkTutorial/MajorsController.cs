using System;
using EntityFrameworkTutorial.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial {
     public class MajorsController {

        private readonly eddbContext _context;

        public MajorsController() {
            _context = new eddbContext();

        }
    }
}
