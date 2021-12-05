using SeturContact;
using SeturContact.Models;

namespace SeturContactApp.Models.ViewModels
{
    public class ContactInformationViewModel
    {
        public int ContactInformationId { get; set; }

        public int ContactId { get; set; }

        public ContactInformationType Type { get; set; }

        public string? Content { get; set; }

        public ContactInformationViewModel From(ContactInformation info)
        {
            this.ContactInformationId = info.ContactInformationId;
            this.ContactId = info.ContactId;
            this.Type = info.Type;
            this.Content = info.Content;

            return this;
        }

        public ContactInformation To()
        {
            var info = new ContactInformation();

            info.ContactInformationId = this.ContactInformationId;
            info.ContactId = this.ContactId;
            info.Type = this.Type;
            info.Content = this.Content;

            return info;
        }

    }
}