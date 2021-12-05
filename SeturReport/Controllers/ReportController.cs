using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturReport.Models;
using SeturReport.Models.Queries;
using SeturReport.Models.Responses;
using System.Net;
using System.Threading;

namespace SeturReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public ReportResponse<Report> GetReports(ReportQuery query)
        {
            try
            {

                using (var ctx = new ReportDbContext())
                {
                    IQueryable<Report> contacts = ctx.Reports.Where(c => query.ReportIds.Contains(c.ReportId));

                    foreach (var include in query.Includes)
                    {
                        contacts = contacts.Include(include);
                    }

                    return new ReportResponse<Report>() { Result = contacts.ToList(), Type = ResponseType.Succes };
                }
            }
            catch (Exception ex)
            {

                return new ReportResponse<Report> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpGet]
        [Route("queue/request")]
        public async Task< ReportResponse<Report>> ProcessReportQuery()
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "host1:9092,host2:9092",
                    ClientId = Dns.GetHostName(),
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    await producer.ProduceAsync("weblog", new Message<Null, string> { Value = "a log message" });
                }
            }
            catch (Exception ex)
            {

                return new ReportResponse<Report> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }

            return null;
        }

        [HttpGet]
        [Route("queue/response")]
        public async Task<ReportResponse<Report>> QueueReportResponse(ReportQuery query)
        {
            try
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = "host1:9092,host2:9092",
                    GroupId = "foo",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe("Report");

                    //while (!cancelled)
                    //{
                    //    var consumeResult = consumer.Consume(cancellationToken);

                    //}

                    consumer.Close();
                }
            }
            catch (Exception ex)
            {

                return new ReportResponse<Report> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }

            return null;
        }
    }
}