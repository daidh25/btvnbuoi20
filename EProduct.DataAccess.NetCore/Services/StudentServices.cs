using EBook.DataAccess.NetCore.DBContext;
using EProduct.DataAccess.NetCore.DTO;
using EProduct.DataAccess.NetCore.IServices;
using EProduct.DataAccess.NetCore.SinhVienDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.Services
{
    public class StudentServices : IStudent
    {
        EStudentDbContext _eStudentDbContext = new EStudentDbContext();

        public async Task<StudentInsertReturnData> Add_Student(Student student)
        {
            var returnData = new StudentInsertReturnData();
            try
            {
                if (student == null || string.IsNullOrEmpty(student.StudentName))
                {
                    returnData.ReturnCode = (int)EShop.Common.Enum_ReturnCode.DataInValid;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }
                var currentStudent = _eStudentDbContext.Students.ToList().Where(s => s.StudentName == student.StudentName).FirstOrDefault();
                if (currentStudent.StudentName == student.StudentName
                    && currentStudent.DateOfBirth.ToString("yyyy/mm/dd") == student.DateOfBirth.ToString("yyyy/mm/dd")
                    && currentStudent.Email == student.Email)
                {
                    returnData.ReturnCode = (int)EShop.Common.Enum_ReturnCode.DuplicateData;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;

                }
                await _eStudentDbContext.Students.AddAsync(student);
                var result = await _eStudentDbContext.SaveChangesAsync();
                returnData.ReturnCode = (int)EShop.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Thêm dữ liệu thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)EShop.Common.Enum_ReturnCode.DataInValid;
                returnData.ReturnMsg = "Đã xảy ra lỗi khi xử lý yêu cầu của bạn";
            }

            return returnData;
        }
        public async Task<List<IStudent>> StudentGetList()
        {
            return _eStudentDbContext.ToList();
        }
    }
    
}
