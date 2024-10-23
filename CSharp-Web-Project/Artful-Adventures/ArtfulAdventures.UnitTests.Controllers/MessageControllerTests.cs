using System.Security.Claims;
using ArtfulAdventures.Services.Data.Interfaces;
using ArtfulAdventures.Web.Controllers;
using ArtfulAdventures.Web.ViewModels.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;

namespace ArtfulAdventures.UnitTests.Controllers;

[TestFixture]
public class MessageControllerTests
{
    private MessageController _messageController;
    private Mock<IMessageService> _mockMessageService;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _mockMessageService = new Mock<IMessageService>();
        _messageController = new MessageController(_mockMessageService.Object);
    }
    
    [Test]
    public async Task SendMessage_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var username = "test";
        var mockMessageService = _mockMessageService;
        var expectedModel = new MessageSendFormModel()
        {
            Receiver = "test"
        };
        mockMessageService.Setup(x => x.GetSendMessageFormAsync(username))
            .ReturnsAsync(expectedModel);
        
        // Act
        var result = await _messageController.SendMessage(username);
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public async Task SendMessage_WhenCalled_ReturnsViewResultWithModel()
    {
        // Arrange
        var username = "test";
        var mockMessageService = _mockMessageService;
        var expectedModel = new MessageSendFormModel()
        {
            Receiver = "test"
        };
        mockMessageService.Setup(x => x.GetSendMessageFormAsync(username))
            .ReturnsAsync(expectedModel);
        
        // Act
        var result = await _messageController.SendMessage(username);
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsInstanceOf<MessageSendFormModel>(viewResult?.Model);
        var model = viewResult?.Model as MessageSendFormModel;
        Assert.AreEqual(expectedModel.Receiver, model?.Receiver);
    }
    
    [Test]
    public async Task SendMessage_WhenSendMessageAsyncReturnsTrue_AddsSuccessMessageToTempDataAndReturnsViewResult()
    {
        // Arrange
        var mockMessageService = new Mock<IMessageService>();
        mockMessageService
            .Setup(service => service.SendMessageAsync(It.IsAny<MessageSendFormModel>(), It.IsAny<string>()))
            .ReturnsAsync(true);

        var controller = new MessageController(mockMessageService.Object);
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;

        var model = new MessageSendFormModel { /* set properties here */ };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        var result = await controller.SendMessage(model);

        // Assert
        Assert.That(controller.TempData["Success"], Is.EqualTo("Message sent successfully."));
        Assert.That(controller.TempData["Error"], Is.Null);
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public async Task SendMessage_WhenSendMessageAsyncReturnsFalse_AddsErrorMessageToTempDataAndReturnsViewResult()
    {
        // Arrange
        var mockMessageService = new Mock<IMessageService>();
        mockMessageService
            .Setup(service => service.SendMessageAsync(It.IsAny<MessageSendFormModel>(), It.IsAny<string>()))
            .ReturnsAsync(false);

        var controller = new MessageController(mockMessageService.Object);
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;

        var model = new MessageSendFormModel { /* set properties here */ };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        // Act
        var result = await controller.SendMessage(model);

        // Assert
        Assert.That(controller.TempData["Error"], Is.EqualTo("User does not exist."));
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public async Task SendMessage_ReturnsView_WhenModelStateIsInvalid()
    {
        // Arrange
        var mockMessageService = _mockMessageService;
        var controller = _messageController;
        controller.ModelState.AddModelError("error", "error");

        // Act
        var result = await controller.SendMessage(new MessageSendFormModel());

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }
    
    [Test]
    public async Task Inbox_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var username = "test";
        var mockMessageService = _mockMessageService;
        var expectedModel = new MessageInbox()
        {
            Messages = new List<MessageInboxViewModel>()
            {
                new MessageInboxViewModel()
                {
                    Sender = "test",
                    Content = "test"
                }
            },
            TotalUnreadMessages = 2,
        };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        
        mockMessageService.Setup(x => x.GetInboxAsync(username))
            .ReturnsAsync(expectedModel);
        
        // Act
        var result = await _messageController.Inbox();
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task ViewMessage_WhenCalled_ReturnsViewForm()
    {
        // Arrange
        var messageId = 1;
        var mockMessageService = _mockMessageService;
        var controller = _messageController;
        var expectedModel = new MessageInboxViewModel()
        {
            Sender = "test",
            Content = "test",
            Subject = "test"
        };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        
        mockMessageService.Setup(x => x.GetInboxViewModelAsync(messageId, userId))
            .ReturnsAsync(expectedModel);
        // Act
        var result = await controller.ViewMessage(messageId);
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task ViewMessage_WhenCalledAndModelIsNull_SetsTempData_AndRedirects()
    {
        // Arrange
        var messageId = 1;
        var mockMessageService = _mockMessageService;
        var controller = _messageController;
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;
        
        mockMessageService.Setup(x => x.GetInboxViewModelAsync(messageId, userId))
            .ReturnsAsync((MessageInboxViewModel)null);
        // Act
        var result = await controller.ViewMessage(messageId);
        
        // Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectResult = result as RedirectToActionResult;
        Assert.That(redirectResult.ActionName, Is.EqualTo("Inbox"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Message"));
    }
    
    [Test]
    public async Task ViewMessageHistory_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var id = 1;
        var mockMessageService = _mockMessageService;
        var expectedModel = new MessageInboxViewModel()
        {
            Sender = "test",
            Content = "test",
            Subject = "test"
        };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        
        mockMessageService.Setup(x => x.GetMessageHistoryAsync(id, userId))
            .ReturnsAsync(expectedModel);
        
        // Act
        var result = await _messageController.ViewMessageHistory(id);
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task ViewMessageHistory_WhenModelIsNUll_RedirectsToAction()
    {
        // Arrange
        var id = 1;
        var mockMessageService = _mockMessageService;
        var controller = _messageController;
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;
        
        mockMessageService.Setup(x => x.GetMessageHistoryAsync(id, userId))
            .ReturnsAsync((MessageInboxViewModel)null);
        
        // Act
        var result = await controller.ViewMessageHistory(id);
        
        // Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectResult = result as RedirectToActionResult;
        Assert.That(redirectResult.ActionName, Is.EqualTo("Inbox"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Message"));
        
    }
    
    [Test]
    public async Task ReplyMessage_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var id = 1;
        var mockMessageService = _mockMessageService;
        var expectedModel = new MessageReplyFormModel()
        {
            Receiver = "test",
            Content = "test",
            Subject = "test"
        };
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        
        mockMessageService.Setup(x => x.GetReplyFormAsync(id, userId))
            .ReturnsAsync(expectedModel);
        
        // Act
        var result = await _messageController.Reply(id);
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task Reply_WhenModelIsNUll_RedirectsToAction()
    {
        var id = 1;
        var mockMessageService = _mockMessageService;
        var controller = _messageController;
        var userId = "test-user-id";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        _messageController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
        var tempDataProvider = new Mock<ITempDataProvider>();
        var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);
        controller.TempData = tempData;
        
        mockMessageService.Setup(x => x.GetReplyFormAsync(id, userId))
            .ReturnsAsync((MessageReplyFormModel)null);
        
        // Act
        var result = await controller.Reply(id);
        
        // Assert
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        var redirectResult = result as RedirectToActionResult;
        Assert.That(redirectResult.ActionName, Is.EqualTo("Inbox"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Message"));
    }
}
