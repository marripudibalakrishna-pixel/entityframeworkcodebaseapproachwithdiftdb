using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using entityframeworkcodebaseapproachwithdiftdb.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityframeworkcodebaseapproachwithdiftdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Idepartmentservice _departmentservice;

        public DepartmentController(Idepartmentservice departmentservice)
        {
            _departmentservice = departmentservice; 
        }
        [HttpPost]
        [Route("AddEmployee")]
        //Here modelbinder bind your request body data to your model class.
        public async Task<IActionResult> Post([FromBody] departmentdto deptdto)
        //line 19 and 32 should have same parameter name because model binder will bind the request body data to this parameter and if you are not pass any payload from request body model binder will excute this if condition and  return 400badrequest error.
        {
            try
            {
                if (!ModelState.IsValid)
                {//if you are not pass any payload fom request body model binder will excute this if condition and  return 400badrequest error.
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata = await _departmentservice.AddDepartment(deptdto);
                    return StatusCode(StatusCodes.Status201Created, deptdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteDepartmentByDeptid/{deptid}")]
        public async Task<IActionResult> delete(int deptid)
        {
            if (deptid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _departmentservice.Deletedepartmentbyid(deptid);//calling service layer method to delete employee data from db by empid
                if (empdata == false)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var deptdata = await _departmentservice.GetDepartments();// calling service layer method to get all employee data from db
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] departmentdto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata = await _departmentservice.Updatedepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetByDeptid/{deptid}")]
        public async Task<IActionResult> Get(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _departmentservice.getdepartmentid(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }

    }
}
