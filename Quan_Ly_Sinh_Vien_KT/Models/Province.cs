﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Sinh_Vien_KT.Models
{
    class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Student> Students { get; set; }

    }
}
