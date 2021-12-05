namespace SeturContact.Models.Queries
{
    public class ContactQuery
    {
        public List<int> ContactIds { get; set; } = new List<int>();

        public List<string> Includes { get; set; } = new List<string>();
    }
}