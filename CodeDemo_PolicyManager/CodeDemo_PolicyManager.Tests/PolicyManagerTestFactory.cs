using Moq;
using PolicyManager.Providers;
using PolicyManager.Models;

namespace PolicyManager.Tests
{
    public class PolicyManagerTestFactory
    {
        public MyPolicyManager Manager { get; set; }
        public Mock<IMyConfiguration> configurationMock { get; set; }

        public PolicyManagerTestFactory()
        {
            configurationMock = new Mock<IMyConfiguration>();
            configurationMock.Setup(c => c.getValue()).Returns("Good");

            Manager = new MyPolicyManager(configurationMock.Object);
        }

    }
}
