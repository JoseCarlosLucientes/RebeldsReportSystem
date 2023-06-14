using RebeldsReportSystem.Domain.ServiceImplementations;
using RebeldsReportSystem.Infrastructure.Data.RepositoryImplementations;
using Xunit;
using RebeldsReportSystem.Domain.DomainEntities;

namespace RebeldsReportSystem.Infrastructure.Tests.Domain
{
    public class RebeldsReportServiceTestSuite
    {

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsVoid()
        {
            // Arrange
            RebeldsReportService service = new RebeldsReportService(
                new RebeldsReportRepository()
            );

            RebeldsReport input = new RebeldsReport();
            input.planetName = "Naboo";
            input.rebeldName = "JoseCarlos";

            // Act
            var exception = Record.Exception(() => service.CreateRebeldReport(input));

            // Assert
            Assert.Null(exception);
        }
    }
}
