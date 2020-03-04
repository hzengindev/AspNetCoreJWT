namespace Business.Model
{
    public class BaseOutModel
    {
        public bool Success { get; set; } = true;
        public string ErrorMessage { get; set; }
        public int? ErrorCode { get; set; }
    }
}
