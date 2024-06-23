namespace CrudWithMongoDB.Model
{
    public class GetAllRecordsResponse
    {
        public bool IsSucess { get; set; }

        public string Message { get; set; }

        public List<InsertRecordRequest> data { get; set; }   
    }
}
