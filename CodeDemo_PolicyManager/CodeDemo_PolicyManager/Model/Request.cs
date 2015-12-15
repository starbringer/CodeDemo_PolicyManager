namespace PolicyManager.Models
{
    /// <summary>
    /// the request will be send to an external partner
    /// </summary>
    public class Request
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}