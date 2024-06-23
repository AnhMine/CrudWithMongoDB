using System.ComponentModel.DataAnnotations;

namespace CrudWithMongoDB.Model
{
    public class UpdateSalaryByIdRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public double Salary {  get; set; } 
    }
    public class UpdateSalaryIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
