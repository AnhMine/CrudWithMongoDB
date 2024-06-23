using CrudWithMongoDB.Model;

namespace CrudWithMongoDB.DAL
{
    public interface ICrudDAL
    {
        public Task<InsertRecordRespone> InsertRecord(InsertRecordRequest request);
        public Task<GetAllRecordsResponse> GetAll();
        public Task<GetRecordByIDResponse> GetRecordByID(string ID);
        public Task<GetRecordByNameResponse> GetRecordByName(string Name);
        public Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request);
        public Task<UpdateSalaryIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request);
        public Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request);
        public Task<DeleteAllRecordResponse> DeleteAllRecord();


    }
}
