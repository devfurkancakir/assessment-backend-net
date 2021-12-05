namespace SeturReport.Models.Responses
{
    public class ReportResponse<T>
    {
        public ResponseType Type { get; set; }

        public string? ErrorMessage { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public List<T> Result { get; set; } = new List<T>();
    }
}