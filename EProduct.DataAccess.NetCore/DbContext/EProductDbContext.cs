
//using EProduct.DataAccess.NetCore.DTO;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EBook.DataAccess.NetCore.DBContext
//{
//    public class EProductDbContext : DbContext
//    {
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GS7QPAK3\\SQLEXPRESS;Initial Catalog=QuanLySanPham;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
//        }

//        public virtual DbSet<Product> product { get; set; }
//        public virtual DbSet<ProductAttribute> productattribute { get; set; }
//        public virtual DbSet<Variant> variant { get; set; }
//        public virtual DbSet<Users> users { get; set; }
//        public virtual DbSet<OrderDetails> OrderDetails {  get; set; }
//    }
//}
