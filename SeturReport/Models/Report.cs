namespace SeturReport.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public DateTime RequestDate { get; set; }

        public ReportStatus Status { get; set; }
    }
}