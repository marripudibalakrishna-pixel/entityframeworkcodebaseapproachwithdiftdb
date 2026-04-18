using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using entityframeworkcodebaseapproachwithdiftdb.Repositories;

namespace entityframeworkcodebaseapproachwithdiftdb.services
{
    public class Departmentservice : Idepartmentservice
       {

        private readonly Departmentrepository _departmentrepository;

        public Departmentservice(Departmentrepository departmentrepository) 
        { 
            _departmentrepository = departmentrepository;
        }
        public async Task<int> AddDepartment(departmentdto deptdto)
        {
            Department dept = new Department();
            dept.DepartmentId = deptdto.DepartmentId;
            dept.DepartmentName = deptdto.DepartmentName;
            dept.Location = deptdto  .Location;

            var res = await _departmentrepository.AddDepartment(dept);
            return res;
        }

        

        public async Task<bool> Deletedepartmentbyid(int id)
        {
            var res = await _departmentrepository.Deletedepartmentbyid(id);
            return res;
        }

        public async Task<departmentdto> getdepartmentid(int id)
        {
            var res = await _departmentrepository.getdepartmentid(id);

            departmentdto deptdto = new departmentdto();
            deptdto.DepartmentId = res.DepartmentId;
            deptdto.DepartmentName = res.DepartmentName;
            deptdto.Location = res.Location;
            return deptdto;
        }




        public async Task<List<departmentdto>> GetDepartments()
        {
            List<departmentdto> lstempdto = new List<departmentdto>();
            var res = await _departmentrepository.GetDepartments();
            foreach (Department dept in res)//To process the list data we are using forach
            {
                departmentdto deptdto = new departmentdto();
                deptdto.DepartmentId = dept.DepartmentId;
                deptdto.DepartmentName = dept.DepartmentName;
                deptdto.Location = dept.Location;
                lstempdto.Add(deptdto);

            }
            return lstempdto;
        }

        public async Task<bool> Updatedepartment(departmentdto deptdto)
        {
            Department dept = new Department();
            dept.DepartmentId = deptdto.DepartmentId;
            dept.DepartmentName = deptdto.DepartmentName;
            dept.Location = deptdto.Location;
            var res = await _departmentrepository.Updatedepartment(dept);
            return res;
        }
    }
}
