using System.Security.Claims;
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
public class FollowingControllerTests
{
    private FollowingController _followingController;
    private Mock<IFollowingService> _mockFollowingService;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mockFollowingService = new Mock<IFollowingService>();
        _followingController = new FollowingController(_mockFollowingService.Object);
    }

    [Test]
    public async Task All_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var sort = "tag";
        var page = 1;
        var username = "test-username";
        var mockFollowingService = _mockFollowingService;
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

        mockFollowingService.Setup(service => service.GetExploreViewModelAsync(sort, page, username))
            .ReturnsAsync(expectedModel);
        var controller = _followingController;
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "test-username")
        }));

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        var result = await controller.All(sort, page);

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.InstanceOf<ExploreViewModel>());
        var model = viewResult.Model as ExploreViewModel;
        Assert.That(model, Is.EqualTo(expectedModel));
    }

    [Test]
    public async Task All_WhenExceptionIsThrown_CatchesExceptionAndRedirects()
    {
        // Arrange
        var mockFollowingService = _mockFollowingService;
        mockFollowingService
            .Setup(service => service.GetExploreViewModelAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
            .Throws(new Exception("Test exception"));
        var controller = _followingController;
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;
        var sort = "test-sort";
        var page = -1;

        // Act
        var result = await controller.All(sort, page);

        // Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectToActionResult = result as RedirectToActionResult;
        Assert.That(redirectToActionResult.ActionName, Is.EqualTo("All"));
        Assert.That(redirectToActionResult.ControllerName, Is.EqualTo("Following"));
        Assert.That(redirectToActionResult.RouteValues["sort"], Is.EqualTo(""));
        Assert.That(redirectToActionResult.RouteValues["page"], Is.EqualTo(1));
    }

    [Test]
    public async Task All_CallsGetExploreViewModelAsyncWithCorrectArguments()
    {
        // Arrange
        var mockFollowingService = new Mock<IFollowingService>();
        var controller = new FollowingController(mockFollowingService.Object);
        var sort = "test-sort";
        var page = 1;
        var username = "test-username";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, username)
        }));
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        await controller.All(sort, page);

        // Assert
        mockFollowingService.Verify(service => service.GetExploreViewModelAsync(sort, page, username), Times.Once);
    }

    [Test]
    public async Task All_SetsViewBagPropertiesToExpectedValues()
    {
        // Arrange
        var mockFollowingService = new Mock<IFollowingService>();
        var controller = new FollowingController(mockFollowingService.Object);
        var sort = "test-sort";
        var page = 1;
        var username = "test-username";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, username)
        }));
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        await controller.All(sort, page);

        // Assert
        Assert.That(controller.ViewBag.Sort, Is.EqualTo(sort));
        Assert.That(controller.ViewBag.CurrentPage, Is.EqualTo(page));
    }

    [Test]
    public async Task All_ReturnsViewResultWithModelOfTypeExploreViewModel()
    {
        // Arrange
        var mockFollowingService = new Mock<IFollowingService>();
        mockFollowingService
            .Setup(service => service.GetExploreViewModelAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
            .ReturnsAsync(new ExploreViewModel());

        var controller = new FollowingController(mockFollowingService.Object);
        var sort = "test-sort";
        var page = 1;
        var username = "test-username";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, username)
        }));

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        var result = await controller.All(sort, page);

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.InstanceOf<ExploreViewModel>());
    }
}