using System.Collections;
using ArtfulAdventures.Services.Data.Interfaces;
using ArtfulAdventures.Web.Controllers;
using ArtfulAdventures.Web.ViewModels.Home;
using ArtfulAdventures.Web.ViewModels.Picture;
using ArtfulAdventures.Web.ViewModels.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;

namespace ArtfulAdventures.UnitTests.Controllers;

[TestFixture]
public class HomeControllerTests
{
    private HomeController _homeController;
    private Mock<ISearchService> _mockSearchService;
    private Mock<IExploreService> _mockExploreService;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mockSearchService = new Mock<ISearchService>();
        _mockExploreService = new Mock<IExploreService>();
        _homeController = new HomeController(_mockSearchService.Object, _mockExploreService.Object);
    }
    [Test]
    public async Task Index_ReturnsAViewResult_WithAListOfPictures()
    {
        // Arrange
        var mockExploreService = _mockExploreService;
        ICollection<PictureVisualizeViewModel> expectedModel = new List<PictureVisualizeViewModel>
        {
            new PictureVisualizeViewModel()
            {
                Id = "1", Likes = 1, CreatedOn = DateTime.UtcNow, Owner = "test", PictureUrl = "testURL",
                HashTags = new List<string>() { "tag1", "tag2" }
            },
            new PictureVisualizeViewModel()
            {
                Id = "1", Likes = 1, CreatedOn = DateTime.UtcNow, Owner = "test", PictureUrl = "testURL",
                HashTags = new List<string>() { "tag1", "tag2" }
            }
        };
        mockExploreService.Setup(x => x.GetPicturesForHomePageAsync()).ReturnsAsync(expectedModel);
        var controller = _homeController;
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.InstanceOf<ICollection<PictureVisualizeViewModel>>());
        var model = viewResult.Model as ICollection<PictureVisualizeViewModel>;
        Assert.That(model, Is.EqualTo(expectedModel));
    }
    
    [Test]
    public async Task AboutUs_ReturnsAViewResult()
    {
        // Arrange
        var controller = _homeController;
        
        // Act
        var result = await controller.AboutUs();

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public async Task Privacy_ReturnsAViewResult()
    {
        // Arrange
        var controller = _homeController;
        
        // Act
        var result = await controller.Privacy();

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public async Task Error_ReturnsAViewResult()
    {
        // Arrange
        var controller = _homeController;
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup(context => context.TraceIdentifier).Returns("test trace identifier");
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = mockHttpContext.Object
        };

        // Act
        var result = controller.Error();

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.InstanceOf<ErrorViewModel>());
        var model = viewResult.Model as ErrorViewModel;
        Assert.That(model.RequestId, Is.EqualTo("test trace identifier"));
    }

    [Test]
    public async Task Search_ReturnsAViewResult()
    {
        //Arrange
        var model = new SearchViewModel
        {
            Pictures = new List<PictureSearchViewModel>
            {
                new PictureSearchViewModel
                {
                    Id = "1",
                    Description = "A beautiful landscape",
                    PictureUrl = "https://example.com/picture1.jpg",
                    Owner = "John Doe",
                    CreatedOn = DateTime.UtcNow
                }
            },
            Challenges = new List<ChallengeSearchViewModel>
            {
                new ChallengeSearchViewModel
                {
                    Id = 1,
                    Creator = "Jane Doe",
                    CreatedOn = DateTime.UtcNow,
                    Requirements = "Take a picture of a sunset"
                }
            },
            Blogs = new List<BlogSearchViewModel>
            {
                new BlogSearchViewModel
                {
                    Id = "1",
                    Title = "My trip to Paris",
                    Author = "John Doe",
                    CreatedOn = DateTime.UtcNow,
                    Content = "I had a wonderful time in Paris..."
                }
            },
            Users = new List<UserSearchViewModel>
            {
                new UserSearchViewModel
                {
                    Id = "1",
                    UserName = "johndoe",
                    Name = "John Doe",
                    Uploads = 10
                }
            },
            ResultsCount = 4,
            SearchTime = 100
        };
        _mockSearchService.Setup(x => x.SearchAsync("test", 1)).ReturnsAsync(model);
        var controller = _homeController;
        
        //Act
        var result = await controller.Search("test", 1);
        
        //Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.InstanceOf<SearchViewModel>());
        var viewModel = viewResult.Model as SearchViewModel;
        Assert.That(viewModel, Is.EqualTo(model));
    }

    [Test]
    public async Task Search_RedirectsToIndexHome()
    {
        //Arrange
        var controller = _homeController;
        
        //Act
        var result = await controller.Search(null, 1);
        
        //Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectResult = result as RedirectToActionResult;
        Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
    }
}