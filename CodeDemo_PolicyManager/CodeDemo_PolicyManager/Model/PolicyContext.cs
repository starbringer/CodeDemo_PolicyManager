namespace PolicyManager.Models
{
    /// <summary>
    /// this class has all the context the will be updated by the policies
    /// </summary>
    public class PolicyContext
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PhoneNumberValidationResult { get; set; }
    }
}