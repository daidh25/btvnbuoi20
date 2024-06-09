using EProduct.DataAccess.NetCore.SinhVienDTO;
using EProduct.DataAccess.NetCore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EProduct.DataAccess.NetCore.IServices;

namespace EBook.DataAccess.NetCore.DBContext
{
    public class EStudentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GS7QPAK3\\SQLEXPRESS;Initial Catalog=QuanLyHocSinh;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }

        internal List<IStudent> ToList()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
