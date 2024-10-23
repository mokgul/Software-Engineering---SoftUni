namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using ArtfulAdventures.Services.Data.Interfaces;
using ViewModels.Message;


/// <summary>
///  This class is used to send messages between users.
/// </summary>
[Authorize]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    /// <summary>
    ///  Gets the message send form.
    /// </summary>
    /// <param name="username"> The username of the receiver. </param>
    /// <returns> The <see cref="MessageSendFormModel"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> SendMessage(string username)
    {
        var model = await _messageService.GetSendMessageFormAsync(username);
        return View(model);
    }

    /// <summary>
    ///  Sends a message to a user.
    /// </summary>
    /// <param name="model"> The <see cref="MessageSendFormModel"/>. </param>
    /// <returns> True if the message was sent successfully. </returns>
    [HttpPost]
    public async Task<IActionResult> SendMessage(MessageSendFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userId = GetUserId();
        var result = await _messageService.SendMessageAsync(model, userId);
        if (!result)
        {
            TempData["Error"] = "User does not exist.";
            return View(model);
        }

        TempData["Success"] = "Message sent successfully.";
        return View(model);
    }

    /// <summary>
    ///  Gets the message inbox of a user.
    /// </summary>
    /// <returns> The <see cref="MessageInbox"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var userId = GetUserId();
        var model = await _messageService.GetInboxAsync(userId);
        return View(model);
    }

    
    /// <summary>
    ///  Provides a functionality for viewing a message.
    /// </summary>
    /// <param name="id"> The id of the message. </param>
    /// <returns> The <see cref="MessageInboxViewModel"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> ViewMessage(int id)
    {
        var model = await _messageService.GetInboxViewModelAsync(id, GetUserId());
        if (model != null)
            return View(model);
        TempData["ErrorNotFound"] = "Message does not exist.";
        return RedirectToAction("Inbox", "Message");
    }

    
    /// <summary>
    ///  Provides a functionality for viewing the message history between two users.
    /// </summary>
    /// <param name="id"> The id of the message. </param>
    /// <returns> A view with the message history. </returns>
    [HttpGet]
    public async Task<IActionResult> ViewMessageHistory(int id)
    {
        var userId = GetUserId();
        var model = await _messageService.GetMessageHistoryAsync(id, userId);
        if (model != null)
            return View(model);
        TempData["ErrorNotFound"] = "Message does not exist.";
        return RedirectToAction("Inbox", "Message");
    }

    
    /// <summary>
    ///  Provides a functionality for replying to a message.
    /// </summary>
    /// <param name="id"> The id of the message. </param>
    /// <returns> The <see cref="MessageReplyFormModel"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> Reply(int id)
    {
        var model = await _messageService.GetReplyFormAsync(id, GetUserId());
        if (model != null) return View(model);
        TempData["ErrorNotFound"] = "Message does not exist.";
        return RedirectToAction("Inbox", "Message");

    }

    /// <summary>
    ///  Provides a method for getting the user id.
    /// </summary>
    /// <returns> The <see cref="string"/>. </returns>
    private string GetUserId()
    {
        return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
}