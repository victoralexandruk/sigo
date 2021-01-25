using Moq;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using SIGO.Normas.Controllers;
using SIGO.Normas.Tests.Mock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SIGO.Normas.Tests.Unit
{
    public class NormaControllerTest
    {
        [Fact]
        public void GetAll()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Norma>>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(NormaMock.GetAll());
            var controller = new NormaController(null, mockRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Norma>>(result);
            Assert.Equal(mockRepo.Object.GetAll().Count(), model.Count());
        }
    }
}
