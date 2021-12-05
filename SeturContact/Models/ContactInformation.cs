using System.ComponentModel.DataAnnotations.Schema;

namespace SeturContact.Models
{
    public class ContactInformation
    {
        public int ContactInformationId { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public ContactInformationType Type { get; set; }

        public string? Content { get; set; }
    }
}