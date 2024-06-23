using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CrudWithMongoDB.Model
{
    public class InsertRecordRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CreateDate { get; set; }
        public string UpdateTime { get; set;}
        [Required]
        [BsonElement(elementName:"Name")]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]  
        public string? Contact {  get; set; }
        public double Salary {  get; set; }

    }
    public class InsertRecordRespone
    {
        public bool IsSucess { get; set; }
        public string? Message { get; set; }
    }
}
