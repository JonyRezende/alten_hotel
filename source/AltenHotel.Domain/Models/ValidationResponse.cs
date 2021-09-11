namespace Domain.Models
{
    public class ValidationResponse
    {
        public bool Valid { get; set; } = true;
        public string Error { get; set; }
    }
}
