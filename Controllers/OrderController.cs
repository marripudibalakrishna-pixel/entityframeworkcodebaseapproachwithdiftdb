using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using entityframeworkcodebaseapproachwithdiftdb.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityframeworkcodebaseapproachwithdiftdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderservice _orderservice;
        public OrderController(IOrderservice orderservice)
        {
            _orderservice = orderservice;
        }
         [HttpPost]
         [Route("Addorder")]
         public async Task<IActionResult> Addorder([FromBody] Orderdto order)
         {
             var result = await _orderservice.Addorder(order);
             if (result > 0)
             {
                 return Ok(result);
             }
             return BadRequest();
         }
        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int orderid)
        {
            if (orderid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderdata = await _orderservice.Deleteorderbyid(orderid);//calling service layer method to delete employee data from db by empid
                if (orderdata == null)
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
        [Route("GetOrders")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _orderservice.Getorders();// calling service layer method to get all employee data from db
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpPut]
        [Route("UpdateOrders")]
        public async Task<IActionResult> put([FromBody] Orderdto orderdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderdata = await _orderservice.Updateorder(orderdto);
                    return StatusCode(StatusCodes.Status200OK, orderdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployeeByEmpid/{orderid}")]
        public async Task<IActionResult> Get(int orderid)
        {
            if (orderid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderdata = await _orderservice.Getorderid(orderid);
                return StatusCode(StatusCodes.Status200OK, orderdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
    }
}
