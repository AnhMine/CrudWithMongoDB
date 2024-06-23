using Amazon.Runtime.Internal;
using CrudWithMongoDB.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudWithMongoDB.DAL
{
    public class CrulDAL:ICrudDAL
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _client;
        private readonly IMongoCollection<InsertRecordRequest> _mongoCollection;
        public CrulDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration[key: "DatabaseSettings:ConnectionString"]);
            var _Mongodb = _client.GetDatabase(_configuration[key: "DatabaseSettings:DatabaseName"]);
            _mongoCollection = _Mongodb.GetCollection<InsertRecordRequest>(_configuration[key: "DatabaseSettings:CollectionName"]);
        }

        public async Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Xóa Thành Công";
            try
            {
               var result = await _mongoCollection.DeleteOneAsync(x => x.Id == request.Id);
                if(!result.IsAcknowledged)
                {
                    response.Message = "Không tìm thấy bản ghi theo Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Lỗi: "+ ex.Message;
            }
            return response;
        }

        public async Task<DeleteAllRecordResponse> DeleteAllRecord()
        {
            DeleteAllRecordResponse response = new DeleteAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Xóa Thành Công";
            try
            {
                var result = await _mongoCollection.DeleteManyAsync(x =>  true);
                if (!result.IsAcknowledged)
                {
                    response.Message = "Không tìm thấy bản ghi theo Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Lỗi: " + ex.Message;
            }
            return response;
        }

        public async Task<GetAllRecordsResponse> GetAll()
        {
            GetAllRecordsResponse response = new GetAllRecordsResponse();
            response.IsSucess = true;
            response.Message = "Lấy Dữ Liệu Thành Công";
            try
            {

                response.data = new List<InsertRecordRequest>();
                response.data = await _mongoCollection.Find(x=>true).ToListAsync();
                if(response.data.Count ==0)
                {
                    response.Message = "Không Tìm Thấy Bản Ghi ";
                }
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Lỗi: " + ex.Message;
            }
            return response;
        }

        public async Task<GetRecordByIDResponse> GetRecordByID(string ID)
        {
            GetRecordByIDResponse response = new GetRecordByIDResponse();
            response.IsSucess = true;
            response.Message = "Thêm Dữ Liệu Thành Công";
            try
            {
                response.data = await _mongoCollection.Find(x=>x.Id ==ID).FirstOrDefaultAsync();
                if (response.data == null)
                {   
                    response.Message ="Không tìm thấy bản ghi của ID:" + ID;
                }

            }
            catch(Exception ex) 
            {
                response.IsSucess = false;
                response.Message = "Lỗi: " + ex.Message;
            }
            return response;
        }

        public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            response.IsSucess = true;
            response.Message = "Thêm Dữ Liệu Thành Công";
            try
            {
                var filter = Builders<InsertRecordRequest>.Filter.Or(
                    Builders<InsertRecordRequest>.Filter.Regex(x => x.FirstName, new MongoDB.Bson.BsonRegularExpression(Name, "i")),
                    Builders<InsertRecordRequest>.Filter.Regex(x => x.LastName, new MongoDB.Bson.BsonRegularExpression(Name, "i"))
                );

                response.data = await _mongoCollection.Find(filter).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "Không tìm thấy bản ghi của tên: " + Name;
                }
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Lỗi: " + ex.Message;
            }
            return response;
        }


        public async Task<InsertRecordRespone> InsertRecord(InsertRecordRequest request)
        {
            InsertRecordRespone response = new InsertRecordRespone();
            response.IsSucess = true;
            response.Message = "Thêm Dữ Liệu Thành Công";
            try
            {
                request.CreateDate = DateTime.Now.ToString();
                request.UpdateTime = string.Empty;
                await _mongoCollection.InsertOneAsync(request);
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Lỗi: " + ex.Message;
            }
            return response;
        }

        public async Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Cập Nhật Thành Công";
            try
            {
                GetRecordByIDResponse respone1 = await GetRecordByID(request.Id);
                request.CreateDate = respone1.data.CreateDate;
                request.UpdateTime = DateTime.Now.ToString();
                var result = await _mongoCollection.ReplaceOneAsync(x=>x.Id==request.Id,request);
                if(!result.IsAcknowledged)
                {
                    response.Message="Không tìm thấy Id" + request.Id;
                }

                
            }
            catch(Exception ex)
            {
                response.IsSuccess  =false;
                response.Message = "Cập Nhật Thất Bại";
            }
            return response;
        }

        public async Task<UpdateSalaryIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateSalaryIdResponse response = new UpdateSalaryIdResponse();
            response.IsSuccess = true;
            response.Message = "Cập Nhật Thành Công";
            try
            {
                var filter = new BsonDocument().Add("Salary", request.Salary).Add("UpdateTime", DateTime.Now.ToString());
                var UpdateDate = new BsonDocument("$set",filter);
                var result = await _mongoCollection.UpdateOneAsync(x => x.Id == request.Id, UpdateDate);
                if(!result.IsAcknowledged)
                {
                    response.Message = "Không tìm thấy Id" + request.Id;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Cập Nhật Thất Bại";
            }
            return response;
        }
    }
}
