using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.SinhVienDTO
{
    public class Student
    {
        public int Id {  get; set; }
        public string StudentName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }
}
