namespace CrudWithMongoDB.Model
{
    public class GetRecordByIDResponse
    {
        public bool IsSucess { get; set; }

        public string Message { get; set; }

        public InsertRecordRequest data { get; set; }

    }
    public class GetRecordByNameResponse
    {
        public bool IsSucess { get; set; }

        public string Message { get; set; }

        public List<InsertRecordRequest> data { get; set; }   
    }
}
