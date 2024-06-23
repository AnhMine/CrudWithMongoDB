using CrudWithMongoDB.DAL;
using CrudWithMongoDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithMongoDB.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class CrudController : Controller
    {
        private readonly ICrudDAL _dal;
        public CrudController(ICrudDAL dal)
        {
            _dal = dal;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord(InsertRecordRequest request)
        {
            InsertRecordRespone respone = new InsertRecordRespone();
           
            try
            {
                respone = await _dal.InsertRecord(request);
            }
            catch (Exception ex)
            {
                respone.IsSucess = false;
                respone.Message= "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecord()
        {
            GetAllRecordsResponse respone = new GetAllRecordsResponse();

            try
            {
                respone = await _dal.GetAll();
            }
            catch (Exception ex)
            {
                respone.IsSucess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecordByID([FromQuery] string Id)
        {
            GetRecordByIDResponse respone = new GetRecordByIDResponse();

            try
            {
                respone = await _dal.GetRecordByID(Id);
            }
            catch (Exception ex)
            {
                respone.IsSucess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecordByName([FromQuery]string Name)
        {
            GetRecordByNameResponse respone = new GetRecordByNameResponse();

            try
            {
                respone = await _dal.GetRecordByName(Name);
            }
            catch (Exception ex)
            {
                respone.IsSucess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordByIdResponse respone = new UpdateRecordByIdResponse();

            try
            {
                respone = await _dal.UpdateRecordById(request);
            }
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateSalaryIdResponse respone = new UpdateSalaryIdResponse();

            try
            {
                respone = await _dal.UpdateSalaryById(request);
            }
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            DeleteRecordByIdResponse respone = new DeleteRecordByIdResponse();

            try
            {
                respone = await _dal.DeleteRecordById(request);
            }
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAllRecord()
        {
            DeleteAllRecordResponse respone = new DeleteAllRecordResponse();

            try
            {
                respone = await _dal.DeleteAllRecord();
            }
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = "Lỗi: " + ex.Message;
            }
            return Ok(respone);
        }


    }
}
