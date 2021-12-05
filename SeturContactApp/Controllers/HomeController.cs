using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SeturContact.Models;
using SeturContact.Models.Queries;
using SeturContact.Models.Responses;
using SeturContactApp.Models;
using SeturContactApp.Models.ViewModels;
using SeturReport.Models;
using SeturReport.Models.Queries;
using SeturReport.Models.Responses;
using System.Diagnostics;
using System.Linq;

namespace SeturContactApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            var model = new ContactViewModel();

            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/get", Method.POST);
                request.AddJsonBody(new ContactQuery());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ContactResponse<Contact>>(responseString);

                model = new ContactViewModel().From(responseObj.Result.FirstOrDefault());

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult ContactDetails(int contactId)
        {
            var model = new ContactListViewModel();

            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/get", Method.POST);
                request.AddJsonBody(new ContactQuery() { ContactIds = new List<int>() { contactId }, Includes = new List<string>() { "Informations" } });
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ContactResponse<Contact>>(responseString);

                model.Contacts= responseObj.Result.Select(r=>new ContactViewModel().From(r)).ToList();

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult CreateContact(ContactViewModel model)
        {
            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/create", Method.POST);
                request.AddJsonBody(model.To());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ContactResponse<Contact>>(responseString);

                model = new ContactViewModel().From(responseObj.Result.FirstOrDefault());

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult DeleteContact(ContactViewModel model)
        {
            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/get", Method.POST);
                request.AddJsonBody(model.To());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ContactResponse<Contact>>(responseString);

                model = new ContactViewModel().From(responseObj.Result.FirstOrDefault());

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }


        public IActionResult Reports()
        {
            var model = new ReportListViewModel();

            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("report/get", Method.POST);
                request.AddJsonBody(new ReportQuery());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ReportResponse<Report>>(responseString);

                model.Reports = responseObj.Result.Select(r => new ReportViewModel().From(r)).ToList();

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult ReportDetails(int reportId)
        {
            var model = new ReportViewModel();

            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("report/get", Method.POST);
                request.AddJsonBody(new ReportQuery() { ReportIds = new List<int>() { reportId } });
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ReportResponse<Report>>(responseString);

                model = new ReportViewModel().From(responseObj.Result.FirstOrDefault());

            }
            catch (Exception ex)
            {

                throw;
            }

            return View(model);
        }

        public IActionResult CreateContactInfo(ContactInformationViewModel model)
        {
            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/info/create", Method.POST);
                request.AddJsonBody(model.To());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ReportResponse<Report>>(responseString);

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult DeleteContactInfo(ContactInformationViewModel model)
        {
            try
            {
                var client = new RestClient("https://localhost:7289/");

                var request = new RestRequest("contact/info/delete", Method.POST);
                request.AddJsonBody(new ReportQuery());
                request.RequestFormat = DataFormat.Json;

                var responseString = client.Execute(request).Content;

                var responseObj = JsonConvert.DeserializeObject<ReportResponse<Report>>(responseString);

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}