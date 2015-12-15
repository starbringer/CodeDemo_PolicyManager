using PolicyManager.Models;

namespace PolicyManager.Providers
{
    public class MyPolicyManager
    {
        public delegate void Policy<in T, TV>(T input1, ref TV output);
        private IMyConfiguration _configuration { get; set; }

        public MyPolicyManager(IMyConfiguration manager)
        {

            this._configuration = manager;
        }

        public PolicyContext ApplyPolicies<T>(T request, IMyConfiguration configuration, params Policy<T, PolicyContext>[] policies)
        {
            PolicyContext policyContext;
            // this is just for testing purpose
            // when the getValue returns "Good", we will give default values to the context
            if (configuration.getValue().Equals("Good"))
            {
                policyContext = new PolicyContext
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumberValidationResult = false
                };
            }
            else
                policyContext = new PolicyContext();


            foreach (var p in policies)
            {
                p(request, ref policyContext);
            }

            return policyContext;
        }

        /// <summary>
        /// check if the Name in the policy context is the same as the Name in the request
        /// if not, update the policy context based on request
        /// </summary>
        public Policy<Request, PolicyContext> NamePolicy
            = (Request r, ref PolicyContext p) =>
            {
                if (r.FirstName != p.FirstName) p.FirstName = r.FirstName;
                if (r.LastName != p.LastName) p.LastName = r.LastName;
            };

        /// <summary>
        /// check if the phone number in the request is started with "100"
        /// if not, set false to PhoneNumberValidationResult in policy context
        /// </summary>
        public Policy<Request, PolicyContext> PhoneNumberPolicy
            = (Request r, ref PolicyContext p) =>
            {
                if (r.PhoneNumber.Substring(0, 3).Equals("100"))
                {
                    p.PhoneNumberValidationResult = true;
                }
                else
                {
                    p.PhoneNumberValidationResult = false;
                }
            };

    }
}