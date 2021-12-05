using SeturReport;
using SeturReport.Models;

namespace SeturContactApp.Models.ViewModels
{
    public class ReportViewModel
    {
        public int ReportId { get; set; }

        public DateTime RequestDate { get; set; }

        public ReportStatus Status { get; set; }

        public ReportViewModel From(Report report)
        {
            this.ReportId = report.ReportId;
            this.RequestDate = report.RequestDate;
            this.Status = report.Status;

            return this;
        }
    }
}