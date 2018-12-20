using Microsoft.AspNetCore.Mvc;
using Moq;
using PhotoFlux.Controllers;
using System.Threading.Tasks;
using Xunit;


namespace PhotoFlux.Tests
{
    public class PhotosControllerTests
    {
        [Fact]
        public async Task WhenGetByIdIsCalledAPhotoMustBeReturned()
        {
            var photoId = "1234";
            var photoStoreMock = new Mock<Domain.IPhotoStore>();
            photoStoreMock.Setup(m => m.GetPhotoDetailsAsync(photoId)).Returns(
                Task.FromResult<Domain.IPhotoMetadata>(new Models.PhotoMetadata { Id = photoId, Title = "Hi" }));

            var sut = new PhotosController(photoStoreMock.Object);
            //sut.ControllerContext.HttpContext = ;

            var response = await sut.Get(photoId);

            Assert.IsType<ActionResult<Domain.IPhotoMetadata>>(response);
            Assert.NotNull(response.Result);
            Assert.IsType<OkObjectResult>(response.Result);

            var statusCode = ((OkObjectResult)response.Result).StatusCode;
            var value = ((OkObjectResult)response.Result).Value as Domain.IPhotoMetadata;
            Assert.Equal(statusCode, (int)System.Net.HttpStatusCode.OK);

            Assert.NotNull(value);
            Assert.True(string.Equals(value.Id, photoId, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(string.Equals(value.Title, "Hi", System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
