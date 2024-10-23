using System.Security.Claims;
using ArtfulAdventures.Services.Data.Interfaces;
using ArtfulAdventures.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ArtfulAdventures.UnitTests.Controllers;

[TestFixture]
public class CommentControllerTests
{
    private CommentController _commentController;
    private Mock<ICommentService> _mockCommentService;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _mockCommentService = new Mock<ICommentService>();
        _commentController = new CommentController(_mockCommentService.Object);
    }
    
    [Test]
    public async Task AddCommentPicture_WhenCalled_ReturnsRedirectToActionResult()
    {
        // Arrange
        var content = "test";
        var pictureId = "test";
        var mockCommentService = _mockCommentService;
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _commentController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        mockCommentService.Setup(x => x.AddCommentPicture(content, pictureId, "test"))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _commentController.AddCommentPicture(content, pictureId);
        
        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }

    [Test]
    public async Task AddCommentBlog_WhenCalled_ReturnsRedirectToActionResult()
    {
        // Arrange
        var content = "test";
        var blogId = "test";
        var mockCommentService = _mockCommentService;
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _commentController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        mockCommentService.Setup(x => x.AddCommentBlog(content, blogId, "test"))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _commentController.AddCommentBlog(content, blogId);
        
        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        
    }

    [Test]
    public async Task AddCommentPicture_Redirects_WhenContentIsEmpty()
    {
        var content = "";
        var pictureId = "test";
        var mockCommentService = _mockCommentService;
        mockCommentService.Setup(x => x.AddCommentPicture(content, pictureId, "test"))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _commentController.AddCommentPicture(content, pictureId);
        
        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }
    
    [Test]
    public async Task AddCommentBlog_Redirects_WhenContentIsEmpty()
    {
        var content = "";
        var blogId = "test";
        var mockCommentService = _mockCommentService;
        mockCommentService.Setup(x => x.AddCommentBlog(content, blogId, "test"))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _commentController.AddCommentBlog(content, blogId);
        
        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }
}