using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturContact.Models;
using SeturContact.Models.Queries;
using SeturContact.Models.Responses;

namespace SeturContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public ContactResponse<Contact> GetContacts(ContactQuery query)
        {
            try
            {

                using (var ctx = new ContactDbContext())
                {
                    IQueryable<Contact>  contacts = ctx.Contacts.Where(c=>query.ContactIds.Contains(c.ContactId));

                    foreach (var include in query.Includes)
                    {
                        contacts= contacts.Include(include);
                    }

                    return new ContactResponse<Contact>() { Result = contacts.ToList(), Type = ResponseType.Succes };
                }
            }
            catch (Exception ex)
            {

                return new ContactResponse<Contact> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("create")]
        public ContactResponse<Contact> CreateContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Add(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse<Contact>() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<Contact> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("update")]
        public ContactResponse<Contact> UpdateContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Update(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse<Contact>() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<Contact> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("delete")]
        public ContactResponse<Contact> DeleteContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Remove(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse<Contact>() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<Contact> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpGet]
        [Route("info/get")]
        public ContactResponse<ContactInformation> GetContactInformations(ContactInformationQuery query)
        {
            try
            {

                using (var ctx = new ContactDbContext())
                {
                    IQueryable<ContactInformation> contactInfos = ctx.ContactInformations;

                    if (query.ContactIds.Any())
                    {
                        contactInfos= contactInfos.Where(c => query.ContactIds.Contains(c.ContactId));
                    }

                    if (query.InformationIds.Any())
                    {
                        contactInfos = contactInfos.Where(c => query.InformationIds.Contains(c.ContactInformationId));
                    }

                    foreach (var include in query.Includes)
                    {
                        contactInfos = contactInfos.Include(include);
                    }

                    return new ContactResponse<ContactInformation>() { Result = contactInfos.ToList(), Type = ResponseType.Succes };
                }
            }
            catch (Exception ex)
            {

                return new ContactResponse<ContactInformation> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("info/create")]
        public ContactResponse<ContactInformation> CreateContactInformation(ContactInformation info)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.ContactInformations.Add(info);

                    ctx.SaveChanges();
                }

                return new ContactResponse<ContactInformation>() { Result = new List<ContactInformation>() { info }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<ContactInformation> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("info/update")]
        public ContactResponse<ContactInformation> UpdateContactInformation(ContactInformation info)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.ContactInformations.Update(info);

                    ctx.SaveChanges();
                }

                return new ContactResponse<ContactInformation>() { Result = new List<ContactInformation>() { info }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<ContactInformation> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpPost]
        [Route("info/delete")]
        public ContactResponse<ContactInformation> DeleteContactInformation(ContactInformation info)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.ContactInformations.Remove(info);

                    ctx.SaveChanges();
                }

                return new ContactResponse<ContactInformation>() { Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse<ContactInformation> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }
    }
}