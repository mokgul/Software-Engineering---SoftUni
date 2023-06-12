using Contacts.Services.Contracts;
using Contacts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> All()
        {
            var allContacts = await _contactService.GetAllAsync();

            return View(allContacts);
        }

        public async Task<IActionResult> Team()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myTeam = await _contactService.GetMyTeamContactsAsync(userId);

            return View(myTeam);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ContactFormModel model = new ContactFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await _contactService.AddContactAsync(model);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(string contactId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _contactService.AddToTeamAsync(userId, contactId);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(string contactId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _contactService.RemoveFromMyTeamAsync(userId, contactId);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Contacts");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            if (contact == null) { return NotFound(); }

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ContactFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                await _contactService.EditContactAsync(id, model);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Contacts");
        }
    }
}
