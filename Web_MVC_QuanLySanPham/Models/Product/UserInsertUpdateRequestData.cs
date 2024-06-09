namespace Web_MVC_QuanLySanPham.Models.Product
{
    public class UserInsertUpdateRequestData
    {
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string OrderValues { get; set; }
    }
}
