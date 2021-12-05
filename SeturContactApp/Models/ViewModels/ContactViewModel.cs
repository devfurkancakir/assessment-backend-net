using SeturContact.Models;
using SeturReport.Models;

namespace SeturContactApp.Models.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public List<ContactInformationViewModel> Informations { get; set; } = new List<ContactInformationViewModel>();

        public ContactViewModel From(Contact contact)
        {
            this.ContactId = contact.ContactId;
            this.Firstname = contact.Firstname;
            this.Lastname = contact.Lastname;

            this.Informations = contact.Informations.Select(x => new ContactInformationViewModel().From(x)).ToList();

            return this;
        }

        public Contact To()
        {
            var contact = new Contact();

            contact.ContactId = this.ContactId;
            contact.Firstname = this.Firstname;
            contact.Lastname = this.Lastname;

            contact.Informations = this.Informations.Select(x => x.To()).ToList();

            return contact;
        }
    }
}