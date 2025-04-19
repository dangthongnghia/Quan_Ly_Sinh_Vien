using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Sinh_Vien_KT.Models
{
    class UserRole
    {
        public string Id { get; set; }

        public string IdStudent { get; set; }
        public string IdRole { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }

    }
}
