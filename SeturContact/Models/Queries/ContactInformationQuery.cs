namespace SeturContact.Models.Queries
{
    public class ContactInformationQuery
    {
        public List<int> ContactIds { get; set; } = new List<int>();

        public List<int> InformationIds { get; set; } = new List<int>();

        public List<string> Includes { get; set; } = new List<string>();
    }
}