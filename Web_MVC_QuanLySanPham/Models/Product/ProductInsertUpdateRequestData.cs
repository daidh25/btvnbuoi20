namespace Web_MVC_QuanLySanPham.Models.Product
{
    public class ProductInsertUpdateRequestData
    {
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string AttributeValues { get; set; }
    }
}
