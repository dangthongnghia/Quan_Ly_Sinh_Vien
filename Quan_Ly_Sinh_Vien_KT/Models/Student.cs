using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Sinh_Vien_KT.Models
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BOF { get; set; }

        public string Gender {get; set;}
        public int IdProvince { get; set; }

        // Navigation property
        public Province Province { get; set; }

    }
}
