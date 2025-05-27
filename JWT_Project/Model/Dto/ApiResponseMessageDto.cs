using System.ComponentModel.DataAnnotations;

namespace JWT_Project.Model.Dto
{
    public class ApiResponseMessageDto
    {
        [Key]
        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string ResponseValues { get; set; }

        public int IsSuccessful { get; set; }
    }
}
