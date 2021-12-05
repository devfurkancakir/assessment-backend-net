namespace SeturReport.Models.Queries
{
    public class ReportQuery
    {
        public List<int> ReportIds { get; set; } = new List<int>();

        public List<string> Includes { get; set; } = new List<string>();
    }
}