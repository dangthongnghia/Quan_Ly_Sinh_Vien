using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Sinh_Vien_KT.Models
{
    class Enrol
    {
        public string IdStudent { get; set; }
        public string IdSubject { get; set; }

        public string Mark { get; set; }

        // Navigation property
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}


    