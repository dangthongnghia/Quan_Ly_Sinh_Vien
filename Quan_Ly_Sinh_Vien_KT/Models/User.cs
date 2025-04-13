using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Sinh_Vien_KT.Models
{
    class User
    {
        public string IdStudent { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


        // Navigation property

    }
}
