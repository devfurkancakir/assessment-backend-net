namespace SeturContact.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public List<ContactInformation> Informations { get; set; } = new List<ContactInformation>();
    }
}