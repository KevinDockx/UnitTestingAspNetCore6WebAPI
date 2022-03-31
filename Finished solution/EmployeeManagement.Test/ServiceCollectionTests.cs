using EmployeeManagement.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EmployeeManagement.Test
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void RegisterDataServices_Execute_DataServicesAreRegistered()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string> {
                        {"ConnectionStrings:EmployeeManagementDB", "AnyValueWillDo"}})
                .Build();

            // Act
            serviceCollection.RegisterDataServices(configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            Assert.NotNull(
                serviceProvider.GetService<IEmployeeManagementRepository>());
            Assert.IsType<EmployeeManagementRepository>(
                serviceProvider.GetService<IEmployeeManagementRepository>());
        }
    }
}
