using ArtfulAdventures.Services.Data.Interfaces;
using ArtfulAdventures.Web.Controllers;
using ArtfulAdventures.Web.ViewModels;
using ArtfulAdventures.Web.ViewModels.HashTag;
using ArtfulAdventures.Web.ViewModels.Picture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;

namespace ArtfulAdventures.UnitTests.Controllers;

[TestFixture]
public class ExploreControllerTests
{
    private ExploreController _exploreController;
    private Mock<IExploreService> _mockExploreService;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mockExploreService = new Mock<IExploreService>();
        _exploreController = new ExploreController(_mockExploreService.Object);
    }

    [Test]
    public async Task All_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var sort = "tag";
        var page = 1;
        var mockExploreService = _mockExploreService;
        var expectedModel = new ExploreViewModel()
        {
            HashTags = new List<HashTagViewModel>()
            {
                new HashTagViewModel()
                {
                    Id = 1, IsSelected = true, Name = "tag", PicturesCount = 1
                }
            },
            Pictures = new List<PictureVisualizeViewModel>()
            {
                new PictureVisualizeViewModel()
                {
                    CreatedOn = DateTime.Now, HashTags = new List<string>(), PictureUrl = "testURL", Likes = 1,
                    Owner = "test", Id = "test"
                }
            },
            TagsForDropDown = new List<HashTagViewModel>()
            {
                new HashTagViewModel()
                {
                    Id = 1, IsSelected = true, Name = "tag", PicturesCount = 1
                }
            },
        };
        mockExploreService.Setup(x => x.GetExploreViewModelAsync(sort, page))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _exploreController.All(sort, page);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task All_WhenCalled_CatchesException_And_Redirects()
    {
        //Arrange
        var mockExploreService = _mockExploreService;
        mockExploreService
            .Setup(service => service.GetExploreViewModelAsync(It.IsAny<string>(), It.IsAny<int>()))
            .Throws(new ArgumentException());
        var controller = _exploreController;
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;
        var sort = "test-sort";
        var page = -1;

        //Act
        var result = await controller.All(sort, page);

        //Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectResult = result as RedirectToActionResult;
        Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Explore"));
        Assert.That(redirectResult.RouteValues["sort"], Is.EqualTo(""));
        Assert.That(redirectResult.RouteValues["page"], Is.EqualTo(1));
    }
}