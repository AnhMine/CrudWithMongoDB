using System.ComponentModel.DataAnnotations;

namespace CrudWithMongoDB.Model
{
  
    public class UpdateRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
