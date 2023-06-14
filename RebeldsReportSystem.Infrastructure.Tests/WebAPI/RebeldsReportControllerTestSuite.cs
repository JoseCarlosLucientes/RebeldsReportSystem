using Moq;
using RebeldsReportSystem.WebAPI.Controllers;
using RebeldsReportSystem.Domain.CustomExceptions;
using RebeldsReportSystem.Domain.DomainEntities;
using RebeldsReportSystem.Domain.ServiceContracts;
using RebeldsReportSystem.Domain.ServiceImplementations;
using RebeldsReportSystem.Infrastructure.Data.RepositoryImplementations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace RebeldsReportSystem.Infrastructure.Tests.WebAPI
{
    public class RebeldsReportControllerTestSuite
    {
        
        private RebeldsReportController InitController()
        {
            RebeldsReportController controller =
                new RebeldsReportController(
                    new RebeldsReportService(
                        new RebeldsReportRepository()));

            return controller;
        }       
       
        
        
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            RebeldsReportController controller = InitController();
            List<string> values = new List<string> { "joseCarlos","naboo" };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }
       

        [Fact]
        public void UnitTest_Register_InputValid_CannotSaveDataExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<IRebeldsReportService> serviceMock = new Mock<IRebeldsReportService>();
            serviceMock.Setup(x => x.CreateRebeldReport(It.IsAny<RebeldsReport>())).Throws<CannotSaveDataException>();

            IRebeldsReportService mockedService = serviceMock.Object;

            RebeldsReportController controller = new RebeldsReportController(mockedService);

            List<string> values = new List<string> { "joseCarlos", "naboo", "extra" };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }
      
    }
}
