using EProduct.DataAccess.NetCore.SinhVienDTO;
using EProduct.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.IServices
{
    public interface IStudent
    {
        Task<List<IStudent>> StudentGetList();
        Task<StudentInsertReturnData> Add_Student(Student student);
    }
}
