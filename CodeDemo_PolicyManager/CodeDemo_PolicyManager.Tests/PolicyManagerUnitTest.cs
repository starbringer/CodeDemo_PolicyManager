using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolicyManager.Models;

namespace PolicyManager.Tests
{
    [TestClass]
    public class PolicyManagerUnitTest
    {
        /// <summary>
        /// Assuming that:
        /// Request is sent to Partner A
        /// PolicyContext will be sent to Partner B
        /// and we want to make sure the first name and last name in both are the same
        /// Thus before we send them we run through the Namepolicy
        /// </summary>
        [TestMethod]
        public void ApplyPolicies_NamePolicy_Different_Expects_Success()
        {
            var request = new Request
            {
                FirstName = "Merry",
                LastName = "Christmas",
                ID = 1283,
                PhoneNumber = "88263891"
            };
            var factroy = new PolicyManagerTestFactory();

            var context = factroy.Manager.ApplyPolicies(
                request, factroy.configurationMock.Object, factroy.Manager.NamePolicy);

            Assert.AreEqual(context.FirstName, request.FirstName);
        }
        /// <summary>
        /// this test is testing when we need to apply 2 policies to a request
        /// in this case, we check if the name is matched and if the phone number is started with "100"
        /// </summary>
        [TestMethod]
        public void ApplyPolicies_NamePolicy_PhoneNumPolicy_Expects_Success()
        {
            var request = new Request
            {
                FirstName = "Merry",
                LastName = "Christmas",
                ID = 1283,
                PhoneNumber = "10063891"
            };
            var factroy = new PolicyManagerTestFactory();

            var context = factroy.Manager.ApplyPolicies(
                request, factroy.configurationMock.Object, factroy.Manager.NamePolicy, factroy.Manager.PhoneNumberPolicy);

            Assert.AreEqual(context.FirstName, request.FirstName);
            Assert.IsTrue(context.PhoneNumberValidationResult);
        }


    }
}
